using Mapster;
using SolutionOrders.Api.Features.Items.Messages.Commands;
using SolutionOrders.Api.Features.Items.Messages.DTOs;

namespace SolutionOrders.Api.Features.Items.Mappings
{
    public class ItemMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Data.Models.Item, ItemDto>()
                .Map(dest => dest.CategoryName, src => src.Category.Name)
                .Map(dest => dest.UnitName, src => src.UnitOfMeasurement != null
                    ? src.UnitOfMeasurement.Name : null);

            config.NewConfig<CreateItemCommand, Data.Models.Item>()
                .Map(dest => dest.IsActive, _ => true)
                .Ignore(dest => dest.IdItem)
                .Ignore(dest => dest.Category)
                .Ignore(dest => dest.UnitOfMeasurement!)
                .Ignore(dest => dest.OrderItems);

            config.NewConfig<UpdateItemCommand, Data.Models.Item>()
                .Ignore(dest => dest.IdItem)
                .Ignore(dest => dest.Category)
                .Ignore(dest => dest.UnitOfMeasurement!)
                .Ignore(dest => dest.OrderItems);
        }
    }
}
