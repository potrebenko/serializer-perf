using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit3;
using Serializers.Models;
using Is = NUnit.DeepObjectCompare.Is;

namespace Serializers.Tests
{
    [TestFixture]
    [Author("Yevhen Potrebenko", "yevgeny.potrebenko@plarium.com")]
    public class SerializerDataTests
    {
        [Test, AutoData]
        public void JsonNet_Deserialize_ObjectEquals(MixedSerializer<BigData> serializer, BigData data)
        {
            //Arrange
            var s = serializer.JsonNetSerialize(data);

            //Act
            var result = serializer.JsonNetDeserialize(s);

            //Assert
            Assert.That(result, Is.DeepEqualTo(data));
        }

        [Test, AutoData]
        public void Protobuf_Deserialize_ObjectEquals(MixedSerializer<BigData> serializer, BigData data)
        {
            //Arrange
            var m = new MemoryStream();
            serializer.ProtoSerialize(m, data);
            m.Position = 0;

            //Act
            var result = serializer.ProtoDeserialize(m);

            //Assert
            Assert.That(result, Is.DeepEqualTo(data));
        }

        [Test, AutoData]
        public void MsgPackCli_Deserialize_ObjectEquals(MixedSerializer<BigData> serializer, BigData data)
        {
            //Arrange
            var m = new MemoryStream();
            serializer.Pack(m, data);
            m.Position = 0;

            //Act
            var result = serializer.Unpack(m);

            //Assert
            Assert.That(result, Is.DeepEqualTo(data));
        }

        [Test, AutoData]
        public void JIL_Deserialize_ObjectEquals(MixedSerializer<TinyData> serializer, TinyData data)
        {
            //Arrange
            var serialized = JSON.Serialize(data);

            //Act
            var result = serializer.JilDeserialize(serialized);

            //Assert
            Assert.That(result, Is.DeepEqualTo(data));
        }

        [Test, AutoData]
        public void GroBuf_Deserialize_ObjectEquals(MixedSerializer<BigData> serializer, BigData data)
        {
            //Arrange
            var serialized = serializer.GroBufSerialize(data);

            //Act
            var result = serializer.GroBufDeserialize(serialized);

            //Assert
            Assert.That(result, Is.DeepEqualTo(data));
        }

        [Test, AutoData]
        public void FastJson_Deserialize_ObjectEquals(MixedSerializer<TinyData> serializer, TinyData data)
        {
            //Arrange
            var serialized = serializer.FastJsonSerialize(data);

            //Act
            var result = serializer.FastJsonDeserialize(serialized);

            //Assert
            Assert.That(result, Is.DeepEqualTo(data));
        }

        [Test, AutoData]
        public void ServiceStackJson_Deserialize_ObjectEquals(MixedSerializer<TinyData> serializer, TinyData data)
        {
            //Arrange
            var serialized = serializer.ServiceStackJsonSerializer(data);

            //Act
            var result = serializer.ServiceStackJsonDeserializer(serialized);

            //Assert
            Assert.That(result, Is.DeepEqualTo(data));
        }

        [Test, AutoData]
        public void Wire_Deserialize_ObjectEquals(MixedSerializer<BigData> serializer, BigData data)
        {
            //Arrange
            var s = new MemoryStream();
            serializer.WireSerialize(s, data);
            s.Position = 0;

            //Act
            var result = serializer.WireDeserialize(s);

            //Assert
            Assert.That(result, Is.DeepEqualTo(data));
        }
    }
}
