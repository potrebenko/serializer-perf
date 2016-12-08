using System;
using ProtoBuf;

namespace Serializers.Models
{
    [ProtoContract]
    public class Transactions
    {
        [ProtoMember(1)]
        public string Id { get; set; }

        [ProtoMember(2)]
        public DateTime Time { get; set; }
    }
}