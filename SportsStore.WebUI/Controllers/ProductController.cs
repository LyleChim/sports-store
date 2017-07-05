using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository repository;

        public int PageSize = 4;

        public ProductController(IProductsRepository productsRepository) {
            this.repository = productsRepository;
        }
        
        public ViewResult List(string category, int page = 1) {

            var productsWhere = repository.Products.Where(p => category == null || p.Category == category);

            var products = productsWhere.OrderBy(p => p.ProductID)
                                        .Skip((page - 1) * PageSize)
                                        .Take(PageSize);

            var pagingInfo = new PagingInfo {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = productsWhere.Count()
            };

            ProductsListViewModel model = new ProductsListViewModel {
                Products = products,
                PagingInfo = pagingInfo,
                CurrentCategory = category
            };

            return View(model);
        }

    }
}