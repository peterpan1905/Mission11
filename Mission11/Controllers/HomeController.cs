using Microsoft.AspNetCore.Mvc;
using Mission11.Models;
using Mission11.Models.ViewModels;
using System.Diagnostics;

namespace Mission11.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository _repo;
        public HomeController(IBookstoreRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 5;

            var bookList = new BooksListViewModel
            {
                Books = _repo.Books
                    .OrderBy(x => x.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Books.Count()

                }
            };

            return View(bookList);
        }
    }
}
