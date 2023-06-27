using System;
using System.Collections.Generic;

namespace DataAxisLayer.Models
{
    public partial class Muser
    {
        public Muser()
        {
            MrefreshTokens = new HashSet<MrefreshToken>();
            Mtasks = new HashSet<Mtask>();
        }

        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PasswordSalt { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime Ts { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<MrefreshToken> MrefreshTokens { get; set; }
        public virtual ICollection<Mtask> Mtasks { get; set; }
    }
}
