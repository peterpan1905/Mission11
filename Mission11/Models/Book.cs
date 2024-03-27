using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mission11.Models;

public partial class Book
{
    [Key]
    [Required(ErrorMessage = "A book id is required")]
    public int BookId { get; set; }
    [Required(ErrorMessage = "A title is required")]
    public string Title { get; set; } = null!;
    [Required(ErrorMessage = "An author is required")]
    public string Author { get; set; } = null!;
    [Required(ErrorMessage = "A publisher is required")]
    public string Publisher { get; set; } = null!;
    [Required(ErrorMessage = "An ISBN is required")]
    public string Isbn { get; set; } = null!;
    [Required(ErrorMessage = "A classification is required")]
    public string Classification { get; set; } = null!;
    [Required(ErrorMessage = "A category is required")]
    public string Category { get; set; } = null!;
    [Required(ErrorMessage = "A page count is required")]
    public int PageCount { get; set; }
    [Required(ErrorMessage = "A price is required")]
    public double Price { get; set; }
}
