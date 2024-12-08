using AutoMapper;
using ProyectoIntegradorClinica.DataAccess.Entities;
using ProyectoIntegradorClinica.Models;

namespace ProyectoIntegradorClinica.Profiles
{
    public class UsuarioProfile: Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioEntity, UsuarioViewModel>()
            .ForMember(dest => dest.IdUsuario, opt => opt.MapFrom(src => src.IdUsuario))
            .ReverseMap();
        }
    }
}
