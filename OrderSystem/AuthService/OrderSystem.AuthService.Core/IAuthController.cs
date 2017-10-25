using DTOs;
using OrderSystem.AuthService.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSystem.AuthService.Core
{
    public interface IAuthController
    {
        Order Serialize(string message);
        AuthResponse Authenticate(PersonAuth authObj);
    }
}
