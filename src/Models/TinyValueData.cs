using System;
using ProtoBuf;

namespace Serializers.Models
{
    [Serializable]
    [ProtoContract]
    public class TinyValueData
    {
        [ProtoMember(1)]
        public byte B { get; set; }

        [ProtoMember(2)]
        public long L { get; set; }

        [ProtoMember(3)]
        public int I { get; set; }

        [ProtoMember(4)]
        public float C { get; set; }
    }
}