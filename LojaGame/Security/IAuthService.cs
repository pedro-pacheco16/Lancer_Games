using LojaGame.Model;

namespace LojaGame.Security
{
    public interface IAuthService
    {
            Task<UserLogin?> Autenticar(UserLogin userLogin);
        
    }
}
