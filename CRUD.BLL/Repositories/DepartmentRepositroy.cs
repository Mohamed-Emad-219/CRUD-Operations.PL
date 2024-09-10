using CRUD.BLL.Interfacies;
using CURD.DAL.Data;
using CURD.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.BLL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDBContext _dbContext;
        public DepartmentRepository(AppDBContext dbContext)
        {
            //   _dbcontext = new ProjectDbContext();// vaild but not good because will create obj in each operation
            _dbContext = dbContext;
        }
        public int Add(Department department)
        {
            _dbContext.Departments.Add(department);
            return _dbContext.SaveChanges();
        }

        public int Delete(Department department)
        {
            _dbContext.Departments.Remove(department);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Department> GetAll()
        {
            var department = _dbContext.Departments.AsNoTracking().ToList();
            return department;
        }

        public Department GetById(int id)
        {
            //var department = _dbContext.Departments.Where(D=>D.Id==id).FirstOrDefault();
            //Best Performance
            var department = _dbContext.Departments.Find(id);//// find op search in cache if found return it else ssearch in database
            return department;

        }

        public int Update(Department department)
        {
            _dbContext.Departments.Update(department);
            return _dbContext.SaveChanges();
        }
    }
}