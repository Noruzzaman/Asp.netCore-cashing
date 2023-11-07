using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cashingaspnet.Models
{
    public interface IEmployeetRepository
    {
        Task<List<EmployeeDTO>> GetEmployees();       

        Task<EmployeeDTO> GetEmployeesByID(int? Id);

       

    }
}
