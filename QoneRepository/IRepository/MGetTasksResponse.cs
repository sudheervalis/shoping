using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAxisLayer.Models;

namespace QoneRepository.IRepository
{
   
    public class MGetTasksResponse : BaseResponse
    {
        public List<Mtask> Tasks { get; set; }
    }
}
