// <auto-generated>
//   This file was generated by a tool; you should avoid making direct changes.
//   Consider using 'partial classes' to extend these types
//   Input: Services.proto
// </auto-generated>

#region Designer generated code
#pragma warning disable CS0612, CS0618, CS1591, CS3021, IDE0079, IDE1006, RCS1036, RCS1057, RCS1085, RCS1192
namespace GrpcGreeter
{

    [global::ProtoBuf.ProtoContract()]
    public partial class HelloRequest : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"name")]
        public string Name { get; set; }

        internal static void Serialize(HelloRequest value, ref global::ProtoBuf.Nano.Writer writer)
        {
            if (value.Name is { Length: > 0} s)
            {
                writer.WriteVarint(10); // field 1, string
                writer.WriteWithLengthPrefix(s);
            }
        }

        internal static ulong Measure(HelloRequest value)
        {
            ulong len = 0;
            if (value.Name is { Length: > 0} s)
            {
                len += 1 + global::ProtoBuf.Nano.Writer.MeasureWithLengthPrefix(s);
            }
            return len;
        }

        internal static HelloRequest Merge(HelloRequest value, ref global::ProtoBuf.Nano.Reader reader)
        {
            ulong oldEnd;
            if (value is null) value = new();
            uint tag;
            while ((tag = reader.ReadTag()) != 0)
            {
                switch (tag)
                {
                    case 10: // field 1, string
                        value.Name = reader.ReadString();
                        break;
                    default:
                        if ((tag & 7) == 4) // end-group
                        {
                            reader.PushGroup(tag);
                            goto ExitLoop;
                        }
                        switch (tag >> 3)
                        {
                            case 1:
                                reader.UnhandledTag(tag); // throws
                                break;
                        }
                        reader.Skip(tag);
                        break;
                }
            }
        ExitLoop:
            return value;
        }

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class HelloReply : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"message")]
        public string Message { get; set; }

        internal static void Serialize(HelloReply value, ref global::ProtoBuf.Nano.Writer writer)
        {
            if (value.Message is { Length: > 0} s)
            {
                writer.WriteVarint(10); // field 1, string
                writer.WriteWithLengthPrefix(s);
            }
        }

        internal static ulong Measure(HelloReply value)
        {
            ulong len = 0;
            if (value.Message is { Length: > 0} s)
            {
                len += 1 + global::ProtoBuf.Nano.Writer.MeasureWithLengthPrefix(s);
            }
            return len;
        }

        internal static HelloReply Merge(HelloReply value, ref global::ProtoBuf.Nano.Reader reader)
        {
            ulong oldEnd;
            if (value is null) value = new();
            uint tag;
            while ((tag = reader.ReadTag()) != 0)
            {
                switch (tag)
                {
                    case 10: // field 1, string
                        value.Message = reader.ReadString();
                        break;
                    default:
                        if ((tag & 7) == 4) // end-group
                        {
                            reader.PushGroup(tag);
                            goto ExitLoop;
                        }
                        switch (tag >> 3)
                        {
                            case 1:
                                reader.UnhandledTag(tag); // throws
                                break;
                        }
                        reader.Skip(tag);
                        break;
                }
            }
        ExitLoop:
            return value;
        }

    }

    [global::System.ServiceModel.ServiceContract(Name = @"Greeter")]
    public partial interface IIGreeter
    {
        global::System.Collections.Generic.<global::GrpcGreeter.HelloReply> SayHelloAsync(global::System.Collections.Generic.<global::GrpcGreeter.HelloRequest> value, global::ProtoBuf.Grpc.CallContext context = default);

    }

}

#pragma warning restore CS0612, CS0618, CS1591, CS3021, IDE0079, IDE1006, RCS1036, RCS1057, RCS1085, RCS1192
#endregion