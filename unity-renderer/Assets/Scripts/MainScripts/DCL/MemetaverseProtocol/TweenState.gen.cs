// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: memetaverse/sdk/components/tween_state.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace DCL.ECSComponents {

  /// <summary>Holder for reflection information generated from memetaverse/sdk/components/tween_state.proto</summary>
  public static partial class TweenStateReflection {

    #region Descriptor
    /// <summary>File descriptor for memetaverse/sdk/components/tween_state.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static TweenStateReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CixtZW1ldGF2ZXJzZS9zZGsvY29tcG9uZW50cy90d2Vlbl9zdGF0ZS5wcm90",
            "bxIabWVtZXRhdmVyc2Uuc2RrLmNvbXBvbmVudHMiYQoMUEJUd2VlblN0YXRl",
            "EjsKBXN0YXRlGAEgASgOMiwubWVtZXRhdmVyc2Uuc2RrLmNvbXBvbmVudHMu",
            "VHdlZW5TdGF0ZVN0YXR1cxIUCgxjdXJyZW50X3RpbWUYAiABKAIqQgoQVHdl",
            "ZW5TdGF0ZVN0YXR1cxINCglUU19BQ1RJVkUQABIQCgxUU19DT01QTEVURUQQ",
            "ARINCglUU19QQVVTRUQQAkIUqgIRRENMLkVDU0NvbXBvbmVudHNiBnByb3Rv",
            "Mw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::DCL.ECSComponents.TweenStateStatus), }, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::DCL.ECSComponents.PBTweenState), global::DCL.ECSComponents.PBTweenState.Parser, new[]{ "State", "CurrentTime" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  public enum TweenStateStatus {
    [pbr::OriginalName("TS_ACTIVE")] TsActive = 0,
    [pbr::OriginalName("TS_COMPLETED")] TsCompleted = 1,
    [pbr::OriginalName("TS_PAUSED")] TsPaused = 2,
  }

  #endregion

  #region Messages
  public sealed partial class PBTweenState : pb::IMessage<PBTweenState>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<PBTweenState> _parser = new pb::MessageParser<PBTweenState>(() => new PBTweenState());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<PBTweenState> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::DCL.ECSComponents.TweenStateReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PBTweenState() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PBTweenState(PBTweenState other) : this() {
      state_ = other.state_;
      currentTime_ = other.currentTime_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PBTweenState Clone() {
      return new PBTweenState(this);
    }

    /// <summary>Field number for the "state" field.</summary>
    public const int StateFieldNumber = 1;
    private global::DCL.ECSComponents.TweenStateStatus state_ = global::DCL.ECSComponents.TweenStateStatus.TsActive;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::DCL.ECSComponents.TweenStateStatus State {
      get { return state_; }
      set {
        state_ = value;
      }
    }

    /// <summary>Field number for the "current_time" field.</summary>
    public const int CurrentTimeFieldNumber = 2;
    private float currentTime_;
    /// <summary>
    /// between 0 and 1
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public float CurrentTime {
      get { return currentTime_; }
      set {
        currentTime_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as PBTweenState);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(PBTweenState other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (State != other.State) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(CurrentTime, other.CurrentTime)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (State != global::DCL.ECSComponents.TweenStateStatus.TsActive) hash ^= State.GetHashCode();
      if (CurrentTime != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(CurrentTime);
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
      if (State != global::DCL.ECSComponents.TweenStateStatus.TsActive) {
        output.WriteRawTag(8);
        output.WriteEnum((int) State);
      }
      if (CurrentTime != 0F) {
        output.WriteRawTag(21);
        output.WriteFloat(CurrentTime);
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
      if (State != global::DCL.ECSComponents.TweenStateStatus.TsActive) {
        output.WriteRawTag(8);
        output.WriteEnum((int) State);
      }
      if (CurrentTime != 0F) {
        output.WriteRawTag(21);
        output.WriteFloat(CurrentTime);
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
      if (State != global::DCL.ECSComponents.TweenStateStatus.TsActive) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) State);
      }
      if (CurrentTime != 0F) {
        size += 1 + 4;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(PBTweenState other) {
      if (other == null) {
        return;
      }
      if (other.State != global::DCL.ECSComponents.TweenStateStatus.TsActive) {
        State = other.State;
      }
      if (other.CurrentTime != 0F) {
        CurrentTime = other.CurrentTime;
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
            State = (global::DCL.ECSComponents.TweenStateStatus) input.ReadEnum();
            break;
          }
          case 21: {
            CurrentTime = input.ReadFloat();
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
            State = (global::DCL.ECSComponents.TweenStateStatus) input.ReadEnum();
            break;
          }
          case 21: {
            CurrentTime = input.ReadFloat();
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
