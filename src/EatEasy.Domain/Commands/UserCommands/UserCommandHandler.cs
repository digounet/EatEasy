using EatEasy.Domain.Core.Messaging;
using MediatR;
using EatEasy.Domain.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace EatEasy.Domain.Commands.UserCommands
{
    public class UserCommandHandler : CommandHandler,
        IRequestHandler<RegisterUserCommand, ValidationResult>,
        IRequestHandler<LoginUserCommand, ValidationResult>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ValidationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            if (await _userManager.FindByNameAsync(request.CPF) != null)
            {
                AddError("Já existe um usuário com o CPF informado.");
                return ValidationResult;
            }

            var entity = new User
            {
                CPF = request.CPF,
                UserName = request.CPF,
                Email = request.Email,
                Id = Guid.NewGuid().ToString(),
                Name = request.Name
            };

           var addResponse = await _userManager.CreateAsync(entity, request.Password);

           if (addResponse.Succeeded)
           {
               await _userManager.AddToRoleAsync(entity, request.Role);
           }
           else
           {
               foreach (var addResponseError in addResponse.Errors)
               {
                   AddError(addResponseError.Description);
               }
           }
            return ValidationResult;
        }

        
        public void Dispose()
        {
            _userManager.Dispose();
        }

        public async Task<ValidationResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(request.CPF, request.Password, false, false);
            if (!result.Succeeded)
            {
                AddError("Tentativa de login inválida.");
                return ValidationResult;
            }

            return ValidationResult;
        }
    }
}
