using Catalog.CORE.Entities;
using MongoDB.Driver;

namespace Catalog.Application.Sorting
{
    public class NameSortStrategy : ISortStrategy
    {
        public string Key => "name";

        public SortDefinition<Product> ApplySort(SortDefinitionBuilder<Product> builer)
        {
            return builer.Ascending(p => p.Name);
        }
    }
}
