using System.Threading.Tasks;
namespace Naloga
{
    public interface IAuth
    {
        Task<string> LoginWithEmailPassword(string email, string password);
        Task<bool> SignUpWithEmailPassword(string email, string password);
    }
}