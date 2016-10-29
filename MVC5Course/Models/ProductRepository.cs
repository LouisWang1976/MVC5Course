using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public override IQueryable<Product> All()
        {
            return base.All().Where(p=>p.IsDeleted==true);
        }
        public Product Find(int id)
        {
            return this.All().FirstOrDefault(p=>p.ProductId==id);
        }
        public IQueryable<Product> GetAllDataOrderByProduct(int TakeValue)
        {
            return this.All().OrderByDescending(p => p.ProductId).Take(TakeValue);
        }
        public override void Delete(Product entity)
        {
            entity.IsDeleted = true;
        }
    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}