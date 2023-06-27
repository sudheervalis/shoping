using DataAxisLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QoneRepository.IRepository
{
    public class MSaveTaskResponse : BaseResponse
    {
        public Mtask Task { get; set; }
    }
}
