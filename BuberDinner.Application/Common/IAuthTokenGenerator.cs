using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Common
{
    public interface IAuthTokenGenerator
    {
        string GenerateToken(User user);
    }
}