using E_Coms_DataAccess.Data;
using E_Coms_DataAccess.Repository.IRepository;
using E_Coms_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Coms_DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository 
    {
        private readonly AppDbContext _appDbContext;
        public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Save()
        {
           _appDbContext.SaveChanges();
        }

        public void Update(Category category)
        {
            _appDbContext.Update(category);
        }
    }
}
