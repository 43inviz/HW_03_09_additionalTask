using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_03_09_additionalTask_1
{
    internal class DbManager
    {

        public void EnsurePopulate()
        {
            using (ApplicationContext db = new ApplicationContext()) 
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();


                var companies = new List<Company>
                {
                    new Company { Name = "TechCorp", Address = "123 Tech Street" },
                    new Company { Name = "Innovatech", Address = "456 Innovation Avenue" },
                    new Company { Name = "SoftSolutions", Address = "789 Software Blvd" }
                };


                var employees = new List<Employees>
                {
                    new Employees { FullName = "Alex Johnson", EmploymentDate = new DateTime(2022, 3, 10), CompanyId = companies[0].Id },
                    new Employees { FullName = "Maria Smith", EmploymentDate = new DateTime(2023, 1, 15), CompanyId = companies[1].Id },
                    new Employees { FullName = "John Doe", EmploymentDate = new DateTime(2023, 7, 22), CompanyId = companies[2].Id }
                };


                var projects = new List<Project>
                {
                    new Project { Title = "AI Development", DeadLine = new DateOnly(2024, 5, 30) },
                    new Project { Title = "Website Redesign", DeadLine = new DateOnly(2024, 11, 15) },
                    new Project { Title = "Mobile App Launch", DeadLine = new DateOnly(2024, 9, 10) }
                };




                var employee1 = db.Employees.FirstOrDefault(e => e.Id == 1);
                var employee2 = db.Employees.FirstOrDefault(e => e.Id == 2);
                var employee3 = db.Employees.FirstOrDefault(e => e.Id == 3);

                var project1 = db.Projects.FirstOrDefault(p => p.Id == 1);
                var project2 = db.Projects.FirstOrDefault(p => p.Id == 2);
                var project3 = db.Projects.FirstOrDefault(p => p.Id == 3);

                employee1.Projects.Add(project1);
                employee1.Projects.Add(project2);



                db.Companies.AddRange(companies);
                db.Employees.AddRange(employees);
                db.Projects.AddRange(projects);

                db.SaveChanges();
            }
        }

        public List<Project> GetProjectInfoByCompany(string companyName)
        {
            using (ApplicationContext db = new ApplicationContext())
            {

                return db.Projects.Include(p => p.Employees)
                    .ThenInclude(e => e.Company)
                    .Where(p => p.Employees.Any(e => e.Company.Name == companyName))
                    .ToList();

            }
        }
    }
}
