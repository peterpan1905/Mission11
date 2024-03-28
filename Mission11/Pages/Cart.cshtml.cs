using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission11.Infastructure;
using Mission11.Models;

namespace Mission11.Pages
{
    public class CartModel : PageModel
    {

        private IBookstoreRepository _repo;

        public CartModel(IBookstoreRepository temp)
        {
            _repo = temp;
        }

        public Cart? Cart { get; set; }
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
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(book, 1);
                HttpContext.Session.SetJson("cart", Cart);
            }

            return RedirectToPage (new {retrurnUrl = returnUrl});
        }
    }
}
