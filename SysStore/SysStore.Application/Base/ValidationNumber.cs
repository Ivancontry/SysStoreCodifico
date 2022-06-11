using System;
using System.ComponentModel.DataAnnotations;

namespace SysStore.Application.Base
{
    public static class ValidationNumber
    {
        public static bool IsNumberValid(this decimal value)
        {
            var expression = new RegularExpressionAttribute("^[0]([.,][0-9]{1,3})?$");
            return expression.IsValid(value);
        }
    }
}
