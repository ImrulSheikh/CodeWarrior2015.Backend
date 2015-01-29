using System.Data.Entity;
using CW.Backend.DAL.Base.Repositories;
using CW.Backend.DAL.Query.Entities;

namespace CW.Backend.DAL.Query
{
    public class ProductFlatRepository : RepositoryBase<ProductFlat>, IProductFlatRepository
    {
        public ProductFlatRepository(DbContext context) : base(context) { }
    }
}