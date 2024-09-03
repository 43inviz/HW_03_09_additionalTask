using Microsoft.EntityFrameworkCore;

namespace HW_03_09_additionalTask_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DbManager dbManager = new DbManager();

            dbManager.EnsurePopulate();

            var result = dbManager.GetProjectInfoByCompany("TechCorp");

            foreach (var item in result) { Console.WriteLine(item.Title); }
        }

    }
}
