using E_Coms_DataAccess.Data;
using E_Coms_DataAccess.Repository.IRepository;
using E_Coms_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Coms_DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _appDbContext;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            Category = new CategoryRepository(_appDbContext);
            Product = new ProductRepository(_appDbContext);
        }

       

        public void Save()
        {
            _appDbContext.SaveChanges();
        }
    }
}
