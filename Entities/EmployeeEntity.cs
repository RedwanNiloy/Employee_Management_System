using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace EmployeeManagement.Entities
{
    public class EmployeeEntity
    {
        
        public int? emp_id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string name { get; set; }
        [Required(ErrorMessage = "email is required.")]
        public string email { get; set; }
        [Required(ErrorMessage = "address is required.")]
        public string address { get; set; }

        [Required(ErrorMessage = "DOB is required.")]
        public DateTime dob { get; set; }
        [Required(ErrorMessage = "Dept_id is required.")]
        public int dept_id { get; set; }

        [Required(ErrorMessage = "Designation id is required.")]
        public int dsg_id { get; set; }
       
       

       


    }
}
