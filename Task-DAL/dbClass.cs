using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task_DAL.IntalioDbModel;
using System.Threading.Tasks;

namespace Task_DAL
{
    public class dbClass
    {
        IntalioDbContext _db = new IntalioDbContext();
        public IEnumerable<TblEmployee> getAllEmployees()
        {
            try
            {
                return  _db.TblEmployees.ToList();
            }
            catch
            {
                return null;
            }
        }
        public async Task<TblEmployee> addEmployees(TblEmployee employee)
        {
            var obj = await _db.TblEmployees.AddAsync(employee);
            _db.SaveChanges();
            return obj.Entity;
        }
        public void updateEmployee(TblEmployee employee)
        {
            _db.TblEmployees.Update(employee);
            _db.SaveChanges();
        }
        public void deleteEmployee(TblEmployee employee)
        {
            _db.Remove(employee);
            _db.SaveChanges();
        }
        public void deleteEmployeeById(int id)
        {
            var employee = _db.TblEmployees.Find(id);
            _db.Remove(employee);
            _db.SaveChanges();
        }
    }
}
