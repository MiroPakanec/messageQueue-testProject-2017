using System;

namespace DTOs
{
    [Serializable]
    public class PersonAuth
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}