using Investeer.DataAccess.Data;
using Investeer.DataAccess.Repository.IRepository;
using Investeer.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Investeer.DataAccess.Repository
{
    public class PropertyNameRepository: Repository<PropertyName>, IPropertyNameRepository
    {
        private readonly ApplicationDbContext _db;

        public PropertyNameRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
