const fs = require('fs')
const path = require('path')

try {
  fs.mkdirSync(path.join(__dirname, 'contents'))
} catch (e) {}

const data = {}
const dirs = fs.readdirSync('.').filter(e => e !== 'contents' && fs.statSync(e).isDirectory())
for (let dir of dirs) {
  const builder = require('./' + dir + '/builder.json')
  const sceneMappings = [{ file: 'bin/game.js', hash: dir + '.js' }, { file: 'scene.json', hash: 'scene.json' }]
  if (builder.version === 3) {
    const ids = Object.keys(builder.scene.components)
    for (let id of ids) {
      const datum = builder.scene.components[id]
      if (!datum.data.mappings) {
        continue
      }
      for (let map of Object.keys(datum.data.mappings)) {
        const basename = map.replace(/^[^\/]+\//g, '')
        sceneMappings.push({ file: 'models/' + basename, hash: datum.data.mappings[map] })
        fs.copyFileSync(
          path.join(__dirname, dir, 'models', basename),
          path.join(__dirname, 'contents', datum.data.mappings[map])
        )
      }
    }
  } else if (builder.version === 11) {
    const ids = Object.keys(builder.scene.sdk6.assets)
    for (let id of ids) {
      const assets = builder.scene.sdk6.assets[id].contents
      for (let asset of Object.keys(assets)) {
        sceneMappings.push({ file: 'models/' + asset, hash: assets[asset] })
        fs.copyFileSync(path.join(__dirname, dir, 'models', asset), path.join(__dirname, 'contents', assets[asset]))
      }
    }
  }
  if (
    fs
      .readFileSync(path.join(__dirname, dir, 'bin/game.js'))
      .toString()
      .startsWith('mtv.subscribe')
  ) {
    fs.copyFileSync(path.join(__dirname, dir, 'bin/game.js'), path.join(__dirname, 'contents', dir + '.js'))
  } else {
    fs.writeFileSync(
      path.join(__dirname, 'contents', dir + '.js'),
      `
mtv.subscribe('sceneStart')

function Vector3(x, y, z) {
  return { x, y, z }
}
function Quaternion(x, y, z, w) {
  return { x, y, z, w }
}
function Transform(transformData) {
  return transformData
}
function GLTFShape(url) {
  return { src: url }
}
const ids = {}
function normalEntityId(id) {
  if (!ids[id]) {
    ids[id] = (Object.keys(ids).length + 1).toString(10)
  }
  return ids[id]
}
function Entity(id) {
  this.id = normalEntityId(id)
  return this
}
Entity.prototype.setParent = function(parent) {
  mtv.setParent(this.id, parent.id)
}
Entity.prototype.addComponentOrReplace = function(component) {
  if (component.position && component.rotation && component.scale) {
    mtv.updateEntityComponent(this.id, 'engine.transform', 1, JSON.stringify(component))
  } else if (component.src) {
    mtv.componentCreated('gl_' + this.id, 'engine.shape', 54)
    mtv.componentUpdated('gl_' + this.id, JSON.stringify(component))
    mtv.attachEntityComponent(this.id, 'engine.shape', 'gl_' + this.id)
  }
}
var engine = {
  addEntity: function(entity) {
    mtv.addEntity(entity.id)
    if (entity.id === "1") {
      mtv.setParent(entity.id, "0")
    }
  }
}\n` + fs.readFileSync(path.join(__dirname, dir, 'bin/game.js')).toString()
    )
  }
  data[dir] = sceneMappings
}

fs.writeFileSync('./index.json', JSON.stringify(data, null, 2))
