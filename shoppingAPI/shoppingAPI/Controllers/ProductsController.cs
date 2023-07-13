using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shoppingAPI.Models;

namespace shoppingAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		Products pObj = new Products(); //this is a bad code, we should use DI instead
		[HttpGet]
		[Route("/plist")]
		public IActionResult GetAllProducts()
		{
			return Ok(pObj.GetAllProducts());
		}		
		[HttpGet]
		[Route("/plist/name/{name}")]
		public IActionResult GetProductsByName(string name)
		{
			try
			{
				var result = pObj.GetProductsByName(name);
				return Ok(result);
			}
			catch (Exception es)
			{
				return NotFound(es.Message);
			}
		}
		[HttpGet]
		[Route("/plist/category/{category}")]
		public IActionResult GetProductsByCategory(string category)
		{
			try
			{
				var result = pObj.GetProductsByCategory(category);
				return Ok(result);
			}
			catch (Exception es)
			{
				return NotFound(es.Message);
			}
		}
		[HttpGet]
		[Route("/plist/inStock/{state}")]
		public IActionResult GetinStockProducts(bool state)
		{
			return Ok(pObj.GetinStockProducts(state));
		}
		[HttpGet]
		[Route("/plist/total")]
		public IActionResult GetTotalProducts()
		{
			return Ok(pObj.GetTotalProducts());
		}



		[HttpPost]
		[Route("/plist/add")]
		public IActionResult AddNewProducts([FromBody] Products prdobj)
		{
			var addresult = pObj.AddProducts(prdobj);
			return Created("", addresult);
		}
		[HttpDelete]
		[Route("/plist/delete/{id}")]
		public IActionResult DeleteProduct(int id)
		{
			try
			{
				var deleteResult = pObj.DeleteProduct(id);
				return Accepted(deleteResult);
			}
			catch (Exception es)
			{
				return NotFound(es.Message);
			}
		}
		[HttpPut]
		[Route("/plist/edit/{id}")]
		public IActionResult UpdateProduct(int id, [FromBody] Products prdObj)
		{
			try
			{
				var updateResult = pObj.UpdateProduct(id, prdObj);
				return Ok(updateResult);
			}
			catch (Exception es)
			{
				return NotFound(es.Message);

			}
		}
	}
}
