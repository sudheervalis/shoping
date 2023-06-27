using System;
using System.Collections.Generic;

namespace DataAxisLayer.Models
{
    public partial class Mtask
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public bool IsCompleted { get; set; }
        public DateTime Ts { get; set; }

        public virtual Muser User { get; set; } = null!;
    }
}
