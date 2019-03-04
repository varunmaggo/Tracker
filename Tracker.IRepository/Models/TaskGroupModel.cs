using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.IRepository.Models
{
    public class TaskGroupModel
    {
        public int Id_TaskGroupModel { get; set; }
        public string GroupName { get; set; }
    }

    public class TaskGroupFilter
    {
        public string Name { get; set; }
    }
}
