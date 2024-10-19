using TestJelmi.Models;

namespace TestJelmi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public UserModel Add(UserModel user);
        public UserModel Update(UserModel user);
        public bool Delete(UserModel user);
        public UserModel? GetById(int id);
        public IEnumerable<UserModel> GetAll();
        public IEnumerable<UserModel> Search(string firstName, string lastName, int page, int pageSize);
    }
}
