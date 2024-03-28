using Microsoft.AspNetCore.Mvc;
using Mission11.Models;

namespace Mission11.Components
{
    public class BookTypesViewComponent : ViewComponent
    {
        private IBookstoreRepository _bookRepo;

        // Constructor
        public BookTypesViewComponent(IBookstoreRepository temp) 
        {
            _bookRepo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedBooktype = RouteData?.Values["booktype"];

            var bookTypes = _bookRepo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(bookTypes);
        }
    }
}
