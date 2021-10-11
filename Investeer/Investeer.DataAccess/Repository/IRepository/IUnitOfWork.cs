using System;
using System.Collections.Generic;
using System.Text;

namespace Investeer.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        ISP_Call SP_Call { get; }
    }
}
