using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Persistence;

public interface IUserService
{
    User? GetUserByEmail(string email);
    void AddUser(User user);
}
