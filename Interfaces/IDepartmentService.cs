using EmployeeManagement.Entities;

namespace EmployeeManagement.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllDepartment();
       // Employee GetDepartmentById(int id);
        Task AddDepartment(Department dept);
        //void UpdateDepartment(Department dept);
        Task DeleteDepartment(int id);
    }
}
