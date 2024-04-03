using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission11.Infastructure;
using Mission11.Models;

namespace Mission11.Pages
{
    public class CartModel : PageModel
    {

        private IBookstoreRepository _repo;

        public Cart Cart { get; set; }

        public CartModel(IBookstoreRepository temp, Cart cartService)
        {
            _repo = temp;
            Cart = cartService;
        }

        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int bookId, string returnUrl) 
        { 
            Book book = _repo.Books
                .FirstOrDefault(x => x.BookId == bookId);

            if (book != null) 
            {
                Cart.AddItem(book, 1);
            }

            return RedirectToPage (new {retrurnUrl = returnUrl});
        }

        public IActionResult OnPostRemove (int bookId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage (new { retrurnUrl = returnUrl});
        }
    }
}
