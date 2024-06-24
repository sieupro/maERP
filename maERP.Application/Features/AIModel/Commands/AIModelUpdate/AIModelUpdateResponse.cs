﻿namespace maERP.Application.Features.AIModel.Commands.AIModelUpdate;

public class AIModelUpdateResponse
{
    public int Id { get; set; }
    public int AIType { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ApiUsername { get; set; } = string.Empty;
    public string ApiPassword { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
}