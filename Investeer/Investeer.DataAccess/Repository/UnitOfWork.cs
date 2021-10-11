using Investeer.DataAccess.Data;
using Investeer.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Investeer.DataAccess.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        

        public UnitOfWork(ApplicationDbContext db,IEmailService emailService)
        {
            _db = db;
            PropertyName = new PropertyNameRepository(_db);
            PropertyDetail = new PropertyDetailRepository(_db);
            SP_Call = new SP_Call(_db);
            _emailService = emailService;
        }

        public IPropertyNameRepository PropertyName { get; private set; }
        public IPropertyDetailRepository PropertyDetail { get; private set; }
        public ISP_Call SP_Call { get; private set; }
        public IEmailService _emailService { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
