﻿using EatEasy.Domain.Core.Data;
using FluentValidation.Results;

namespace EatEasy.Domain.Core.Messaging
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AddError(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected void AddErrors(List<ValidationFailure> validationResultErrors)
        {
            validationResultErrors.ForEach(x => AddError(x.ErrorMessage));
        }

        protected async Task<ValidationResult> Commit(IUnitOfWork uow, string message)
        {
            if (!await uow.CommitAsync()) AddError(message);

            return ValidationResult;
        }

        protected async Task<ValidationResult> Commit(IUnitOfWork uow)
        {
            return await Commit(uow, "Ocorreu um erro ao salvar os dados").ConfigureAwait(false);
        }
    }
}
