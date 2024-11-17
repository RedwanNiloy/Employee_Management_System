using EmployeeManagement.Entities;
using EmployeeManagement.Interfaces;

namespace EmployeeManagement.Services
{
    public class DepartmentService:IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        public DepartmentService(IDepartmentRepository repository) {

            _repository = repository;
        }


        public async Task<IEnumerable<Department>> GetAllDepartment() { 
        
           return await _repository.GetAllDepartment();
        
        
        
        }
        // Employee GetDepartmentById(int id);
        public async Task AddDepartment(Department dept)
        { 
             await _repository.AddDepartment(dept); 
        
        }
        //void UpdateDepartment(Department dept);
       public async Task DeleteDepartment(int id) { 
        
        await _repository.DeleteDepartment(id); 
        
        }

    }
}
