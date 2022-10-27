using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_System.Data;

namespace HR_System.services
{
    public interface IDepartmentService
    {
        public List<Department> loadAll();
        public List<Department> loadAll(string name);
        public void insert(Department d);
        public void delete(int id);
        public Department load(int id);
        public void Update(Department dept);
        //public List<Employee> loademp(int id);

    }
}
