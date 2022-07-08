﻿namespace Vshop.Web.Models.ViewModel;
public class ProductViewmodel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public long Stock { get; set; }
    public string? ImageUrl { get; set; }
    public string? CategoryName { get; set; }
    public int CategoryId { get; set; }
}
