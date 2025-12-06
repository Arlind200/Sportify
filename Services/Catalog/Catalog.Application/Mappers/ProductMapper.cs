using AutoMapper;

namespace Catalog.Application.Mappers
{
    public class ProductMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<ProductMappingProfile>();

            });
            var mapepr = config.CreateMapper();
            return mapepr;
        });

        public static IMapper Mapper => Lazy.Value;
    }
}
