namespace Catalog.Application.Queries
{
    public class GetProductByIdQuery
    {
        public string Id { get; set; }

        public GetProductByIdQuery(string id)
        {
            Id = id;
        }
    }
}
