﻿using AutoMapper;
using maERP.Application.Contracts.Logging;
using maERP.Application.Contracts.Persistence;
using maERP.Application.Features.SalesChannel.Commands.UpdateSalesChannelCommand;
using MediatR;

namespace maERP.Application.Features.SalesChannel.Commands.UpdateSalesChannelCommand;

public class UpdateSalesChannelCommandHandler : IRequestHandler<UpdateSalesChannelCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IAppLogger<UpdateSalesChannelCommandHandler> _logger;
    private readonly ISalesChannelRepository _salesChannelRepository;


    public UpdateSalesChannelCommandHandler(IMapper mapper,
        IAppLogger<UpdateSalesChannelCommandHandler> logger,
        ISalesChannelRepository salesChannelRepository)
    {
        _mapper = mapper;
        _logger = logger;
        _salesChannelRepository = salesChannelRepository;
    }

    public async Task<int> Handle(UpdateSalesChannelCommand request, CancellationToken cancellationToken)
    {
        // Validate incoming data
        var validator = new UpdateSalesChannelCommandValidator(_salesChannelRepository);
        var validationResult = await validator.ValidateAsync(request);

        if(validationResult.Errors.Any())
        {
            _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(SalesChannel.Commands.CreateSalesChannelCommand), request.Id);
            throw new Exceptions.ValidationException("Invalid SalesChannel", validationResult);
        }

        // convert to domain entity object
        var salesChannelToUpdate = _mapper.Map<Domain.SalesChannel>(request);

        // add to database
        await _salesChannelRepository.UpdateAsync(salesChannelToUpdate);

        // return record id
        return salesChannelToUpdate.Id;
    }
}
