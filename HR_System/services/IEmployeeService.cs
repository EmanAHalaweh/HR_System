using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_System.Data;

namespace HR_System.services
{
   public interface IEmployeeService
    {
        public List<Employee> loadAll();
        public List<Employee> loadAll(string name);
        public void insert(Employee emp);
        public void delete(int id);
        public Employee load(int id);
        public void Update(Employee emp);
        public List<Employee> Ldept(int dept_id);

    }
}
