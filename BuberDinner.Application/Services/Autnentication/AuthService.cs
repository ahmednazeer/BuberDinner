using BuberDinner.Application.Common;
using BuberDinner.Application.Services.Models;
using BuberDinner.Application.Services.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;
public class AuthService : IAuthService
{
    private readonly IAuthTokenGenerator _authTokenGenerator;
    private readonly IUserService _userService;
    public AuthService(IAuthTokenGenerator authTokenGenerator, IUserService userService)
    {
        _userService = userService;
        _authTokenGenerator = authTokenGenerator;
    }
    public AuthResult Login(string email, string password)
    {
        //check if user exist with email 
        if (_userService.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with this email already exists");
        }
        //compare password with given one 
        if (user.Password != password)
        {
            throw new Exception("Password is incorrect");
        }
        //generate token

        var token = _authTokenGenerator.GenerateToken(user);
        
        return new AuthResult(user.Id,user.FirstName,user.LastName,email,token);
    }

    public AuthResult Register(string firstName, string lastName, string email, string password)
    {
        //check if user with email exists
        
        if (_userService.GetUserByEmail(email) is User user)
        {
            throw new Exception("User with this email already exists");
        }
        //add user to db
        user=new User
        {FirstName=firstName,LastName= lastName,Email= email,Password= password,Id=Guid.NewGuid()};
         _userService.AddUser(user);
        //generate token
        
        var token = _authTokenGenerator.GenerateToken(user);
        return new AuthResult(user.Id,firstName,lastName,email,token);
    }
}