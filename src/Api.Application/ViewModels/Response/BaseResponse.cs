using System;

namespace Api.Application.ViewModels.Response
{
    public class BaseResponse
    {
        public string Message { get; set; }

        public BaseResponse()
        {
            this.Message = ResponseMessages.Messages[ResponseStatusEnum.Success];
        }
        public T Success<T>(string message = null) where T : BaseResponse
        {
            this.Message = message ?? ResponseMessages.Messages[ResponseStatusEnum.Success];
            return (T)this;
        }
         public T NotFound<T>(string message = null) where T : BaseResponse
        {
            this.Message = message ?? ResponseMessages.Messages[ResponseStatusEnum.NotFound];
            return (T)this;
        }

        public T InternalServerError<T>() where T : BaseResponse
        {
            this.Message = ResponseMessages.Messages[ResponseStatusEnum.Error];
            return (T)this;
        }

        public T Error<T>(string message) where T : BaseResponse
        {
            this.Message = message;
            return (T)this;
        }

        public T NoModifield<T>(string message = null) where T : BaseResponse
        {
            this.Message = message ?? ResponseMessages.Messages[ResponseStatusEnum.NoModified];
            return (T)this;
        }

        public T BadRequest<T>(string message = null) where T : BaseResponse
        {
            this.Message = message ?? ResponseMessages.Messages[ResponseStatusEnum.BadRequest];
            return (T)this;
        }

        public T UnprocessableRequest<T>(string message = null) where T : BaseResponse
        {
            this.Message = message ?? ResponseMessages.Messages[ResponseStatusEnum.Unprocessable];
            return (T)this;
        }

        public T Forbidden<T>(string message = null) where T : BaseResponse
        {
            this.Message = message ?? ResponseMessages.Messages[ResponseStatusEnum.Forbidden];
            return (T)this;
        }
        
        public T Unauthorized<T>(string message = null) where T : BaseResponse
        {
            this.Message = message ?? ResponseMessages.Messages[ResponseStatusEnum.Unauthorized];
            return (T)this;
        }

        public T Conflict<T>(string message) where T : BaseResponse
        {
            this.Message = message ?? ResponseMessages.Messages[ResponseStatusEnum.Conflict];
            return (T)this;
        }
    }
}