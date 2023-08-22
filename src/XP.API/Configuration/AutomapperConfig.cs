using AutoMapper;
using XP.API.DTO;
using XP.Business.Models;

namespace XP.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Email, EmailDTO>().ReverseMap();
            CreateMap<Endereco, EnderecoDTO>().ReverseMap();
        }
    }
}
