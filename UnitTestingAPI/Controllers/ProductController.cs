using MediatR;
using Microsoft.AspNetCore.Mvc;

using UnitTestingAPI.Application.Products.Commands.AddProduct;
using UnitTestingAPI.Application.Products.Commands.DeleteProduct;
using UnitTestingAPI.Application.Products.Interfaces;

namespace UnitTestingAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController
{
    private readonly IMediator _mediator;
    private readonly IProductService _productService;

	public ProductController(IMediator mediator, IProductService productService)
	{
        _mediator = mediator;
        _productService = productService;
	}

    [HttpGet]
    public async Task<IActionResult> Get(int id)
        => await _productService.GetByIdAsync(id).ToActionResult();

    [HttpPost]
    public async Task<IActionResult> Create(AddProductRequest request)
            => await _mediator.Send(request).ToActionResult();

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteProductRequest request)
        => await _mediator.Send(request).ToActionResult();
}