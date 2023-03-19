using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuberDinner.Application.Services.Models;

namespace BuberDinner.Application.Services.Authentication;

public interface IAuthService
{
    AuthResult Login(string email,string password);
    AuthResult Register(string firstName,string lastName,string email,string password);
}

