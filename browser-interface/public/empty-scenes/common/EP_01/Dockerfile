FROM node:10

# Create app directory
WORKDIR /usr/src/app

RUN npm install --global memetaverse@next

# Install app dependencies
# A wildcard is used to ensure both package.json AND package-lock.json are copied
# where available (npm@5+)
COPY package*.json ./

RUN npm install
# If you are building your code for production
# RUN npm install --only=production

# Bundle app source
COPY . .

EXPOSE 8000
CMD [ "npm", "start", "--", "--ci" ]