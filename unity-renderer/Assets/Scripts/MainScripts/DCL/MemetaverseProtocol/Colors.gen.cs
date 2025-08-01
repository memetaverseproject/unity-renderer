// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: memetaverse/common/colors.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Memetaverse.Common {

  /// <summary>Holder for reflection information generated from memetaverse/common/colors.proto</summary>
  public static partial class ColorsReflection {

    #region Descriptor
    /// <summary>File descriptor for memetaverse/common/colors.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ColorsReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Ch9tZW1ldGF2ZXJzZS9jb21tb24vY29sb3JzLnByb3RvEhJtZW1ldGF2ZXJz",
            "ZS5jb21tb24iKQoGQ29sb3IzEgkKAXIYASABKAISCQoBZxgCIAEoAhIJCgFi",
            "GAMgASgCIjQKBkNvbG9yNBIJCgFyGAEgASgCEgkKAWcYAiABKAISCQoBYhgD",
            "IAEoAhIJCgFhGAQgASgCYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Memetaverse.Common.Color3), global::Memetaverse.Common.Color3.Parser, new[]{ "R", "G", "B" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Memetaverse.Common.Color4), global::Memetaverse.Common.Color4.Parser, new[]{ "R", "G", "B", "A" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class Color3 : pb::IMessage<Color3>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<Color3> _parser = new pb::MessageParser<Color3>(() => new Color3());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<Color3> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Memetaverse.Common.ColorsReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Color3() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Color3(Color3 other) : this() {
      r_ = other.r_;
      g_ = other.g_;
      b_ = other.b_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Color3 Clone() {
      return new Color3(this);
    }

    /// <summary>Field number for the "r" field.</summary>
    public const int RFieldNumber = 1;
    private float r_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public float R {
      get { return r_; }
      set {
        r_ = value;
      }
    }

    /// <summary>Field number for the "g" field.</summary>
    public const int GFieldNumber = 2;
    private float g_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public float G {
      get { return g_; }
      set {
        g_ = value;
      }
    }

    /// <summary>Field number for the "b" field.</summary>
    public const int BFieldNumber = 3;
    private float b_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public float B {
      get { return b_; }
      set {
        b_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as Color3);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(Color3 other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(R, other.R)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(G, other.G)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(B, other.B)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (R != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(R);
      if (G != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(G);
      if (B != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(B);
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
      if (R != 0F) {
        output.WriteRawTag(13);
        output.WriteFloat(R);
      }
      if (G != 0F) {
        output.WriteRawTag(21);
        output.WriteFloat(G);
      }
      if (B != 0F) {
        output.WriteRawTag(29);
        output.WriteFloat(B);
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
      if (R != 0F) {
        output.WriteRawTag(13);
        output.WriteFloat(R);
      }
      if (G != 0F) {
        output.WriteRawTag(21);
        output.WriteFloat(G);
      }
      if (B != 0F) {
        output.WriteRawTag(29);
        output.WriteFloat(B);
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
      if (R != 0F) {
        size += 1 + 4;
      }
      if (G != 0F) {
        size += 1 + 4;
      }
      if (B != 0F) {
        size += 1 + 4;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(Color3 other) {
      if (other == null) {
        return;
      }
      if (other.R != 0F) {
        R = other.R;
      }
      if (other.G != 0F) {
        G = other.G;
      }
      if (other.B != 0F) {
        B = other.B;
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
          case 13: {
            R = input.ReadFloat();
            break;
          }
          case 21: {
            G = input.ReadFloat();
            break;
          }
          case 29: {
            B = input.ReadFloat();
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
          case 13: {
            R = input.ReadFloat();
            break;
          }
          case 21: {
            G = input.ReadFloat();
            break;
          }
          case 29: {
            B = input.ReadFloat();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class Color4 : pb::IMessage<Color4>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<Color4> _parser = new pb::MessageParser<Color4>(() => new Color4());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<Color4> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Memetaverse.Common.ColorsReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Color4() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Color4(Color4 other) : this() {
      r_ = other.r_;
      g_ = other.g_;
      b_ = other.b_;
      a_ = other.a_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Color4 Clone() {
      return new Color4(this);
    }

    /// <summary>Field number for the "r" field.</summary>
    public const int RFieldNumber = 1;
    private float r_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public float R {
      get { return r_; }
      set {
        r_ = value;
      }
    }

    /// <summary>Field number for the "g" field.</summary>
    public const int GFieldNumber = 2;
    private float g_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public float G {
      get { return g_; }
      set {
        g_ = value;
      }
    }

    /// <summary>Field number for the "b" field.</summary>
    public const int BFieldNumber = 3;
    private float b_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public float B {
      get { return b_; }
      set {
        b_ = value;
      }
    }

    /// <summary>Field number for the "a" field.</summary>
    public const int AFieldNumber = 4;
    private float a_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public float A {
      get { return a_; }
      set {
        a_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as Color4);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(Color4 other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(R, other.R)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(G, other.G)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(B, other.B)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(A, other.A)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (R != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(R);
      if (G != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(G);
      if (B != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(B);
      if (A != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(A);
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
      if (R != 0F) {
        output.WriteRawTag(13);
        output.WriteFloat(R);
      }
      if (G != 0F) {
        output.WriteRawTag(21);
        output.WriteFloat(G);
      }
      if (B != 0F) {
        output.WriteRawTag(29);
        output.WriteFloat(B);
      }
      if (A != 0F) {
        output.WriteRawTag(37);
        output.WriteFloat(A);
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
      if (R != 0F) {
        output.WriteRawTag(13);
        output.WriteFloat(R);
      }
      if (G != 0F) {
        output.WriteRawTag(21);
        output.WriteFloat(G);
      }
      if (B != 0F) {
        output.WriteRawTag(29);
        output.WriteFloat(B);
      }
      if (A != 0F) {
        output.WriteRawTag(37);
        output.WriteFloat(A);
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
      if (R != 0F) {
        size += 1 + 4;
      }
      if (G != 0F) {
        size += 1 + 4;
      }
      if (B != 0F) {
        size += 1 + 4;
      }
      if (A != 0F) {
        size += 1 + 4;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(Color4 other) {
      if (other == null) {
        return;
      }
      if (other.R != 0F) {
        R = other.R;
      }
      if (other.G != 0F) {
        G = other.G;
      }
      if (other.B != 0F) {
        B = other.B;
      }
      if (other.A != 0F) {
        A = other.A;
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
          case 13: {
            R = input.ReadFloat();
            break;
          }
          case 21: {
            G = input.ReadFloat();
            break;
          }
          case 29: {
            B = input.ReadFloat();
            break;
          }
          case 37: {
            A = input.ReadFloat();
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
          case 13: {
            R = input.ReadFloat();
            break;
          }
          case 21: {
            G = input.ReadFloat();
            break;
          }
          case 29: {
            B = input.ReadFloat();
            break;
          }
          case 37: {
            A = input.ReadFloat();
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
