using System;
using ProtoBuf;

namespace Serializers.Models
{
    [Serializable]
    [ProtoContract]
    public class TinyArray
    {
        [ProtoMember(1)]
        public int[] TestArray { get; set; }
    }
}