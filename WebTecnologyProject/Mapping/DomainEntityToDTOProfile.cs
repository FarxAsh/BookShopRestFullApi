using AutoMapper;
using WebTechnologyProjectCore.Entities;
using WebTecnologyProjectApi.ViewModels;

namespace WebTecnologyProjectApi.Mapping
{
    public class DomainEntityToDTOProfile: Profile
    {
        public DomainEntityToDTOProfile()
        {
            CreateMap<Book, BookViewModel>()
                .ForMember(dest => dest.AuthorsName, opt => opt.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}"));


            CreateMap<Author, AuthorViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<OrderViewModel, Order>();
        }
    }
}
