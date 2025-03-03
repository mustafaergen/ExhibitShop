using Microsoft.AspNetCore.Http;
using ProductCatalog_Repositories.UnitOfWork;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Enums;
using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Services
{
    public class ArticleService : IArticleService
    {
        private readonly IRepositoryManager _manager;

        public ArticleService(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateArticle(Article article)
        {
            var art = new Article {Name = article.Name, Introduction=article.Introduction, Development=article.Development, Conclusion=article.Conclusion, ImageUrl1=article.ImageUrl1,ImageUrl2=article.ImageUrl2,ImageUrl3=article.ImageUrl3,Status=Status.Passive };
            _manager.ArticleRepository.Create(art);
            _manager.Save();
        }

        public void DeleteArticle(int id)
        {
            var article = _manager.ArticleRepository.FindById(id);
            if (article is null)
                throw new Exception("Article not found!");

                _manager.ArticleRepository.Delete(article);
                _manager.Save();
        }

        public IEnumerable<Article> GetAllArticle()
        {
            return _manager.ArticleRepository.GetAllArticle();
        }

        public IEnumerable<Article> GetAllArticleByStatus()
        {
            return _manager.ArticleRepository.GetAllArticle().Where(x => x.Status == Status.Active);
        }

        public Article GetArticle(int id)
        {
            return _manager.ArticleRepository.FindById(id);
        }

        public void UpdateArticle(Article article)
        {
            var art = _manager.ArticleRepository.FindById(article.Id);
            art.Name = article.Name;
            art.Introduction = article.Introduction;
            art.Development = article.Development;
            art.Conclusion= article.Conclusion;
            art.ImageUrl1 = article.ImageUrl1;
            art.ImageUrl2 = article.ImageUrl2;
            art.ImageUrl3 = article.ImageUrl3;
            art.Status = article.Status;
            _manager.ArticleRepository.Update(art);
            _manager.Save();
        }

        public void UpdateStatus(int id, Status status)
        {
            var art = _manager.ArticleRepository.FindById(id);
            art.Status = status;
            _manager.Save();
        }
    }
}
