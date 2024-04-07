﻿using FluentValidation;
using maERP.Application.Contracts.Persistence;

namespace maERP.Application.Features.Product.Commands.CreateProductCommand;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandValidator(IProductRepository productRepository)
    {
        _productRepository = productRepository;

        RuleFor(p => p.TaxRate)
            .NotNull().WithMessage("{PropertyName} is required.")
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .InclusiveBetween(0, 100).WithMessage("{PropertyName} must between 0 and 100.");
    }

    private async Task<bool> ProductUnique(CreateProductCommand command, CancellationToken cancellationToken)
    {
        // TODO: Implement unique Product name validation
        await Task.CompletedTask;
        return true;
    }
}
