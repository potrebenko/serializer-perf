
using System;
using ProtoBuf;

namespace Serializers.Models
{
    [Serializable]
    [ProtoContract]
    public class TinyData
    {
        [ProtoMember(1)]
        public string Name { get; set; }

        [ProtoMember(2)]
        public int Age { get; set; }

        [ProtoMember(3)]
        public Guid Hash { get; set; }

        [ProtoMember(4)]
        public DateTime Time { get; set; }
    }
}