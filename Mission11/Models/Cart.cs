namespace Mission11.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public void AddItem(Book book, int quantity)
        {
            CartLine? line = Lines
                .Where(x => x.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine()
                {
                    Book = book,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Book book) => Lines.RemoveAll(x => x.Book.BookId == book.BookId);

        public void Clear() => Lines.Clear();

        public decimal CalculateTotal()
        {
            decimal total = 0;

            if (Lines != null)
            {
                total = (decimal)Lines.Where(line => line != null && line.Book != null)
                    .Sum(line => line.Book.Price * line.Quantity);
            }

            return total;
        }
        public class CartLine
        {
            public int CartLineId { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}
