using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Catalog.API.Dtos
{
    public class ProductDto
    {
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; }

        [BsonElement("Summary")]
        public string Summary { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("ImageFile")]
        public string ImageFile { get; set; }

        [BsonElement("Price")]
        public decimal Price { get; set; }
    }
}
