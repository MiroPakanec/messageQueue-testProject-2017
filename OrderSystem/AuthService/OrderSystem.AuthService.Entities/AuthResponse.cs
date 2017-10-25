using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSystem.AuthService.Entities
{
    public class AuthResponse
    {
        public AuthResponse() { }

        public AuthResponse(bool success, string errorMessage)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }

        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
