using Mapster;
using SolutionOrders.Api.Features.Categories.Messages.DTOs;
using SolutionOrders.Data.Models;

namespace SolutionOrders.Api.Features.Categories.Mappings;

public class CategoryMappingConfig: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Category, CategoryDto>();
    }
}