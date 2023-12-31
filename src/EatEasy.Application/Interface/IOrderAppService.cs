﻿using EatEasy.Application.ViewModels;
using EatEasy.Domain.Enums;
using FluentValidation.Results;

namespace EatEasy.Application.Interface;

public interface IOrderAppService : IDisposable
{
    Task<ValidationResult> RegisterAsync(OrderRegisterViewModel orderViewModel, CancellationToken cancellationToken);

    Task<ValidationResult> UpdateStatus(Guid orderId, OrderStatus newStatus, CancellationToken cancellationToken);
    Task<IEnumerable<OrderViewModel>> GetAllAsync(string loggedUserRole, Guid loggedUserId, Guid? clientId, CancellationToken cancellationToken);
    Task<OrderViewModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<ValidationResult> Remove(Guid id, CancellationToken cancellationToken);
}