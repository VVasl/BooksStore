using AutoMapper;
using BooksStore.Data.Entities;
using BooksStore.Models;

namespace BooksStore.Data
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
