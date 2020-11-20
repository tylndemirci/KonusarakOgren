namespace KonusarakOgren.Business.Abstract
{
    public interface IAuthBusiness
    {
        public void UserRegister(string username, string password);
        public void UserLogin(string username, string password);
        public void Logout();
    }
}