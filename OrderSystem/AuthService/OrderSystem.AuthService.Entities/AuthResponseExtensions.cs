using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSystem.AuthService.Entities
{
    public static class AuthResponseExtensions
    {
        public static AuthResponse WithFailErrorMessage(this AuthResponse authResponse, string message)
        {
            authResponse.Success = false;
            authResponse.ErrorMessage = $"Authantication has failed - {message}";
            return authResponse;
        }

        public static AuthResponse WithSuccess(this AuthResponse authResponse)
        {
            authResponse.Success = true;
            authResponse.ErrorMessage = $"Authantication successful.";
            return authResponse;
        }
    }
}
