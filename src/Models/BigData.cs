using System.Collections.Generic;
using ProtoBuf;

namespace Serializers.Models
{
    [ProtoContract]
    public class BigData
    {
        [ProtoMember(1)]
        public string Name { get; set; }

        [ProtoMember(2)]
        public int Age { get; set; }

        [ProtoMember(3)]
        public bool Gender { get; set; }

        [ProtoMember(4)]
        public double Price { get; set; }

        [ProtoMember(5)]
        public List<Transactions> Transactions { get; set; }

        [ProtoMember(6)]
        public Dictionary<int, Transactions> Dict { get; set; }
    }
}
