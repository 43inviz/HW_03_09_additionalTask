using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_03_09_additionalTask_1
{
    internal class Employees
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public DateTime EmploymentDate { get; set; }


        public int CompanyId { get; set; }
        public Company? Company { get; set; }


        public List<Project> Projects { get; set; } = new List<Project>();
    }
}
