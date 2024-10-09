using TestRestWebApi.Models;

namespace TestRestWebApi.Contacts
{
    public interface IUserService
    {
        public User GetUser(string id);
        public bool SaveUser(User user);
    }
}