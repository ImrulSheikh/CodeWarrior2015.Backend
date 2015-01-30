using System.Data.Entity;
using CW.Backend.DAL.Base.Repositories;
using CW.Backend.DAL.Query.Entities;

namespace CW.Backend.DAL.Query
{
    public class ProductSummaryRepository : RepositoryBase<ProductSummary>, IProductSummaryRepository
    {
        public ProductSummaryRepository(DbContext context) : base(context) { }
    }
}