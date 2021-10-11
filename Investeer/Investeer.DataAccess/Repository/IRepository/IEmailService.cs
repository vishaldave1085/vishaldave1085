using Dapper;
using Investeer.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Investeer.DataAccess.Repository.IRepository
{
    public interface IEmailService
    {
        Task SendEmailAsync<T,S,U>(Email mailRequest, T t, S s, U u);
    }
}
