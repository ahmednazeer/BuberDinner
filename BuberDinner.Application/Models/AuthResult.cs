namespace BuberDinner.Application.Services.Models;

public record AuthResult(
    Guid Id,string FirstName, string LastName, string Email, string Token
    );