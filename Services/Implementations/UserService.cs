using Microsoft.EntityFrameworkCore;
using Models.Db;
using Models.Models;
using Models.Requests;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _dbContext;
        public UserService(DatabaseContext db)
        {
            _dbContext = db;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users =  await _dbContext.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetUserById(Guid id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async Task<User> AddUser(CreateOrUpdateUserRequest user)
        {
            User model = new User()
            {
                Id = Guid.NewGuid(),
                Name = user.Name,
                LastName = user.LastName,
                Age = user.Age
            };
            await _dbContext.AddAsync(model);
            int result = await _dbContext.SaveChangesAsync();
            if(result != -1)
            {
                return model;
            }
            else
            {
                return null;
            }
        }

        public async Task<User> UpdateUser(Guid id, CreateOrUpdateUserRequest user)
        {
            var model = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (model != null)
            {
                model.Name = user.Name;
                model.LastName = user.LastName;
                model.Age = user.Age;
                int result = await _dbContext.SaveChangesAsync();
                if (result != -1)
                {
                    return model;
                }
            }
            return null;
        }
    }
}
