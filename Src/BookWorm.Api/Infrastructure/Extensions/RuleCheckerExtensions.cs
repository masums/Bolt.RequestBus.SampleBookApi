using System.Collections.Generic;
using System.Linq;
using Bolt.Common.Extensions;
using Bolt.RequestBus;
using Bolt.Validation;

namespace BookWorm.Api.Infrastructure.Extensions
{
    public static class RuleCheckerExtensions
    {
        public static IEnumerable<IError> ToRequestValidationErrors<T>(this RuleChecker<T> checker) where T : class 
        {
            return checker.Result().Errors.NullSafe().Select(x => new Error(x.ErrorCode, x.PropertyName, x.ErrorMessage));
        } 
    }
}