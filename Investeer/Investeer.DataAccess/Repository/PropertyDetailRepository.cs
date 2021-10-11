using Investeer.DataAccess.Data;
using Investeer.DataAccess.Repository.IRepository;
using Investeer.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Investeer.DataAccess.Repository
{
    public class PropertyDetailRepository : Repository<PropertyDetail>, IPropertyDetailRepository
    {
        private readonly ApplicationDbContext _db;

        public PropertyDetailRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
