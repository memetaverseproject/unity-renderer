// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: memetaverse/sdk/components/gltf_container.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace DCL.ECSComponents {

  /// <summary>Holder for reflection information generated from memetaverse/sdk/components/gltf_container.proto</summary>
  public static partial class GltfContainerReflection {

    #region Descriptor
    /// <summary>File descriptor for memetaverse/sdk/components/gltf_container.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static GltfContainerReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Ci9tZW1ldGF2ZXJzZS9zZGsvY29tcG9uZW50cy9nbHRmX2NvbnRhaW5lci5w",
            "cm90bxIabWVtZXRhdmVyc2Uuc2RrLmNvbXBvbmVudHMiygEKD1BCR2x0ZkNv",
            "bnRhaW5lchILCgNzcmMYASABKAkSKgoddmlzaWJsZV9tZXNoZXNfY29sbGlz",
            "aW9uX21hc2sYBCABKA1IAIgBARIsCh9pbnZpc2libGVfbWVzaGVzX2NvbGxp",
            "c2lvbl9tYXNrGAUgASgNSAGIAQFCIAoeX3Zpc2libGVfbWVzaGVzX2NvbGxp",
            "c2lvbl9tYXNrQiIKIF9pbnZpc2libGVfbWVzaGVzX2NvbGxpc2lvbl9tYXNr",
            "SgQIAhADSgQIAxAEQhSqAhFEQ0wuRUNTQ29tcG9uZW50c2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::DCL.ECSComponents.PBGltfContainer), global::DCL.ECSComponents.PBGltfContainer.Parser, new[]{ "Src", "VisibleMeshesCollisionMask", "InvisibleMeshesCollisionMask" }, new[]{ "VisibleMeshesCollisionMask", "InvisibleMeshesCollisionMask" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// GltfContainer loads a GLTF file (and any additional files packaged inside) attached to an Entity.
  ///
  /// This allows the use of custom models, materials, collision boundaries and shapes that can't be 
  /// achieved using MeshRenderer, MeshCollider and other standard components.
  /// </summary>
  public sealed partial class PBGltfContainer : pb::IMessage<PBGltfContainer>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<PBGltfContainer> _parser = new pb::MessageParser<PBGltfContainer>(() => new PBGltfContainer());
    private pb::UnknownFieldSet _unknownFields;
    private int _hasBits0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<PBGltfContainer> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::DCL.ECSComponents.GltfContainerReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PBGltfContainer() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PBGltfContainer(PBGltfContainer other) : this() {
      _hasBits0 = other._hasBits0;
      src_ = other.src_;
      visibleMeshesCollisionMask_ = other.visibleMeshesCollisionMask_;
      invisibleMeshesCollisionMask_ = other.invisibleMeshesCollisionMask_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PBGltfContainer Clone() {
      return new PBGltfContainer(this);
    }

    /// <summary>Field number for the "src" field.</summary>
    public const int SrcFieldNumber = 1;
    private string src_ = "";
    /// <summary>
    /// the GLTF file path as listed in the scene's manifest.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Src {
      get { return src_; }
      set {
        src_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "visible_meshes_collision_mask" field.</summary>
    public const int VisibleMeshesCollisionMaskFieldNumber = 4;
    private uint visibleMeshesCollisionMask_;
    /// <summary>
    /// default: 0
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint VisibleMeshesCollisionMask {
      get { if ((_hasBits0 & 1) != 0) { return visibleMeshesCollisionMask_; } else { return 0; } }
      set {
        _hasBits0 |= 1;
        visibleMeshesCollisionMask_ = value;
      }
    }
    /// <summary>Gets whether the "visible_meshes_collision_mask" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasVisibleMeshesCollisionMask {
      get { return (_hasBits0 & 1) != 0; }
    }
    /// <summary>Clears the value of the "visible_meshes_collision_mask" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearVisibleMeshesCollisionMask() {
      _hasBits0 &= ~1;
    }

    /// <summary>Field number for the "invisible_meshes_collision_mask" field.</summary>
    public const int InvisibleMeshesCollisionMaskFieldNumber = 5;
    private uint invisibleMeshesCollisionMask_;
    /// <summary>
    /// default: CL_POINTER | CL_PHYSICS
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint InvisibleMeshesCollisionMask {
      get { if ((_hasBits0 & 2) != 0) { return invisibleMeshesCollisionMask_; } else { return 0; } }
      set {
        _hasBits0 |= 2;
        invisibleMeshesCollisionMask_ = value;
      }
    }
    /// <summary>Gets whether the "invisible_meshes_collision_mask" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasInvisibleMeshesCollisionMask {
      get { return (_hasBits0 & 2) != 0; }
    }
    /// <summary>Clears the value of the "invisible_meshes_collision_mask" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearInvisibleMeshesCollisionMask() {
      _hasBits0 &= ~2;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as PBGltfContainer);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(PBGltfContainer other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Src != other.Src) return false;
      if (VisibleMeshesCollisionMask != other.VisibleMeshesCollisionMask) return false;
      if (InvisibleMeshesCollisionMask != other.InvisibleMeshesCollisionMask) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Src.Length != 0) hash ^= Src.GetHashCode();
      if (HasVisibleMeshesCollisionMask) hash ^= VisibleMeshesCollisionMask.GetHashCode();
      if (HasInvisibleMeshesCollisionMask) hash ^= InvisibleMeshesCollisionMask.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Src.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Src);
      }
      if (HasVisibleMeshesCollisionMask) {
        output.WriteRawTag(32);
        output.WriteUInt32(VisibleMeshesCollisionMask);
      }
      if (HasInvisibleMeshesCollisionMask) {
        output.WriteRawTag(40);
        output.WriteUInt32(InvisibleMeshesCollisionMask);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Src.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Src);
      }
      if (HasVisibleMeshesCollisionMask) {
        output.WriteRawTag(32);
        output.WriteUInt32(VisibleMeshesCollisionMask);
      }
      if (HasInvisibleMeshesCollisionMask) {
        output.WriteRawTag(40);
        output.WriteUInt32(InvisibleMeshesCollisionMask);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (Src.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Src);
      }
      if (HasVisibleMeshesCollisionMask) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(VisibleMeshesCollisionMask);
      }
      if (HasInvisibleMeshesCollisionMask) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(InvisibleMeshesCollisionMask);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(PBGltfContainer other) {
      if (other == null) {
        return;
      }
      if (other.Src.Length != 0) {
        Src = other.Src;
      }
      if (other.HasVisibleMeshesCollisionMask) {
        VisibleMeshesCollisionMask = other.VisibleMeshesCollisionMask;
      }
      if (other.HasInvisibleMeshesCollisionMask) {
        InvisibleMeshesCollisionMask = other.InvisibleMeshesCollisionMask;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Src = input.ReadString();
            break;
          }
          case 32: {
            VisibleMeshesCollisionMask = input.ReadUInt32();
            break;
          }
          case 40: {
            InvisibleMeshesCollisionMask = input.ReadUInt32();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            Src = input.ReadString();
            break;
          }
          case 32: {
            VisibleMeshesCollisionMask = input.ReadUInt32();
            break;
          }
          case 40: {
            InvisibleMeshesCollisionMask = input.ReadUInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
