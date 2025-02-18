using ProductCatalog_Repositories.Contracts.Base;
using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Repositories.Contracts
{
    public interface IArticleRepository : IRepositoryBase<Article>
    {
        IQueryable<Article> GetAllArticle();
    }
}
