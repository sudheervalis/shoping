using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QoneModel
{
    public  class MRefreshTokenRequest
    {
        public int UserId { get; set; }
        public string? RefreshToken { get; set; }
    }
}
