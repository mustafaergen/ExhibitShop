using ProductCatalog_Repositories.Contexts;
using ProductCatalog_Repositories.Contracts;
using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Repositories
{
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Article> GetAllArticle() => FindAll();

    }
}
