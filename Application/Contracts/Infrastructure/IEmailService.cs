﻿namespace Application.Contracts.Infrastructure;

public interface IEmailService
{
    Task SendEmailAsync(string email, string subject, string content);
}
