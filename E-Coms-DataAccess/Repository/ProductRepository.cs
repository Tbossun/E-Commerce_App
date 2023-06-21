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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Update(Product product)
        {
            _appDbContext.Update(product);
        }
    }
}
