using EatEasy.Application.Interface;
using EatEasy.Application.ViewModels;
using FluentValidation.Results;
using AutoMapper;
using EatEasy.Domain.Commands.CategoryCommands;
using EatEasy.Domain.Core.Mediator;
using EatEasy.Domain.Interfaces;

namespace EatEasy.Application.Services
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMediatorHandler _mediator;

        public CategoryAppService(IMapper mapper, ICategoryRepository categoryRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _mediator = mediator;
        }

        public void Dispose()
        {
            _categoryRepository.Dispose();
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryRepository.GetAllAsync(cancellationToken));
        }

        public async Task<CategoryViewModel> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return _mapper.Map<CategoryViewModel>(await _categoryRepository.GetByIdAsync(id, cancellationToken));
        }

        public async Task<ValidationResult> RegisterAsync(CategoryViewModel categoryViewModel, CancellationToken cancellationToken)
        {
            var registerCommand = _mapper.Map<RegisterCategoryCommand>(categoryViewModel);
            return await _mediator.SendCommandAsync(registerCommand, cancellationToken);
        }

        public async Task<ValidationResult> Update(CategoryViewModel categoryViewModel, CancellationToken cancellationToken)
        {
            var registerCommand = _mapper.Map<UpdateCategoryCommand>(categoryViewModel);
            return await _mediator.SendCommandAsync(registerCommand, cancellationToken);
        }

        public async Task<ValidationResult> Remove(Guid id, CancellationToken cancellationToken)
        {
            var removeCommand = new RemoveCategoryCommand(id);
            return await _mediator.SendCommandAsync(removeCommand, cancellationToken);
        }
    }
}
