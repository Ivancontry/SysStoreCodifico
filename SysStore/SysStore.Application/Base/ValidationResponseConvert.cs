﻿using System.Linq;
using FluentValidation;
using SysStore.Domain.Base;
namespace SysStore.Application.Base
{
    public static class ValidationResponseConvert
    {

        public static void ToValidationFailure<T>(this DomainValidation validation, ValidationContext<T> context)
        {
            var failures = validation.Fallos.ToList();
            failures.ForEach(error =>
            {
                context.AddFailure(error.Key, error.Value);
            });
        }
    }
}
