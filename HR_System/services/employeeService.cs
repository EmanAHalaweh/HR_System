using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_System.Data;

namespace HR_System.services
{
    public class employeeService:IEmployeeService
    {
        HRContext context;
        public employeeService(HRContext _context)
        {
            context = _context;
        }
       
      

        public List<Employee> loadAll()
        {
            List<Employee> li= context.employees.ToList();
            return (li);
        }

        public List<Employee> loadAll(string name)
        {
            List<Employee> li= context.employees.Where(n=>n.Fname==name).ToList();
            return (li);
        }

        public void insert(Employee emp)
        {
            context.employees.Add(emp);
            context.SaveChanges();
        }

        public void delete(int id)
        {
            Employee employee = context.employees.Find(id);
            context.employees.Remove(employee);
            context.SaveChanges();
        }



        public Employee load(int id)
        {
             
            return (context.employees.Find(id));
        }


             public void Update(Employee emp)
        {
            context.employees.Attach(emp);
            context.Entry(emp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public List<Employee> Ldept(int dept_id)
        {
            List<Employee> li = (from p in context.employees
                                  where p.depId == dept_id
                                  select p).ToList();
            return li;
        }

    }
}
