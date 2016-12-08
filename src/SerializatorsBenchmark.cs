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
    public class SerializatorsBenchmark<T>
    {
        private T _data;
        private string _jsonSerialized;
        private string _jilSerialized;
        private MemoryStream _msgPackStream;
        private MemoryStream _protoStream;
        private MemoryStream _wireStream;

        private MixedSerializer<T> _serializer;
        private byte[] _groBufSerialized;
        private string _fastJsonSerialized;
        private string _serviceStackJsonSerialized;

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

            //Wire
            _wireStream = new MemoryStream();
            _serializer.WireSerialize(_wireStream, _data);
            _wireStream.Position = 0;
        }

        #region JsonNet

        [Benchmark]
        public void JsonNetSerialize() => _serializer.JsonNetSerialize(_data);

        [Benchmark]
        public void JsonNetDeserialize() => _serializer.JsonNetDeserialize(_jsonSerialized);

        #endregion

        #region Protobuf

        [Benchmark]
        public void ProtobufSerialize()
        {
            using (var m = new MemoryStream())
            {
                _serializer.ProtoSerialize(m, _data);
            }
        }

        [Benchmark]
        public T ProtobufDeserialize()
        {
            _protoStream.Position = 0;
            return _serializer.ProtoDeserialize(_protoStream);
        }

        #endregion

        #region MiniMsgPack

        [Benchmark]
        public void MsgPackCliSerialize()
        {
            using (var m = new MemoryStream())
            {
                _serializer.Pack(m, _data);
            }
        }

        [Benchmark]
        public T MsgPackCliDeserialize()
        {
            _msgPackStream.Position = 0;
            return _serializer.Unpack(_msgPackStream);
        }

        #endregion

        #region Jil

        [Benchmark]
        public string JilSerialize()
        {
            return _serializer.JilSerialize(_data);
        }

        [Benchmark]
        public T JilDeserialize()
        {
            return _serializer.JilDeserialize(_jilSerialized);
        }

        #endregion

        #region GroBuf

        [Benchmark(Baseline = true)]
        public byte[] GroBufSerialize()
        {
            return _serializer.GroBufSerialize(_data);
        }

        [Benchmark]
        public T GroBufDeserialize()
        {
            return _serializer.GroBufDeserialize(_groBufSerialized);
        }

        #endregion

        #region FastJson

        [Benchmark]
        public string FastJsonSerialize()
        {
            return _serializer.FastJsonSerialize(_data);
        }

        [Benchmark]
        public T FastJsonDeserialize()
        {
            return _serializer.FastJsonDeserialize(_fastJsonSerialized);
        }

        #endregion

        #region ServiceStackJson

        [Benchmark]
        public string ServiceStackJsonSerialize()
        {
            return _serializer.ServiceStackJsonSerializer(_data);
        }

        [Benchmark]
        public T ServiceStackJsonDeserialize()
        {
            return _serializer.ServiceStackJsonDeserializer(_serviceStackJsonSerialized);
        }

        #endregion

        #region Wire

        [Benchmark]
        public string WireSerialize()
        {
            return _serializer.ServiceStackJsonSerializer(_data);
        }

        [Benchmark]
        public T WireDeserialize()
        {
            return _serializer.ServiceStackJsonDeserializer(_serviceStackJsonSerialized);
        }

        #endregion

    }
}