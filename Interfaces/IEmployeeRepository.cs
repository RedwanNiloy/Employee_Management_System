using EmployeeManagement.Entities;
namespace EmployeeManagement.Interfaces
{
    public interface IEmployeeRepository
    {
       public Task<IEnumerable<EmployeeEntity>> GetAllEmployees();
      public  Task<EmployeeEntity> GetEmployeeById(int id);
      public Task<int>AddEmployee(EmployeeEntity employee);
        //void UpdateEmployee(EmployeeEntity employee);
      public Task DeleteEmployee(int id);

    }
}
