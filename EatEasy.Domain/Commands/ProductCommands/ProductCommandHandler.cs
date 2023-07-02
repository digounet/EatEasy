using EatEasy.Domain.Core.Messaging;
using MediatR;
using EatEasy.Domain.Interfaces;
using EatEasy.Domain.Models;
using FluentValidation.Results;

namespace EatEasy.Domain.Commands.ProductCommands
{
    public class ProductCommandHandler : CommandHandler,
        IRequestHandler<RegisterProductCommand, ValidationResult>,
        IRequestHandler<UpdateProductCommand, ValidationResult>,
        IRequestHandler<RemoveProductCommand, ValidationResult>
    {

        private readonly IProductRepository _productRepository;

        public ProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ValidationResult> Handle(RegisterProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            if (await _productRepository.GetByNameAsync(request.Name, cancellationToken) != null)
            {
                AddError("Já existe um produto com o nome informado.");
                return ValidationResult;
            }

            var entity = new Product(Guid.NewGuid(), request.Name, request.Description, request.CategoryID, request.Price);

            _productRepository.AddAsync(entity, cancellationToken);

            return await Commit(_productRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var entity = new Product(request.Id, request.Name, request.Description, request.CategoryID, request.Price);
            var existingEntity = await _productRepository.GetByNameAsync(request.Name, cancellationToken);

            if (existingEntity != null && existingEntity.Id != entity.Id)
            {
                AddError("Já existe um produto com o nome informado.");
                return ValidationResult;
            }

            _productRepository.Update(entity);

            return await Commit(_productRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var customer = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

            if (customer is null)
            {
                AddError("Produto não encontrado");
                return ValidationResult;
            }

            _productRepository.Remove(customer);

            return await Commit(_productRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _productRepository.Dispose();
        }
    }
}
