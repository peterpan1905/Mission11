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

        public IActionResult Index(int pageNum, string? bookType)
        {
            int pageSize = 10;

            var bookList = new BooksListViewModel
            {
                Books = _repo.Books
                    .Where(x => x.Category == bookType || bookType == null)
                    .OrderBy(x => x.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = bookType == null ? _repo.Books.Count() : _repo.Books.Where(x => x.Category == bookType).Count()

                },

                CurrentBookType = bookType

            };

            return View(bookList);
        }
    }
}
