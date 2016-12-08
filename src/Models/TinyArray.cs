using ProtoBuf;

namespace Serializers.Models
{
    [ProtoContract]
    public class TinyArray
    {
        [ProtoMember(1)]
        public int[] TestArray { get; set; }
    }
}