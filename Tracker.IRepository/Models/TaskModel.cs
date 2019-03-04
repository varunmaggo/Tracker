using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.IRepository.Models
{
    public class TaskModel
    {
        public int Id_Task { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Project_Id { get; set; }
        public int? TaskGroup_Id { get; set; }

    }
}
