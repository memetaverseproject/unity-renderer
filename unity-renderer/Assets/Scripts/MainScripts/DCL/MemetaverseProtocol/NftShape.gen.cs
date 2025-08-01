// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: memetaverse/sdk/components/nft_shape.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace DCL.ECSComponents {

  /// <summary>Holder for reflection information generated from memetaverse/sdk/components/nft_shape.proto</summary>
  public static partial class NftShapeReflection {

    #region Descriptor
    /// <summary>File descriptor for memetaverse/sdk/components/nft_shape.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static NftShapeReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CiptZW1ldGF2ZXJzZS9zZGsvY29tcG9uZW50cy9uZnRfc2hhcGUucHJvdG8S",
            "Gm1lbWV0YXZlcnNlLnNkay5jb21wb25lbnRzGh9tZW1ldGF2ZXJzZS9jb21t",
            "b24vY29sb3JzLnByb3RvIpsBCgpQQk5mdFNoYXBlEgsKA3VybhgBIAEoCRI8",
            "CgVzdHlsZRgCIAEoDjIoLm1lbWV0YXZlcnNlLnNkay5jb21wb25lbnRzLk5m",
            "dEZyYW1lVHlwZUgAiAEBEi4KBWNvbG9yGAMgASgLMhoubWVtZXRhdmVyc2Uu",
            "Y29tbW9uLkNvbG9yM0gBiAEBQggKBl9zdHlsZUIICgZfY29sb3Iq2AMKDE5m",
            "dEZyYW1lVHlwZRIPCgtORlRfQ0xBU1NJQxAAEhgKFE5GVF9CQVJPUVVFX09S",
            "TkFNRU5UEAESGAoUTkZUX0RJQU1PTkRfT1JOQU1FTlQQAhIUChBORlRfTUlO",
            "SU1BTF9XSURFEAMSFAoQTkZUX01JTklNQUxfR1JFWRAEEg4KCk5GVF9CTE9D",
            "S1kQBRISCg5ORlRfR09MRF9FREdFUxAGEhMKD05GVF9HT0xEX0NBUlZFRBAH",
            "EhEKDU5GVF9HT0xEX1dJREUQCBIUChBORlRfR09MRF9ST1VOREVEEAkSFAoQ",
            "TkZUX01FVEFMX01FRElVTRAKEhIKDk5GVF9NRVRBTF9XSURFEAsSEgoOTkZU",
            "X01FVEFMX1NMSU0QDBIVChFORlRfTUVUQUxfUk9VTkRFRBANEgwKCE5GVF9Q",
            "SU5TEA4SFQoRTkZUX01JTklNQUxfQkxBQ0sQDxIVChFORlRfTUlOSU1BTF9X",
            "SElURRAQEgwKCE5GVF9UQVBFEBESEQoNTkZUX1dPT0RfU0xJTRASEhEKDU5G",
            "VF9XT09EX1dJREUQExISCg5ORlRfV09PRF9UV0lHUxAUEg4KCk5GVF9DQU5W",
            "QVMQFRIMCghORlRfTk9ORRAWQhSqAhFEQ0wuRUNTQ29tcG9uZW50c2IGcHJv",
            "dG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Memetaverse.Common.ColorsReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::DCL.ECSComponents.NftFrameType), }, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::DCL.ECSComponents.PBNftShape), global::DCL.ECSComponents.PBNftShape.Parser, new[]{ "Urn", "Style", "Color" }, new[]{ "Style", "Color" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  /// <summary>
  /// NftFrameType is a predefined framing style for the image.
  /// </summary>
  public enum NftFrameType {
    [pbr::OriginalName("NFT_CLASSIC")] NftClassic = 0,
    [pbr::OriginalName("NFT_BAROQUE_ORNAMENT")] NftBaroqueOrnament = 1,
    [pbr::OriginalName("NFT_DIAMOND_ORNAMENT")] NftDiamondOrnament = 2,
    [pbr::OriginalName("NFT_MINIMAL_WIDE")] NftMinimalWide = 3,
    [pbr::OriginalName("NFT_MINIMAL_GREY")] NftMinimalGrey = 4,
    [pbr::OriginalName("NFT_BLOCKY")] NftBlocky = 5,
    [pbr::OriginalName("NFT_GOLD_EDGES")] NftGoldEdges = 6,
    [pbr::OriginalName("NFT_GOLD_CARVED")] NftGoldCarved = 7,
    [pbr::OriginalName("NFT_GOLD_WIDE")] NftGoldWide = 8,
    [pbr::OriginalName("NFT_GOLD_ROUNDED")] NftGoldRounded = 9,
    [pbr::OriginalName("NFT_METAL_MEDIUM")] NftMetalMedium = 10,
    [pbr::OriginalName("NFT_METAL_WIDE")] NftMetalWide = 11,
    [pbr::OriginalName("NFT_METAL_SLIM")] NftMetalSlim = 12,
    [pbr::OriginalName("NFT_METAL_ROUNDED")] NftMetalRounded = 13,
    [pbr::OriginalName("NFT_PINS")] NftPins = 14,
    [pbr::OriginalName("NFT_MINIMAL_BLACK")] NftMinimalBlack = 15,
    [pbr::OriginalName("NFT_MINIMAL_WHITE")] NftMinimalWhite = 16,
    [pbr::OriginalName("NFT_TAPE")] NftTape = 17,
    [pbr::OriginalName("NFT_WOOD_SLIM")] NftWoodSlim = 18,
    [pbr::OriginalName("NFT_WOOD_WIDE")] NftWoodWide = 19,
    [pbr::OriginalName("NFT_WOOD_TWIGS")] NftWoodTwigs = 20,
    [pbr::OriginalName("NFT_CANVAS")] NftCanvas = 21,
    [pbr::OriginalName("NFT_NONE")] NftNone = 22,
  }

  #endregion

  #region Messages
  /// <summary>
  /// The NftShape component renders a framed picture from an NFT. It supports PNG, JPEG and GIF files.
  ///
  /// The `urn` field is the URI of the NFT, and must follow the format 'urn:decentraland:&lt;CHAIN>:&lt;CONTRACT_STANDARD>:&lt;CONTRACT_ADDRESS>:&lt;TOKEN_ID>'
  /// Example: 'urn:decentraland:ethereum:erc721:0x00000000:123'
  ///
  /// The picture frame can have several different styles, plus a background color for images that have
  /// transparent pixels.
  /// </summary>
  public sealed partial class PBNftShape : pb::IMessage<PBNftShape>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<PBNftShape> _parser = new pb::MessageParser<PBNftShape>(() => new PBNftShape());
    private pb::UnknownFieldSet _unknownFields;
    private int _hasBits0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<PBNftShape> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::DCL.ECSComponents.NftShapeReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PBNftShape() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PBNftShape(PBNftShape other) : this() {
      _hasBits0 = other._hasBits0;
      urn_ = other.urn_;
      style_ = other.style_;
      color_ = other.color_ != null ? other.color_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PBNftShape Clone() {
      return new PBNftShape(this);
    }

    /// <summary>Field number for the "urn" field.</summary>
    public const int UrnFieldNumber = 1;
    private string urn_ = "";
    /// <summary>
    /// the URI of the NFT
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Urn {
      get { return urn_; }
      set {
        urn_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "style" field.</summary>
    public const int StyleFieldNumber = 2;
    private global::DCL.ECSComponents.NftFrameType style_;
    /// <summary>
    /// the frame style (default NFT_CLASSIC)
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::DCL.ECSComponents.NftFrameType Style {
      get { if ((_hasBits0 & 1) != 0) { return style_; } else { return global::DCL.ECSComponents.NftFrameType.NftClassic; } }
      set {
        _hasBits0 |= 1;
        style_ = value;
      }
    }
    /// <summary>Gets whether the "style" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasStyle {
      get { return (_hasBits0 & 1) != 0; }
    }
    /// <summary>Clears the value of the "style" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearStyle() {
      _hasBits0 &= ~1;
    }

    /// <summary>Field number for the "color" field.</summary>
    public const int ColorFieldNumber = 3;
    private global::Memetaverse.Common.Color3 color_;
    /// <summary>
    /// RGB background (default [0.6404918, 0.611472, 0.8584906])
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Memetaverse.Common.Color3 Color {
      get { return color_; }
      set {
        color_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as PBNftShape);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(PBNftShape other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Urn != other.Urn) return false;
      if (Style != other.Style) return false;
      if (!object.Equals(Color, other.Color)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Urn.Length != 0) hash ^= Urn.GetHashCode();
      if (HasStyle) hash ^= Style.GetHashCode();
      if (color_ != null) hash ^= Color.GetHashCode();
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
      if (Urn.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Urn);
      }
      if (HasStyle) {
        output.WriteRawTag(16);
        output.WriteEnum((int) Style);
      }
      if (color_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(Color);
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
      if (Urn.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Urn);
      }
      if (HasStyle) {
        output.WriteRawTag(16);
        output.WriteEnum((int) Style);
      }
      if (color_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(Color);
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
      if (Urn.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Urn);
      }
      if (HasStyle) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Style);
      }
      if (color_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Color);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(PBNftShape other) {
      if (other == null) {
        return;
      }
      if (other.Urn.Length != 0) {
        Urn = other.Urn;
      }
      if (other.HasStyle) {
        Style = other.Style;
      }
      if (other.color_ != null) {
        if (color_ == null) {
          Color = new global::Memetaverse.Common.Color3();
        }
        Color.MergeFrom(other.Color);
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
            Urn = input.ReadString();
            break;
          }
          case 16: {
            Style = (global::DCL.ECSComponents.NftFrameType) input.ReadEnum();
            break;
          }
          case 26: {
            if (color_ == null) {
              Color = new global::Memetaverse.Common.Color3();
            }
            input.ReadMessage(Color);
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
            Urn = input.ReadString();
            break;
          }
          case 16: {
            Style = (global::DCL.ECSComponents.NftFrameType) input.ReadEnum();
            break;
          }
          case 26: {
            if (color_ == null) {
              Color = new global::Memetaverse.Common.Color3();
            }
            input.ReadMessage(Color);
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
