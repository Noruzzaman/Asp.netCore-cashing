using Cashingaspnet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace Cashingaspnet.Models
{
    public class EmployeeRepository: IEmployeetRepository
    {

        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context)
        {
             _context= context;
        }
        public async Task<List<EmployeeDTO>> GetEmployees()
        {
            if (_context != null)
            {
                return await (from s in _context.TblEmployee
                              join st in _context.TblDesignation on s.DesignationID equals st.Id into st2
                              from st in st2.DefaultIfEmpty()
                              select new EmployeeDTO
                              {

                                  Id =(int)s.Id,
                                  Name = s.Name,
                                  LastName = s.LastName,
                                  Email = s.Email,
                                  Age = s.Age,
                                  Doj = s.Doj,
                                  Gender = s.Gender,
                                  IsMarried = s.IsMarried,
                                  IsActive = s.IsActive,
                                  DesignationID = s.DesignationID,
                                  Designations = st.Designations

                              }).ToListAsync();
            }

            return null;
        }

        public async Task<EmployeeDTO> GetEmployeesByID(int? empId)
        {
                       
            if (_context != null)
            {
                return await (from s in _context.TblEmployee
                              from st in _context.TblDesignation
                              where s.Id == empId
                              select new EmployeeDTO
                              {
                                  Id = (int)s.Id,
                                  Name = s.Name,
                                  LastName = s.LastName,
                                  Email = s.Email,
                                  Age = s.Age,
                                  Doj = s.Doj,
                                  Gender = s.Gender,
                                  IsMarried = s.IsMarried,
                                  IsActive = s.IsActive,
                                  DesignationID = s.DesignationID,
                                  Designations = st.Designations
                              }).FirstOrDefaultAsync();
            }

            return null;
        }

      
       


    }
}
