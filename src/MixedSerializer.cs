using System.IO;
using System.Runtime.CompilerServices;
using GroBuf;
using GroBuf.DataMembersExtracters;
using Jil;
using MBrace.FsPickler;
using MBrace.FsPickler.Combinators;
using Microsoft.FSharp.Core;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MsgPack.Serialization;
using Newtonsoft.Json;
using ServiceStack;
using SerializationContext = MsgPack.Serialization.SerializationContext;
using ProtoSerializer = ProtoBuf.Serializer;

namespace Serializers
{
    public class MixedSerializer<T>
    {
        private readonly MessagePackSerializer<T> _mgsPackSerializer;
        private readonly ISerializer _groBuf;
        private readonly Wire.Serializer _wireSerializer;
        private BinarySerializer _fsPicklerBinary;

        public MixedSerializer()
        {
            _mgsPackSerializer = SerializationContext.Default.GetSerializer<T>();
            _groBuf = new GroBuf.Serializer(new PropertiesExtractor(), options: GroBufOptions.WriteEmptyObjects);
            _wireSerializer = new Wire.Serializer();
            _fsPicklerBinary = FsPickler.CreateBinarySerializer();
        }

        /// <summary>
        /// https://github.com/msgpack/msgpack-cli
        /// </summary>
        /// <param name="s"></param>
        /// <param name="o"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Pack(Stream s, T o)
        {
            _mgsPackSerializer.Pack(s, o);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Unpack(Stream input)
        {
            return _mgsPackSerializer.Unpack(input);
        }

        /// <summary>
        /// https://github.com/mgravell/protobuf-net
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ProtoSerialize(Stream s, T data)
        {
            ProtoSerializer.Serialize(s, data);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T ProtoDeserialize(Stream s)
        {
            return ProtoSerializer.Deserialize<T>(s);
        }

        /// <summary>
        /// https://github.com/JamesNK/Newtonsoft.Json
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string JsonNetSerialize(T data)
        {
            return JsonConvert.SerializeObject(data);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T JsonNetDeserialize(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }

        /// <summary>
        /// https://github.com/kevin-montrose/Jil
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string JilSerialize(T data)
        {
            return JSON.Serialize(data);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T JilDeserialize(string input)
        {
            return JSON.Deserialize<T>(input);
        }

        /// <summary>
        /// https://github.com/homuroll/GroBuf
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte[] GroBufSerialize(T data)
        {
            return _groBuf.Serialize(data);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T GroBufDeserialize(byte[] input)
        {
            return _groBuf.Deserialize<T>(input);
        }

        /// <summary>
        /// https://github.com/mgholam/fastJSON
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string FastJsonSerialize(T data)
        {
            return fastJSON.JSON.ToJSON(data);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T FastJsonDeserialize(string input)
        {
            return fastJSON.JSON.ToObject<T>(input);
        }

        /// <summary>
        /// https://github.com/ServiceStack/ServiceStack.Text
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ServiceStackJsonSerializer(T data)
        {
            return data.ToJson();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T ServiceStackJsonDeserializer(string input)
        {
            return input.FromJson<T>();
        }

        /// <summary>
        /// https://github.com/rogeralsing/Wire
        /// </summary>
        /// <param name="s">Stream</param>
        /// <param name="data">Input data</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WireSerialize(Stream s, T data)
        {
            _wireSerializer.Serialize(data, s);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T WireDeserialize(Stream input)
        {
            return _wireSerializer.Deserialize<T>(input);
        }

        /// <summary>
        /// https://github.com/mbraceproject/FsPickler
        /// </summary>
        /// <param name="s">Stream</param>
        /// <param name="data">Input data</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void FsPicklerBinarySerialize(Stream s, T data)
        {
            _fsPicklerBinary.Serialize(s, data);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T FsPicklerBinaryDeserialize(byte[] input)
        {
            var m = new MemoryStream(input);
            return _fsPicklerBinary.Deserialize<T>(m);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte[] BsonSerialize(T data)
        {
            return data.ToBson();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T BsonDeserialize(byte[] input)
        {
            return BsonSerializer.Deserialize<T>(input);
        }
    }
}
