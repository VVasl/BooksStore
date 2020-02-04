using AutoMapper;
using BooksStore.Core.Entities;
using BooksStore.ViewModels;

namespace BooksStore.Mapping
{
    public class BooksStoreMappingProfile : Profile
    {
        public BooksStoreMappingProfile()
        {
            CreateMap<Book, BookDto>()
                .ReverseMap();

            CreateMap<Order, OrderDto>()
                .ForMember(o => o.OrderId, ex => ex.MapFrom(o => o.Id))
                .ReverseMap();

            CreateMap<OrderItem, OrderItemsDto>()
                .ReverseMap();
        }
    }
}
