// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: memetaverse/sdk/components/pointer_events_result.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace DCL.ECSComponents {

  /// <summary>Holder for reflection information generated from memetaverse/sdk/components/pointer_events_result.proto</summary>
  public static partial class PointerEventsResultReflection {

    #region Descriptor
    /// <summary>File descriptor for memetaverse/sdk/components/pointer_events_result.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static PointerEventsResultReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CjZtZW1ldGF2ZXJzZS9zZGsvY29tcG9uZW50cy9wb2ludGVyX2V2ZW50c19y",
            "ZXN1bHQucHJvdG8SGm1lbWV0YXZlcnNlLnNkay5jb21wb25lbnRzGjRtZW1l",
            "dGF2ZXJzZS9zZGsvY29tcG9uZW50cy9jb21tb24vaW5wdXRfYWN0aW9uLnBy",
            "b3RvGjNtZW1ldGF2ZXJzZS9zZGsvY29tcG9uZW50cy9jb21tb24vcmF5Y2Fz",
            "dF9oaXQucHJvdG8inwIKFVBCUG9pbnRlckV2ZW50c1Jlc3VsdBI+CgZidXR0",
            "b24YASABKA4yLi5tZW1ldGF2ZXJzZS5zZGsuY29tcG9uZW50cy5jb21tb24u",
            "SW5wdXRBY3Rpb24SOgoDaGl0GAIgASgLMi0ubWVtZXRhdmVyc2Uuc2RrLmNv",
            "bXBvbmVudHMuY29tbW9uLlJheWNhc3RIaXQSQgoFc3RhdGUYBCABKA4yMy5t",
            "ZW1ldGF2ZXJzZS5zZGsuY29tcG9uZW50cy5jb21tb24uUG9pbnRlckV2ZW50",
            "VHlwZRIRCgl0aW1lc3RhbXAYBSABKA0SEwoGYW5hbG9nGAYgASgCSACIAQES",
            "EwoLdGlja19udW1iZXIYByABKA1CCQoHX2FuYWxvZ0IUqgIRRENMLkVDU0Nv",
            "bXBvbmVudHNiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::DCL.ECSComponents.InputActionReflection.Descriptor, global::DCL.ECSComponents.RaycastHitReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::DCL.ECSComponents.PBPointerEventsResult), global::DCL.ECSComponents.PBPointerEventsResult.Parser, new[]{ "Button", "Hit", "State", "Timestamp", "Analog", "TickNumber" }, new[]{ "Analog" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// renderer append a new object of this in each command, there can be many commands per frames
  /// </summary>
  public sealed partial class PBPointerEventsResult : pb::IMessage<PBPointerEventsResult>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<PBPointerEventsResult> _parser = new pb::MessageParser<PBPointerEventsResult>(() => new PBPointerEventsResult());
    private pb::UnknownFieldSet _unknownFields;
    private int _hasBits0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<PBPointerEventsResult> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::DCL.ECSComponents.PointerEventsResultReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PBPointerEventsResult() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PBPointerEventsResult(PBPointerEventsResult other) : this() {
      _hasBits0 = other._hasBits0;
      button_ = other.button_;
      hit_ = other.hit_ != null ? other.hit_.Clone() : null;
      state_ = other.state_;
      timestamp_ = other.timestamp_;
      analog_ = other.analog_;
      tickNumber_ = other.tickNumber_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PBPointerEventsResult Clone() {
      return new PBPointerEventsResult(this);
    }

    /// <summary>Field number for the "button" field.</summary>
    public const int ButtonFieldNumber = 1;
    private global::DCL.ECSComponents.InputAction button_ = global::DCL.ECSComponents.InputAction.IaPointer;
    /// <summary>
    /// identifier of the input
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::DCL.ECSComponents.InputAction Button {
      get { return button_; }
      set {
        button_ = value;
      }
    }

    /// <summary>Field number for the "hit" field.</summary>
    public const int HitFieldNumber = 2;
    private global::DCL.ECSComponents.RaycastHit hit_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::DCL.ECSComponents.RaycastHit Hit {
      get { return hit_; }
      set {
        hit_ = value;
      }
    }

    /// <summary>Field number for the "state" field.</summary>
    public const int StateFieldNumber = 4;
    private global::DCL.ECSComponents.PointerEventType state_ = global::DCL.ECSComponents.PointerEventType.PetUp;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::DCL.ECSComponents.PointerEventType State {
      get { return state_; }
      set {
        state_ = value;
      }
    }

    /// <summary>Field number for the "timestamp" field.</summary>
    public const int TimestampFieldNumber = 5;
    private uint timestamp_;
    /// <summary>
    /// monotonic counter
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint Timestamp {
      get { return timestamp_; }
      set {
        timestamp_ = value;
      }
    }

    /// <summary>Field number for the "analog" field.</summary>
    public const int AnalogFieldNumber = 6;
    private float analog_;
    /// <summary>
    /// if the input is analog then we store it here
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public float Analog {
      get { if ((_hasBits0 & 1) != 0) { return analog_; } else { return 0F; } }
      set {
        _hasBits0 |= 1;
        analog_ = value;
      }
    }
    /// <summary>Gets whether the "analog" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasAnalog {
      get { return (_hasBits0 & 1) != 0; }
    }
    /// <summary>Clears the value of the "analog" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearAnalog() {
      _hasBits0 &= ~1;
    }

    /// <summary>Field number for the "tick_number" field.</summary>
    public const int TickNumberFieldNumber = 7;
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
      return Equals(other as PBPointerEventsResult);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(PBPointerEventsResult other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Button != other.Button) return false;
      if (!object.Equals(Hit, other.Hit)) return false;
      if (State != other.State) return false;
      if (Timestamp != other.Timestamp) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Analog, other.Analog)) return false;
      if (TickNumber != other.TickNumber) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Button != global::DCL.ECSComponents.InputAction.IaPointer) hash ^= Button.GetHashCode();
      if (hit_ != null) hash ^= Hit.GetHashCode();
      if (State != global::DCL.ECSComponents.PointerEventType.PetUp) hash ^= State.GetHashCode();
      if (Timestamp != 0) hash ^= Timestamp.GetHashCode();
      if (HasAnalog) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Analog);
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
      if (Button != global::DCL.ECSComponents.InputAction.IaPointer) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Button);
      }
      if (hit_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Hit);
      }
      if (State != global::DCL.ECSComponents.PointerEventType.PetUp) {
        output.WriteRawTag(32);
        output.WriteEnum((int) State);
      }
      if (Timestamp != 0) {
        output.WriteRawTag(40);
        output.WriteUInt32(Timestamp);
      }
      if (HasAnalog) {
        output.WriteRawTag(53);
        output.WriteFloat(Analog);
      }
      if (TickNumber != 0) {
        output.WriteRawTag(56);
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
      if (Button != global::DCL.ECSComponents.InputAction.IaPointer) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Button);
      }
      if (hit_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Hit);
      }
      if (State != global::DCL.ECSComponents.PointerEventType.PetUp) {
        output.WriteRawTag(32);
        output.WriteEnum((int) State);
      }
      if (Timestamp != 0) {
        output.WriteRawTag(40);
        output.WriteUInt32(Timestamp);
      }
      if (HasAnalog) {
        output.WriteRawTag(53);
        output.WriteFloat(Analog);
      }
      if (TickNumber != 0) {
        output.WriteRawTag(56);
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
      if (Button != global::DCL.ECSComponents.InputAction.IaPointer) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Button);
      }
      if (hit_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Hit);
      }
      if (State != global::DCL.ECSComponents.PointerEventType.PetUp) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) State);
      }
      if (Timestamp != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Timestamp);
      }
      if (HasAnalog) {
        size += 1 + 4;
      }
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
    public void MergeFrom(PBPointerEventsResult other) {
      if (other == null) {
        return;
      }
      if (other.Button != global::DCL.ECSComponents.InputAction.IaPointer) {
        Button = other.Button;
      }
      if (other.hit_ != null) {
        if (hit_ == null) {
          Hit = new global::DCL.ECSComponents.RaycastHit();
        }
        Hit.MergeFrom(other.Hit);
      }
      if (other.State != global::DCL.ECSComponents.PointerEventType.PetUp) {
        State = other.State;
      }
      if (other.Timestamp != 0) {
        Timestamp = other.Timestamp;
      }
      if (other.HasAnalog) {
        Analog = other.Analog;
      }
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
            Button = (global::DCL.ECSComponents.InputAction) input.ReadEnum();
            break;
          }
          case 18: {
            if (hit_ == null) {
              Hit = new global::DCL.ECSComponents.RaycastHit();
            }
            input.ReadMessage(Hit);
            break;
          }
          case 32: {
            State = (global::DCL.ECSComponents.PointerEventType) input.ReadEnum();
            break;
          }
          case 40: {
            Timestamp = input.ReadUInt32();
            break;
          }
          case 53: {
            Analog = input.ReadFloat();
            break;
          }
          case 56: {
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
            Button = (global::DCL.ECSComponents.InputAction) input.ReadEnum();
            break;
          }
          case 18: {
            if (hit_ == null) {
              Hit = new global::DCL.ECSComponents.RaycastHit();
            }
            input.ReadMessage(Hit);
            break;
          }
          case 32: {
            State = (global::DCL.ECSComponents.PointerEventType) input.ReadEnum();
            break;
          }
          case 40: {
            Timestamp = input.ReadUInt32();
            break;
          }
          case 53: {
            Analog = input.ReadFloat();
            break;
          }
          case 56: {
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
