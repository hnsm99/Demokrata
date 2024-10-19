using TestJelmi.Data;
using TestJelmi.Models;
using TestJelmi.Repositories.Interfaces;

namespace TestJelmi.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext _context;

        public UserRepository(DataBaseContext context)
        {
            _context = context;
        }

        public UserModel Add(UserModel user)
        {
            //user.Id = _users.Count + 1;
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public UserModel Update(UserModel user)
        {
            var existingUser = GetById(user.Id);
            existingUser.PrimerNombre = user.PrimerNombre;
            existingUser.PrimerApellido = user.PrimerApellido;
            existingUser.SegundoNombre = user.SegundoNombre;
            existingUser.SegundoApellido = user.SegundoApellido;
            existingUser.FechaNacimiento = user.FechaNacimiento;
            existingUser.Sueldo = user.Sueldo;
            existingUser.FechaModificacion = user.FechaModificacion;
            _context.Users.Update(existingUser);
            _context.SaveChanges();
            return _context.Users.FirstOrDefault(u => u.Id == user.Id);
        }

        public bool Delete(UserModel user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }

        public UserModel? GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<UserModel> Search(string firstName, string lastName, int page, int pageSize)
        {
            var query = _context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(firstName))
            {
                query = query.Where(u => u.PrimerNombre.Contains(firstName));
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                query = query.Where(u => u.PrimerApellido.Contains(lastName));
            }
            return query.ToList().Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<UserModel> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}
