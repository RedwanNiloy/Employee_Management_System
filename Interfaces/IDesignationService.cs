using EmployeeManagement.Entities;

namespace EmployeeManagement.Interfaces
{
    public interface IDesignationService
    {

       public  Task<IEnumerable<Designation>> GetAllDesignation();
        //Employee GetEmployeeById(int id);
       public Task AddDesignation(Designation dsg);
      //  public Task UpdateDesignation(Designation dsg);
        public Task DeleteDesignation(int id);
    }
}
