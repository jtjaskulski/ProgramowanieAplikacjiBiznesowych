using Mapster;
using SolutionOrders.Api.Features.Messages.Commands;
using SolutionOrders.Api.Features.Messages.DTOs;
using SolutionOrders.Data.Models;

namespace SolutionOrders.Api.Features.Mappings;

public class CategoryMappingConfig: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Category, CategoryDto>();
    }
}