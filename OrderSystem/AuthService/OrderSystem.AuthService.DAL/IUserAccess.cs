using OrderSystem.AuthService.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSystem.AuthService.DAL
{
    public interface IUserAccess
    {
        User GetUserWithId(int id);
    }
}
