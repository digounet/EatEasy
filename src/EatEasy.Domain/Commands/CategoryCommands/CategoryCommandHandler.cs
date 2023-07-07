using EatEasy.Domain.Core.Messaging;
using MediatR;
using EatEasy.Domain.Interfaces;
using EatEasy.Domain.Models;
using FluentValidation.Results;

namespace EatEasy.Domain.Commands.CategoryCommands
{
    public class CategoryCommandHandler : CommandHandler,
        IRequestHandler<RegisterCategoryCommand, ValidationResult>,
        IRequestHandler<UpdateCategoryCommand, ValidationResult>,
        IRequestHandler<RemoveCategoryCommand, ValidationResult>
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ValidationResult> Handle(RegisterCategoryCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            if (await _categoryRepository.GetByNameAsync(request.Name, cancellationToken) != null)
            {
                AddError("Já existe uma categoria com o nome informado.");
                return ValidationResult;
            }

            var entity = new Category(Guid.NewGuid(), request.Name);

            _categoryRepository.AddAsync(entity, cancellationToken);

            return await Commit(_categoryRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var entity = new Category(request.Id, request.Name);
            var existingEntity = await _categoryRepository.GetByNameAsync(request.Name, cancellationToken);

            if (existingEntity != null && existingEntity.Id != entity.Id)
            {
                AddError("Já existe uma categoria com o nome informado.");
                return ValidationResult;
            }

            _categoryRepository.Update(entity);

            return await Commit(_categoryRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var category = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);

            if (category is null)
            {
                AddError("Categoria não encontrada");
                return ValidationResult;
            }

            _categoryRepository.Remove(category);

            return await Commit(_categoryRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _categoryRepository.Dispose();
        }
    }
}
