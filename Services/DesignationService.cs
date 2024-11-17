using EmployeeManagement.Entities;
using EmployeeManagement.Interfaces;

namespace EmployeeManagement.Services
{
    public class DesignationService: IDesignationService
    {    
        private readonly IDesignationRepository _designationRepository;
        public DesignationService(IDesignationRepository designationRepository)
        {
            _designationRepository = designationRepository;


        }
           public async Task<IEnumerable<Designation>> GetAllDesignation()
            {

                return await _designationRepository.GetAllDesignation(); ;



            }


        // Employee GetDepartmentById(int id);
        public async Task AddDesignation(Designation dsg)
        {
            await _designationRepository.AddDesignation(dsg);

        }
        //void UpdateDepartment(Department dept);
        public async Task DeleteDesignation(int id)
        {

            await _designationRepository.DeleteDesignation(id);

        }








    }
}
