using Bazar.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bazar.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly BazarContext _context;

		public ProductsController(BazarContext context)
		{
			_context = context;
		}

		// Endpoint para obtener todos los productos
		[HttpGet]
		public async Task<IActionResult> GetAllProducts()
		{
			var products = await _context.Products
				.Select(p => new
				{
					p.Title,
					p.Description,
					p.Price,
					p.Category,
					p.Rating,
					p.Thumbnail
				})
				.ToListAsync();

			return Ok(products);
		}

		// Endpoint para realizar búsqueda de productos
		[HttpGet("items")]
		public async Task<IActionResult> SearchItems([FromQuery] string q)
		{
			if (string.IsNullOrWhiteSpace(q))
			{
				return Ok("Search query is required.");
			}

			// Buscar productos por título o descripción que contengan la query
			var products = await _context.Products
				.Where(p => p.Title.Contains(q) || p.Description.Contains(q))
				.Select(p => new
				{
					p.Id,
					p.Title,
					p.Description,
					p.Price,
					p.Category,
					p.Rating,
					p.Thumbnail,
					p.Stock,
				})
				.ToListAsync();

			return Ok(products);
		}
		[HttpGet("items/{id}")]
		public IActionResult GetItem(int id)
		{
			// Buscar el producto por su ID
			var item = _context.Products
				.Where(p => p.Id == id)
				.Select(p => new
				{
					p.Id,
					p.Title,
					p.Description,
					p.Price,
					p.Category,
					p.Rating,
					p.Thumbnail,
					p.Stock,
					p.Images
				})
				.FirstOrDefault();

			// Si no se encuentra el producto, devolver un error 404
			if (item == null)
			{
				return NotFound(new { message = "Producto no encontrado" });
			}

			// Si se encuentra el producto, devolver los datos
			return Ok(item);
		}
		[HttpGet("sales")]
		public IActionResult GetSales()
		{
			var sales = _context.Sales
				.Select(s => new
				{
					s.Id,
					s.ProductId,
					s.Quantity,
					s.TotalPrice,
					s.SaleDate,
					ProductTitle = s.Product.Title
				})
				.ToList();

			return Ok(sales);
		}

		[HttpPost("addSale")]
		public IActionResult AddSale([FromBody] SaleRequestDto saleRequest)
		{
			// Validar si el producto existe en la base de datos
			var product = _context.Products.FirstOrDefault(p => p.Id == saleRequest.ProductId);
			if (product == null)
			{
				return NotFound(new { message = "Producto no encontrado" });
			}

			// Calcular el precio total basado en la cantidad y el precio del producto
			

			// Crear una nueva venta
			var sale = new Sale
			{
				ProductId = saleRequest.ProductId,
				Quantity = 1,
				TotalPrice = product.Price??0,
				SaleDate = DateTime.Now
			};
			product.Stock -= 1;
			// Agregar la venta a la base de datos
			_context.Products.Update(product);
			_context.Sales.Add(sale);
			_context.SaveChanges();

			// Retornar respuesta con éxito
			return Ok(new { success = true });
		}


		public class SaleRequestDto
		{
			public int ProductId { get; set; }
			
		}


	}
}
