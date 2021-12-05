using Application.ApiModels;
using AutoMapper;
using Domain.Commands;
using Domain.Models;

namespace Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to View Mapping
            CreateMap<Book, BookApiModel>();

            // View to Domain Mapping
            CreateMap<BookApiModel, RegisterNewBookCommand>()
                .ConstructUsing(c => new RegisterNewBookCommand(c.Name, c.Quantity));

            CreateMap<BookApiModel, UpdateBookCommand>()
                .ConstructUsing(c => new UpdateBookCommand(c.Id, c.Name, c.Quantity));
        }
    }
}
