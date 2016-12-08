using GroBuf.DataMembersExtracters;
using Jil;
using Newtonsoft.Json;
using ProtoBuf;

namespace Serializers.Models
{
    [ProtoContract]
    [JsonObject]
    public class TinyAttributeData
    {
        [GroboMember("n")]
        [JsonProperty("n")]
        [JilDirective(Name = "n")]
        [ProtoMember(1)]
        public string Name { get; set; }

        [GroboMember("a")]
        [JsonProperty("a")]
        [JilDirective(Name = "a")]
        [ProtoMember(2)]
        public int Age { get; set; }
    }
}
