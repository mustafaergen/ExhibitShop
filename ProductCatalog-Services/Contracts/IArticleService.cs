using Microsoft.AspNetCore.Http;
using ProductCatolog_Core.Enums;
using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Services.Contracts
{
    public interface IArticleService
    {
        IEnumerable<Article> GetAllArticle();
        Article GetArticle(int id);
        void CreateArticle(Article article);
        void UpdateArticle(Article article);
        void UpdateStatus(int id, Status status);
        void DeleteArticle(int id);
    }
}
