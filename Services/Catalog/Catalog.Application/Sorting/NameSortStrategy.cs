using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Application.Sorting
{
    public class NameSortStrategy : ISortStrategy
    {
        public string Key => "name";


        SortDefinition<Product> ISortStrategy.ApplySort(SortDefinitionBuilder<Product> builder)
        {
            return builder.Ascending(p => p.Name);
        }
    }
}
