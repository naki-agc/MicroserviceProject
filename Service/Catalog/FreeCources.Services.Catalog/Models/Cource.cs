using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FreeCources.Services.Catalog.Models
{
    public class Cource
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public string Price { get; set; }

        public string UserId{ get; set; }
        public string Picture { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedTime { get; set; }

        public Feature  Feature{ get; set; }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId{ get; set; }

        [BsonIgnore] // mongoDbde bir karşılığı yok bunu insertlerken göz ardı et demek ıgnore
        public Category Category { get; set; }
    }
}
