﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CustomerAPI.Models
{ 
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("username")]
        public string username { get; set; }

        [BsonElement("password")]
        public string password { get; set; }

        [BsonElement("balance")]
        public int balance { get; set; }

        [BsonElement("credit_limit")]
        public int credit_limit { get; set; }
    }
}