using System;
using System.Threading.Tasks;
using Android.Gms.Extensions;
using AppFirebaseAuth.Droid;
using Firebase.Auth;
using Naloga;
using Xamarin.Forms;
[assembly: Dependency(typeof(AuthDroid))]
namespace AppFirebaseAuth.Droid
{
    public class AuthDroid : IAuth
    {
        public async Task<string> LoginWithEmailPassword(string email, string password) {
            try {
                var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var token = await (user.User.GetIdToken(false).AsAsync<GetTokenResult>());
                return token.Token;
            }
            catch (FirebaseAuthInvalidUserException e) {
                //e.PrintStackTrace();
                return "";
            }
        }
        public async Task<bool> SignUpWithEmailPassword(string email, string password) {
            try {
                var signUpTask = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                return signUpTask != null;
            }
            catch (Exception e) {
                return false;
            }
        }
    }
}