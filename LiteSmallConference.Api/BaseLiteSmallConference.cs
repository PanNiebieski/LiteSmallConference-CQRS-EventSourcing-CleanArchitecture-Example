using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace LiteSmallConference.Api
{
    public class BaseLiteSmallConference : Controller
    {
        protected virtual MethodFailureResult MethodFailure([ActionResultObjectValue] object value)
        {
            return new MethodFailureResult(value);
        }
    }

    public class MethodFailureResult : ObjectResult
    {
        private const int DefaultStatusCode = 420;

        /// <summary>
        /// Creates a new <see cref="NotFoundObjectResult"/> instance.
        /// </summary>
        /// <param name="value">The value to format in the entity body.</param>
        public MethodFailureResult([ActionResultObjectValue] object value)
            : base(value)
        {
            StatusCode = DefaultStatusCode;
        }
    }
}
