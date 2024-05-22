﻿using maERP.Domain.Models;

namespace maERP.Application.Contracts.Persistence;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<Product?> GetBySkuAsync(string sku);
    Task<Product?> GetWithDetailsAsync(int id);
}