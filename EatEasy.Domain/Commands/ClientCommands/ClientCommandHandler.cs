using EatEasy.Domain.Core.Messaging;
using MediatR;
using EatEasy.Domain.Interfaces;
using EatEasy.Domain.Models;
using FluentValidation.Results;

namespace EatEasy.Domain.Commands.ClientCommands
{
    public class ClientCommandHandler : CommandHandler,
        IRequestHandler<RegisterClientCommand, ValidationResult>,
        IRequestHandler<UpdateClientCommand, ValidationResult>,
        IRequestHandler<RemoveClientCommand, ValidationResult>
    {

        private readonly IClientRepository _clientRepository;

        public ClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<ValidationResult> Handle(RegisterClientCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            if (await _clientRepository.GetByCpfAsync(request.CPF, cancellationToken) != null)
            {
                AddError("Já existe um cliente com o CPF informado.");
                return ValidationResult;
            }

            var entity = new Client(Guid.NewGuid(), request.Name, request.CPF, request.Password, request.Email, request.MobilePhone);

            _clientRepository.AddAsync(entity, cancellationToken);

            return await Commit(_clientRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var entity = new Client(request.Id, request.Name, request.CPF, request.Password, request.Email, request.MobilePhone);
            var existingEntity = await _clientRepository.GetByCpfAsync(request.CPF, cancellationToken);

            if (existingEntity != null && existingEntity.Id != entity.Id)
            {
                AddError("Já existe um cliente com o CPF informado.");
                return ValidationResult;
            }

            _clientRepository.Update(entity);

            return await Commit(_clientRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveClientCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var customer = await _clientRepository.GetByIdAsync(request.Id, cancellationToken);

            if (customer is null)
            {
                AddError("Cliente não encontrado");
                return ValidationResult;
            }

            _clientRepository.Remove(customer);

            return await Commit(_clientRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _clientRepository.Dispose();
        }
    }
}
