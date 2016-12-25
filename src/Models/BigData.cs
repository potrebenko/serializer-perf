using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using ProtoBuf;

namespace Serializers.Models
{
    [Serializable]
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
        public List<Transaction> Transactions { get; set; }

        [ProtoMember(6)]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<int, Transaction> Dict { get; set; }
    }
}
