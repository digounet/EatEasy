using EatEasy.Application.Interface;
using EatEasy.Application.ViewModels;
using FluentValidation.Results;
using AutoMapper;
using EatEasy.Domain.Commands.ProductCommands;
using EatEasy.Domain.Core.Mediator;
using EatEasy.Domain.Interfaces;

namespace EatEasy.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IMediatorHandler _mediator;

        public ProductAppService(IMapper mapper, IProductRepository productRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _mediator = mediator;
        }

        public void Dispose()
        {
            _productRepository.Dispose();
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetAllAsync(cancellationToken));
        }

        public async Task<IEnumerable<ProductViewModel>> FindByCategoryAsync(Guid categoryId, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetByCategoryAsync(categoryId, cancellationToken));
        }

        public async Task<ProductViewModel> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return _mapper.Map<ProductViewModel>(await _productRepository.GetByIdAsync(id, cancellationToken));
        }

        public async Task<ValidationResult> RegisterAsync(ProductRegisterViewModel productViewModel, CancellationToken cancellationToken)
        {
            var registerCommand = _mapper.Map<RegisterProductCommand>(productViewModel);
            return await _mediator.SendCommandAsync(registerCommand, cancellationToken);
        }

        public async Task<ValidationResult> Update(ProductUpdateViewModel productViewModel, CancellationToken cancellationToken)
        {
            var registerCommand = _mapper.Map<UpdateProductCommand>(productViewModel);
            return await _mediator.SendCommandAsync(registerCommand, cancellationToken);
        }

        public async Task<ValidationResult> Remove(Guid id, CancellationToken cancellationToken)
        {
            var removeCommand = new RemoveProductCommand(id);
            return await _mediator.SendCommandAsync(removeCommand, cancellationToken);
        }
    }
}
