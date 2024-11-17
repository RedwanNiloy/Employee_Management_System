using EmployeeManagement.Entities;

namespace EmployeeManagement.Interfaces
{
    public interface IDepartmentRepository
    {

        public Task<IEnumerable<Department>> GetAllDepartment();
        //public Task<Department> GetDepartemtById(int id);
        public Task AddDepartment(Department dept);
        //void UpdateEmployee(EmployeeEntity employee);
        public Task DeleteDepartment(int id);


    }
}
