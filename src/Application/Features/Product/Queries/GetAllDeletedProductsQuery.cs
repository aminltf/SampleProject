﻿using Application.Common.Models.Pagination;
using Application.Features.Product.Dtos;
using MediatR;

namespace Application.Features.Product.Queries;

public class GetAllDeletedProductsQuery : IRequest<PageResponse<ProductDto>>
{
    public PageRequest Pagination { get; set; } = new();
}
