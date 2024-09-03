using AutoMapper;
using BookStore.Core.Entities;
using BookStore.Application.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;
using BookStore.Application.DTOs.Visoma3;
using BookStore.Core.Entities.Visoma3;

namespace BookStore.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<Book, BookCustomerViewsDto>()
           .ForMember(dest => dest.FinalPrice,
                      opt => opt.MapFrom(src => src.IsDiscounted ?? false ? src.DiscountedPrice : src.Price)).ReverseMap();

            // Map for mobile use
            CreateMap<Book, BookCustomerViewsMobileDto>();
            // Map for admin use
            CreateMap<Book, BookAdminDto>().ReverseMap();

            CreateMap<BookMongo, BookMongoCustomerViewsDto>()
     .ForMember(dest => dest.FinalPrice, opt => opt.MapFrom(src => src.DiscountedPrice));
            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<Ticket, TicketDto>().ReverseMap();
            CreateMap<TicketData, TicketDataDto>().ReverseMap();



            CreateMap<TicketTypeDto, TicketType>()
            .ForMember(dest => dest.Fields, opt => opt.MapFrom(src => src.Fields));

            CreateMap<FieldDto, Field>();

            CreateMap<TicketType, TicketTypeDto>()
                .ForMember(dest => dest.Fields, opt => opt.MapFrom(src => src.Fields));

            CreateMap<Field, FieldDto>();


            /*
            CreateMap<TicketType, TicketTypeDto>().ReverseMap();
           // CreateMap<TicketType, TicketTypeDto>()
           //           .ForMember(dest => dest.Fields, opt => opt.MapFrom(src => src.Fields));

            CreateMap<Field, FieldDto>().ReverseMap();
            */
            /*
            CreateMap<TicketType, TicketTypeDto>();
            CreateMap<Field, FieldDto>();

            CreateMap<TicketTypeDto, TicketType>();
            CreateMap<FieldDto, Field>();
            */

        }
    }
}
