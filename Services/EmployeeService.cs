using EmployeeManagement.Entities;
using EmployeeManagement.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EmployeeManagement.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository) { 
                    
            _employeeRepository = employeeRepository;
           
        
        
        }

           public async Task<IEnumerable<EmployeeEntity>> GetAllEmployees() { 

                      return    await  _employeeRepository.GetAllEmployees();
            
            
            
            }
           public async Task< EmployeeEntity> GetEmployeeById(int id) {
            
                  return await _employeeRepository.GetEmployeeById(id);
            }
           public async Task<int> AddEmployee(EmployeeEntity employee) { 
        
              return await _employeeRepository.AddEmployee(employee);
        
        
        
        }
            void UpdateEmployee(EmployeeEntity employee) { }
            public async Task DeleteEmployee(int id) {
               
              await _employeeRepository.DeleteEmployee(id);


           
        
        
        
        }




        }   
    }

