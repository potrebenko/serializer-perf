using System;
using ProtoBuf;

namespace Serializers.Models
{
    [Serializable]
    [ProtoContract]
    public class Transaction
    {
        [ProtoMember(1)]
        public string Id { get; set; }

        [ProtoMember(2)]
        public long Time { get; set; }
    }
}