using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cashingaspnet.Models
{
    public class EmployeeDTO
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime Doj { get; set; }
        public string Gender { get; set; }
        public int IsMarried { get; set; }
        public int IsActive { get; set; }
        public int DesignationID { get; set; }

        public string Designations { get; set; }

        public List<Designation> DesignationsList { get; set; }
        public Employee EmployeeList { get; set; }


    }
}
