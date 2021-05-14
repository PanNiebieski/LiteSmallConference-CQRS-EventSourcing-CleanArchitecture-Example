using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace LiteSmallConference.Application.Common
{
    public abstract class BaseResponse
    {
        public ResponseStatus Status { get; set; }

        public bool Success { get; set; }
        public string Message { get; set; }

        public List<string> ValidationErrors { get; set; }


        protected BaseResponse()
        {
            ValidationErrors = new List<string>();
            Success = true;
            Status = ResponseStatus.Success;
        }

        protected BaseResponse(string message = null)
        {
            ValidationErrors = new List<string>();
            Success = true;
            Message = message;
            Status = ResponseStatus.Success;
        }

        protected BaseResponse(string message, bool success)
        {
            ValidationErrors = new List<string>();
            Success = success;
            Message = message;
        }

        protected BaseResponse(ResponseStatus status)
        {
            ValidationErrors = new List<string>();
            Success = status != ResponseStatus.Success;
            Status = status;
        }

        protected BaseResponse(ValidationResult validationResult)
        {
            ValidationErrors = new List<String>();
            Success = validationResult.Errors.Count < 0;
            foreach (var item in validationResult.Errors)
            {
                ValidationErrors.Add(item.ErrorMessage);
            }

            if (!Success)
                Status = ResponseStatus.ValidationError;
            else
                Status = ResponseStatus.Success;
        }

        public string StatusInfo
        {
            get
            {
                return Status.ToString();
            }
        }

        public WhatHTTPCodeShouldBeRetruned WhatHTTPCodeToBeRetruned
        {
            get
            {
                if (this.Status == ResponseStatus.BussinesLogicError)
                    return WhatHTTPCodeShouldBeRetruned.Forbid;
                if (this.Status == ResponseStatus.NotFoundInDataBase)
                    return WhatHTTPCodeShouldBeRetruned.NotFound;
                if (this.Status == ResponseStatus.ValidationError ||
                    this.Status == ResponseStatus.BadQuery ||
                    this.Status == ResponseStatus.ConcurrencyOlderVersionSendedWhenNewerIsInEventStore)
                    return WhatHTTPCodeShouldBeRetruned.BadRequest;
                if (!this.Success)
                    return WhatHTTPCodeShouldBeRetruned.BadRequest;
                else
                    return WhatHTTPCodeShouldBeRetruned.Ok;
            }
        }
    }
}
