using PrimeraPrueba.EN;

namespace PrimeraPrueba.WebAPI.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(Usuario pUsuario);
    }
}
