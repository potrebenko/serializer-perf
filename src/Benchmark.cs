using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Order;
using Ploeh.AutoFixture;

namespace Serializers
{
    [RankColumn]
    [OrderProvider(SummaryOrderPolicy.FastestToSlowest)]
    [Config(typeof(TestConfig))]
    public class Benchmark<T>
    {
        private static T _data;

        private static string _jsonSerialized;
        private static string _jilSerialized;
        private static MemoryStream _msgPackStream;
        private static MemoryStream _protoStream;
        private static MemoryStream _wireStream;
        private static byte[] _groBufSerialized;
        private static string _fastJsonSerialized;
        private static string _serviceStackJsonSerialized;
        private static byte[] _fsPicklerSerialized;
        private static byte[] _bsonSerialized;
        private byte[] _messageSharkSerialized;

        private static MixedSerializer<T> _serializer;

        [Setup]
        public void Init()
        {
            _serializer = new MixedSerializer<T>();
            var fixture = new Fixture();
            fixture.RepeatCount = 10;
            _data = fixture.Create<T>();

            // Json
            _jsonSerialized = _serializer.JsonNetSerialize(_data);

            // Protobuf
            _protoStream = new MemoryStream();
            _serializer.ProtoSerialize(_protoStream, _data);
            _protoStream.Position = 0;

            // MsgPack
            _msgPackStream = new MemoryStream();
            _serializer.Pack(_msgPackStream, _data);
            _msgPackStream.Position = 0;

            // Jil
            _jilSerialized = _serializer.JilSerialize(_data);

            // GroBuf
            _groBufSerialized = _serializer.GroBufSerialize(_data);

            // FastJson
            _fastJsonSerialized = _serializer.FastJsonSerialize(_data);

            // ServiceStack
            _serviceStackJsonSerialized = _serializer.ServiceStackJsonSerializer(_data);

            // Wire
            _wireStream = new MemoryStream();
            _serializer.WireSerialize(_wireStream, _data);
            _wireStream.Position = 0;

            // FsPickler
            using (var m = new MemoryStream())
            {
                _serializer.FsPicklerBinarySerialize(m, _data);
                _fsPicklerSerialized = m.ToArray();
            }

            // Bson
            _bsonSerialized = _serializer.BsonSerialize(_data);

            // Message shark
            _messageSharkSerialized = _serializer.MessageSharkSerialize(_data);
        }

        #region JsonNet

        [Benchmark(Description = "Json .NET [S]")]
        public void JsonNetSerialize() => _serializer.JsonNetSerialize(_data);

        [Benchmark(Description = "Json .NET [D]")]
        public void JsonNetDeserialize() => _serializer.JsonNetDeserialize(_jsonSerialized);

        #endregion

        #region Protobuf

        [Benchmark(Description = "Protobuf [S]")]
        public void ProtobufSerialize()
        {
            using (var m = new MemoryStream())
            {
                _serializer.ProtoSerialize(m, _data);
            }
        }

        [Benchmark(Description = "Protobuf [D]")]
        public T ProtobufDeserialize()
        {
            _protoStream.Position = 0;
            return _serializer.ProtoDeserialize(_protoStream);
        }

        #endregion

        #region MiniMsgPack

        [Benchmark(Description = "MsgPack [S]")]
        public void MsgPackCliSerialize()
        {
            using (var m = new MemoryStream())
            {
                _serializer.Pack(m, _data);
            }
        }

        [Benchmark(Description = "MsgPack [D]")]
        public T MsgPackCliDeserialize()
        {
            _msgPackStream.Position = 0;
            return _serializer.Unpack(_msgPackStream);
        }

        #endregion

        #region Jil

        [Benchmark(Description = "Jil [S]")]
        public string JilSerialize()
        {
            return _serializer.JilSerialize(_data);
        }

        [Benchmark(Description = "Jil [D]")]
        public T JilDeserialize()
        {
            return _serializer.JilDeserialize(_jilSerialized);
        }

        #endregion

        #region GroBuf

        [Benchmark(Baseline = true, Description = "GroBuf [S]")]
        public byte[] GroBufSerialize()
        {
            return _serializer.GroBufSerialize(_data);
        }

        [Benchmark(Description = "GroBuf [D]")]
        public T GroBufDeserialize()
        {
            return _serializer.GroBufDeserialize(_groBufSerialized);
        }

        #endregion

        #region FastJson

        [Benchmark(Description = "FastJson [S]")]
        public string FastJsonSerialize()
        {
            return _serializer.FastJsonSerialize(_data);
        }

        [Benchmark(Description = "FastJson [D]")]
        public T FastJsonDeserialize()
        {
            return _serializer.FastJsonDeserialize(_fastJsonSerialized);
        }

        #endregion

        #region ServiceStackJson

        [Benchmark(Description = "ServiceStack [S]")]
        public string ServiceStackJsonSerialize()
        {
            return _serializer.ServiceStackJsonSerializer(_data);
        }

        [Benchmark(Description = "ServiceStack [D]")]
        public T ServiceStackJsonDeserialize()
        {
            return _serializer.ServiceStackJsonDeserializer(_serviceStackJsonSerialized);
        }

        #endregion

        #region Wire

        [Benchmark(Description = "Wire [S]")]
        public string WireSerialize()
        {
            return _serializer.ServiceStackJsonSerializer(_data);
        }

        [Benchmark(Description = "Wire [D]")]
        public T WireDeserialize()
        {
            return _serializer.ServiceStackJsonDeserializer(_serviceStackJsonSerialized);
        }

        #endregion

        #region FsPickler

        [Benchmark(Description = "FsPickler [S]")]
        public void FsPicklerBinarySerialize()
        {
            using (var m = new MemoryStream())
            {
                _serializer.FsPicklerBinarySerialize(m, _data);
            }
        }

        [Benchmark(Description = "FsPickler [D]")]
        public T FsPicklerBinaryDeserialize()
        {
            return _serializer.FsPicklerBinaryDeserialize(_fsPicklerSerialized);
        }

        #endregion

        #region Bson

        [Benchmark(Description = "Bson [S]")]
        public byte[] BsonSerialize()
        {
            return _serializer.BsonSerialize(_data);
        }

        [Benchmark(Description = "Bson [D]")]
        public T BsonDeserialize()
        {
            return _serializer.BsonDeserialize(_bsonSerialized);
        }

        #endregion

        #region Message shark

        [Benchmark(Description = "Message shark [S]")]
        public byte[] MessageSharkSerialize()
        {
            return _serializer.MessageSharkSerialize(_data);
        }

        [Benchmark(Description = "Message shark [D]")]
        public T MessageSharkDeserialize()
        {
            return _serializer.MessageSharkDeserialize(_messageSharkSerialized);
        }

        #endregion
    }
}