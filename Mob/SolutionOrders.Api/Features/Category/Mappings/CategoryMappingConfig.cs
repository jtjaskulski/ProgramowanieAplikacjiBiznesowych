using Mapster;
using SolutionOrders.Api.Features.Category.Messages.DTOs;

namespace SolutionOrders.Api.Features.Category.Mappings;

public class CategoryMappingConfig: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Data.Models.Category, CategoryDto>();
    }
}