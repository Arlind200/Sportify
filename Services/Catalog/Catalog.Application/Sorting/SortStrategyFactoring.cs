namespace Catalog.Application.Sorting
{
    public class SortStrategyFactoring : ISortStrategyFactory
    {
        private readonly IEnumerable<ISortStrategy> _strategies;

        public SortStrategyFactoring(IEnumerable<ISortStrategy> strategies)
        {
            _strategies = strategies;
        }
        public ISortStrategy GetStrategy(string sortOption)
        {
            if (string.IsNullOrEmpty(sortOption))
            {
                sortOption = "name";
            }
            var strategy = _strategies.FirstOrDefault(s =>
            s.Key.Equals(sortOption, StringComparison.OrdinalIgnoreCase));

            return strategy ?? _strategies.First(s => s.Key == "name");
        }
    }
}
