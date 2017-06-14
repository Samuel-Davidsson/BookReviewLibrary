using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SamsBookReviewLibary.Repositories;
using SamsBookReviewLibary.ViewModels;

namespace SamsBookReviewLibary.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookTitleRepository _bookrepo;

        public HomeController(IBookTitleRepository bookrepo)
        {
            _bookrepo = bookrepo;
        }


        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                BookTitles = _bookrepo.BookTitles
            
            };
            return View(homeViewModel);

        }
    }
}
