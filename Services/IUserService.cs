using Backend.Api.Models;
using System.Collections.Generic;

namespace Backend.Api.Services
{
    public interface IUserService
    {
        public Response Get();
        public Response Get(int id);
        public bool Delete(int id);
        public Response Update(User user);
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        List<User> GetAll();
        User GetById(int id);
    }
}
