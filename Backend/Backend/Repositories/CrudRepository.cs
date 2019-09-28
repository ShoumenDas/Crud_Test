using Backend.DBContext;
using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public class CrudRepository : ICrudRepository<CrudModels>
    {
        readonly Crud_Context _context;

        public CrudRepository(Crud_Context context)
        {
            _context = context;
        }
        public void Add(CrudModels entity)
        {
            _context.CrudContext.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(CrudModels entity)
        {
            _context.CrudContext.Remove(entity);
            _context.SaveChanges();
        }

        public CrudModels Get(long id)
        {
            return _context.CrudContext.FirstOrDefault(c => c.ID == id);
        }

        public IEnumerable<CrudModels> GetAll()
        {
            return _context.CrudContext.ToList().OrderBy(c => c.FirstName);
        }

        public void Update(CrudModels crudModel, CrudModels entity)
        {
            crudModel.FirstName = entity.FirstName;
            crudModel.LastName = entity.LastName;
            crudModel.Email = entity.Email;
            crudModel.DateOfBirth = entity.DateOfBirth;
            crudModel.PhoneNo = entity.PhoneNo;

            _context.CrudContext.Add(crudModel);
            _context.SaveChanges();
        }
    }
}
