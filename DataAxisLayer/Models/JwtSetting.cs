using System;
using System.Collections.Generic;

namespace DataAxisLayer.Models
{
    public partial class JwtSetting
    {
        public int Id { get; set; }
        public string? ValidateIssuerSigningKey { get; set; }
        public string? IssuerSigningKey { get; set; }
        public string? ValidateIssuer { get; set; }
        public string? ValidIssuer { get; set; }
        public string? ValidateAudience { get; set; }
        public string? ValidAudience { get; set; }
        public string? RequireExpirationTime { get; set; }
        public string? ValidateLifetime { get; set; }
    }
}
