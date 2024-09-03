using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_03_09_additionalTask_1
{
    internal class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public DateOnly DeadLine {  get; set; }



        public List<Employees> Employees { get; set; } = new List<Employees>();
    }
}
