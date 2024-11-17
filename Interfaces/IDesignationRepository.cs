using EmployeeManagement.Entities;

namespace EmployeeManagement.Interfaces
{
    public interface IDesignationRepository
    {
        public Task<IEnumerable<Designation>> GetAllDesignation();
        //public Task<Department> GetDepartemtById(int id);
        public Task AddDesignation(Designation des);
        //void UpdateEmployee(EmployeeEntity employee);
        public Task DeleteDesignation(int id);
    }
}
