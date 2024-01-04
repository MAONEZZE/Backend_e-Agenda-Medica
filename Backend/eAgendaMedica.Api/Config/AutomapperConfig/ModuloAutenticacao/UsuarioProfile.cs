using eAgendaMedica.Api.ViewModels.ModuloAutenticacao;
using eAgendaMedica.Dominio.ModuloAutenticacao;

namespace eAgendaMedica.Api.Config.AutomapperConfig.ModuloAutenticacao
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<RegistrarUsuarioViewModel, Usuario>()
                .ForMember(usuario => usuario.UserName, opt => opt.MapFrom(usuarioVM => usuarioVM.Login));
                //.ForMember(usuario => usuario.PasswordHash, opt => opt.MapFrom(usuarioVM => usuarioVM.Senha))
        }
    }
}
