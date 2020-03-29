
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace App.DAL.Entities
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        [BsonElement("_id")]
        public int Id { get; set; }

        [BsonElement("FirstName")]
        public string FirstName { get; set; }

        [BsonElement("LastName")]
        public string LastName { get; set; }

        [BsonElement("About")]
        public string About { get; set; }

        [BsonElement("EnrollmentDate")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime EnrollmentDate { get; set; }
    }
}