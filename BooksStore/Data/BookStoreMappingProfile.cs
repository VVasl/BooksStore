using AutoMapper;
using BooksStore.Data.Entities;
using BooksStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Data
{
    public class BooksStoreMappingProfile : Profile
    {
        public BooksStoreMappingProfile()
        {
            CreateMap<Book, BookDto>()
                .ReverseMap();

            //CreateMap<Order, OrderViewModel>()
            //    .ForMember(o => o.OrderId, ex => ex.MapFrom(o => o.Id))
            //    .ReverseMap();

            //CreateMap<OrderItem, OrderItemViewModel>()
            //    .ReverseMap();
        }
    }
}
