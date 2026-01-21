using Catalog.CORE.Entities;
using MongoDB.Driver;

namespace Catalog.Application.Sorting
{
    public interface ISortStrategy
    {
        string Key { get; }

        SortDefinition<Product> ApplySort(SortDefinitionBuilder<Product> builer);
    }
}
