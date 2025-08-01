// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: memetaverse/sdk/components/raycast_result.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace DCL.ECSComponents {

  /// <summary>Holder for reflection information generated from memetaverse/sdk/components/raycast_result.proto</summary>
  public static partial class RaycastResultReflection {

    #region Descriptor
    /// <summary>File descriptor for memetaverse/sdk/components/raycast_result.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static RaycastResultReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Ci9tZW1ldGF2ZXJzZS9zZGsvY29tcG9uZW50cy9yYXljYXN0X3Jlc3VsdC5w",
            "cm90bxIabWVtZXRhdmVyc2Uuc2RrLmNvbXBvbmVudHMaIG1lbWV0YXZlcnNl",
            "L2NvbW1vbi92ZWN0b3JzLnByb3RvGjNtZW1ldGF2ZXJzZS9zZGsvY29tcG9u",
            "ZW50cy9jb21tb24vcmF5Y2FzdF9oaXQucHJvdG8i7QEKD1BCUmF5Y2FzdFJl",
            "c3VsdBIWCgl0aW1lc3RhbXAYASABKA1IAIgBARIyCg1nbG9iYWxfb3JpZ2lu",
            "GAIgASgLMhsubWVtZXRhdmVyc2UuY29tbW9uLlZlY3RvcjMSLgoJZGlyZWN0",
            "aW9uGAMgASgLMhsubWVtZXRhdmVyc2UuY29tbW9uLlZlY3RvcjMSOwoEaGl0",
            "cxgEIAMoCzItLm1lbWV0YXZlcnNlLnNkay5jb21wb25lbnRzLmNvbW1vbi5S",
            "YXljYXN0SGl0EhMKC3RpY2tfbnVtYmVyGAUgASgNQgwKCl90aW1lc3RhbXBC",
            "FKoCEURDTC5FQ1NDb21wb25lbnRzYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Memetaverse.Common.VectorsReflection.Descriptor, global::DCL.ECSComponents.RaycastHitReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::DCL.ECSComponents.PBRaycastResult), global::DCL.ECSComponents.PBRaycastResult.Parser, new[]{ "Timestamp", "GlobalOrigin", "Direction", "Hits", "TickNumber" }, new[]{ "Timestamp" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// The PBRaycast component and PBRaycastResult are defined in https://adr.memetaverse.org/adr/ADR-200
  ///
  /// The RaycastResult component is added to an Entity when the results of a previously attached
  /// Raycast component are available. It contains information about the ray and any objects it
  /// collided with.
  /// </summary>
  public sealed partial class PBRaycastResult : pb::IMessage<PBRaycastResult>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<PBRaycastResult> _parser = new pb::MessageParser<PBRaycastResult>(() => new PBRaycastResult());
    private pb::UnknownFieldSet _unknownFields;
    private int _hasBits0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<PBRaycastResult> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::DCL.ECSComponents.RaycastResultReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PBRaycastResult() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PBRaycastResult(PBRaycastResult other) : this() {
      _hasBits0 = other._hasBits0;
      timestamp_ = other.timestamp_;
      globalOrigin_ = other.globalOrigin_ != null ? other.globalOrigin_.Clone() : null;
      direction_ = other.direction_ != null ? other.direction_.Clone() : null;
      hits_ = other.hits_.Clone();
      tickNumber_ = other.tickNumber_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PBRaycastResult Clone() {
      return new PBRaycastResult(this);
    }

    /// <summary>Field number for the "timestamp" field.</summary>
    public const int TimestampFieldNumber = 1;
    private uint timestamp_;
    /// <summary>
    /// timestamp is a correlation id, copied from the PBRaycast
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint Timestamp {
      get { if ((_hasBits0 & 1) != 0) { return timestamp_; } else { return 0; } }
      set {
        _hasBits0 |= 1;
        timestamp_ = value;
      }
    }
    /// <summary>Gets whether the "timestamp" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasTimestamp {
      get { return (_hasBits0 & 1) != 0; }
    }
    /// <summary>Clears the value of the "timestamp" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearTimestamp() {
      _hasBits0 &= ~1;
    }

    /// <summary>Field number for the "global_origin" field.</summary>
    public const int GlobalOriginFieldNumber = 2;
    private global::Memetaverse.Common.Vector3 globalOrigin_;
    /// <summary>
    /// the starting point of the ray in global coordinates
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Memetaverse.Common.Vector3 GlobalOrigin {
      get { return globalOrigin_; }
      set {
        globalOrigin_ = value;
      }
    }

    /// <summary>Field number for the "direction" field.</summary>
    public const int DirectionFieldNumber = 3;
    private global::Memetaverse.Common.Vector3 direction_;
    /// <summary>
    /// the direction vector of the ray in global coordinates
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Memetaverse.Common.Vector3 Direction {
      get { return direction_; }
      set {
        direction_ = value;
      }
    }

    /// <summary>Field number for the "hits" field.</summary>
    public const int HitsFieldNumber = 4;
    private static readonly pb::FieldCodec<global::DCL.ECSComponents.RaycastHit> _repeated_hits_codec
        = pb::FieldCodec.ForMessage(34, global::DCL.ECSComponents.RaycastHit.Parser);
    private readonly pbc::RepeatedField<global::DCL.ECSComponents.RaycastHit> hits_ = new pbc::RepeatedField<global::DCL.ECSComponents.RaycastHit>();
    /// <summary>
    /// zero or more hits
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::DCL.ECSComponents.RaycastHit> Hits {
      get { return hits_; }
    }

    /// <summary>Field number for the "tick_number" field.</summary>
    public const int TickNumberFieldNumber = 5;
    private uint tickNumber_;
    /// <summary>
    /// number of tick in which the event was produced, equals to EngineInfo.tick_number
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint TickNumber {
      get { return tickNumber_; }
      set {
        tickNumber_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as PBRaycastResult);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(PBRaycastResult other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Timestamp != other.Timestamp) return false;
      if (!object.Equals(GlobalOrigin, other.GlobalOrigin)) return false;
      if (!object.Equals(Direction, other.Direction)) return false;
      if(!hits_.Equals(other.hits_)) return false;
      if (TickNumber != other.TickNumber) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (HasTimestamp) hash ^= Timestamp.GetHashCode();
      if (globalOrigin_ != null) hash ^= GlobalOrigin.GetHashCode();
      if (direction_ != null) hash ^= Direction.GetHashCode();
      hash ^= hits_.GetHashCode();
      if (TickNumber != 0) hash ^= TickNumber.GetHashCode();
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
      if (HasTimestamp) {
        output.WriteRawTag(8);
        output.WriteUInt32(Timestamp);
      }
      if (globalOrigin_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(GlobalOrigin);
      }
      if (direction_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(Direction);
      }
      hits_.WriteTo(output, _repeated_hits_codec);
      if (TickNumber != 0) {
        output.WriteRawTag(40);
        output.WriteUInt32(TickNumber);
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
      if (HasTimestamp) {
        output.WriteRawTag(8);
        output.WriteUInt32(Timestamp);
      }
      if (globalOrigin_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(GlobalOrigin);
      }
      if (direction_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(Direction);
      }
      hits_.WriteTo(ref output, _repeated_hits_codec);
      if (TickNumber != 0) {
        output.WriteRawTag(40);
        output.WriteUInt32(TickNumber);
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
      if (HasTimestamp) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Timestamp);
      }
      if (globalOrigin_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(GlobalOrigin);
      }
      if (direction_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Direction);
      }
      size += hits_.CalculateSize(_repeated_hits_codec);
      if (TickNumber != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(TickNumber);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(PBRaycastResult other) {
      if (other == null) {
        return;
      }
      if (other.HasTimestamp) {
        Timestamp = other.Timestamp;
      }
      if (other.globalOrigin_ != null) {
        if (globalOrigin_ == null) {
          GlobalOrigin = new global::Memetaverse.Common.Vector3();
        }
        GlobalOrigin.MergeFrom(other.GlobalOrigin);
      }
      if (other.direction_ != null) {
        if (direction_ == null) {
          Direction = new global::Memetaverse.Common.Vector3();
        }
        Direction.MergeFrom(other.Direction);
      }
      hits_.Add(other.hits_);
      if (other.TickNumber != 0) {
        TickNumber = other.TickNumber;
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
          case 8: {
            Timestamp = input.ReadUInt32();
            break;
          }
          case 18: {
            if (globalOrigin_ == null) {
              GlobalOrigin = new global::Memetaverse.Common.Vector3();
            }
            input.ReadMessage(GlobalOrigin);
            break;
          }
          case 26: {
            if (direction_ == null) {
              Direction = new global::Memetaverse.Common.Vector3();
            }
            input.ReadMessage(Direction);
            break;
          }
          case 34: {
            hits_.AddEntriesFrom(input, _repeated_hits_codec);
            break;
          }
          case 40: {
            TickNumber = input.ReadUInt32();
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
          case 8: {
            Timestamp = input.ReadUInt32();
            break;
          }
          case 18: {
            if (globalOrigin_ == null) {
              GlobalOrigin = new global::Memetaverse.Common.Vector3();
            }
            input.ReadMessage(GlobalOrigin);
            break;
          }
          case 26: {
            if (direction_ == null) {
              Direction = new global::Memetaverse.Common.Vector3();
            }
            input.ReadMessage(Direction);
            break;
          }
          case 34: {
            hits_.AddEntriesFrom(ref input, _repeated_hits_codec);
            break;
          }
          case 40: {
            TickNumber = input.ReadUInt32();
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
