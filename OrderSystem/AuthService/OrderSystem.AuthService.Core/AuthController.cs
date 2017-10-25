using DTOs;
using OrderSystem.AuthService.DAL;
using OrderSystem.AuthService.Entities;
using System;

namespace OrderSystem.AuthService.Core
{
    public class AuthController : IAuthController
    {
        private readonly IUserAccess _userAccess;

        public AuthController(IUserAccess userAccess)
        {
            _userAccess = userAccess;
        }

        public AuthResponse Authenticate(PersonAuth authObj)
        {
            var user = _userAccess.GetUserWithId(authObj.Id);

            if (user.Username != authObj.Username)
                return new AuthResponse().WithFailErrorMessage("Username does not match.");

            if(user.Password != authObj.Password)
                return new AuthResponse().WithFailErrorMessage("Password does not match.");

            return new AuthResponse().WithSuccess();
        }

        public Order Serialize(string message)
        {
            return Serializer.XmlDeserializeFromString<Order>(message);
        }
    }
}
