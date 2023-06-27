using System;
using System.Collections.Generic;

namespace DataAxisLayer.Models
{
    public partial class UserDatum
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public string? UserRole { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? EmailId { get; set; }
        public string? Token { get; set; }
        public DateTime? Validaty { get; set; }
        public string? RefreshToken { get; set; }
        public string? GuidId { get; set; }
        public DateTime? ExpiredTime { get; set; }
    }
}
