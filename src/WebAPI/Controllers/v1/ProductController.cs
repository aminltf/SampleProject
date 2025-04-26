using Application.Common.Models.Pagination;
using Application.Features.Product.Commands;
using Application.Features.Product.Dtos;
using Application.Features.Product.Queries;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Base;

namespace WebAPI.Controllers.v1;

[ApiVersion("1.0")]
public class ProductController : ApiControllerBase
{
    [HttpPost("create")]
    public async Task<ActionResult<ProductDto>> Create(CreateProductCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpPut("update/{id:guid}")]
    public async Task<ActionResult<ProductDto>> Update(Guid id, UpdateProductCommand command)
    {
        if (id != command.Id) return BadRequest("ID mismatch");
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("soft-delete/{id:guid}")]
    public async Task<IActionResult> SoftDelete(Guid id, [FromQuery] string deletedBy)
    {
        await Mediator.Send(new DeleteProductCommand(id, deletedBy));
        return NoContent();
    }

    [HttpPost("restore/{id:guid}")]
    public async Task<IActionResult> Restore(Guid id, [FromQuery] string modifiedBy)
    {
        await Mediator.Send(new RestoreProductCommand(id, modifiedBy));
        return NoContent();
    }

    [HttpGet("get-by-id/{id:guid}")]
    public async Task<ActionResult<ProductDto>> GetById(Guid id, [FromQuery] bool includeDeleted = false)
    {
        return Ok(await Mediator.Send(new GetProductByIdQuery(id, includeDeleted)));
    }

    [HttpGet("get-all")]
    public async Task<ActionResult<PageResponse<ProductDto>>> GetAll([FromQuery] int page = 1, [FromQuery] int size = 10)
    {
        var query = new GetAllProductsQuery
        {
            Pagination = new PageRequest { PageNumber = page, PageSize = size }
        };

        return Ok(await Mediator.Send(query));
    }

    [HttpGet("get-deleted")]
    public async Task<ActionResult<PageResponse<ProductDto>>> GetDeleted([FromQuery] int page = 1, [FromQuery] int size = 10)
    {
        var query = new GetAllDeletedProductsQuery
        {
            Pagination = new PageRequest { PageNumber = page, PageSize = size }
        };

        return Ok(await Mediator.Send(query));
    }
}
