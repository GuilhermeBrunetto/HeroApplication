using System;

namespace API.Entities
{
    public class Hero
    {
        public int Id { get; set; }
        public string HeroName { get; set; }

        // In order to add these new properties to the columns must add new migration
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}