using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.CORE.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public string ImageFile { get; set; }
    public ProductBrand Brand { get; set; }
    public ProductType MyProperty { get; set; }

    [BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)]
    public decimal Price { get; set; }
    public object Type { get; set; }
}

