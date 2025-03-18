using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
	private static readonly List<string> Products = new() { "Laptop", "Phone", "Tablet" };
	[HttpGet]
	public IActionResult GetProducts()
	{
		return Ok(Products);
	}
	[Authorize]
	[HttpPost]
	public IActionResult AddProduct(string product)
	{
		Products.Add(product);
		return Ok(Products);
	}
}