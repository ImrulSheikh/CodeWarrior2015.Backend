using System.Data.Entity;
using CW.Backend.DAL.Base.Repositories;
using CW.Backend.DAL.Query.Entities;

namespace CW.Backend.DAL.Query
{
    public class ProductDetailsRepository : RepositoryBase<ProductDetails>, IProductDetailsRepository
    {
        public ProductDetailsRepository(DbContext context) : base(context) { }
    }
}