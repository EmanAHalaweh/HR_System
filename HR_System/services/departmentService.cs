using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_System.Data;

namespace HR_System.services
{
    public class departmentService:IDepartmentService
    {
        HRContext context;
        public departmentService(HRContext _context)
        {
            context = _context;
        }
        

        public List<Department> loadAll()
        {
            List<Department> li= context.depts.ToList();

            return (li);

        }
        public List<Department> loadAll(string name)
        {
            List<Department> li = context.depts.Where(n=>n.name==name).ToList();
            return (li);
        }

        public void insert(Department d)
        {
            context.depts.Add(d);
            context.SaveChanges();
        }

        public void delete(int id)
        {
            Department dept = context.depts.Find(id);
            context.depts.Remove(dept);
            context.SaveChanges();
        }

        public Department load(int id)
        {

            return (context.depts.Find(id));
        }

        public void Update(Department dept)
        {
            context.depts.Attach(dept);
            context.Entry(dept).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }


        public List<Employee> loademp(int id)
        {
            List<Employee> li = context.employees.Where(c => c.depId == id).ToList();
            return (li);
        }

    }
}
