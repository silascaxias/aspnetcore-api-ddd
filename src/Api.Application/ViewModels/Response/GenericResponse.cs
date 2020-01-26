namespace Api.Application.ViewModels.Response
{
    public class GenericResponse<T> : BaseResponse
    {
        public T Data { get; set; }

        public GenericResponse() {}

        public GenericResponse(T data)
        {
            this.Data = data;
        }

        public virtual GenericResponse<T> Success(string message = null)
        {
            return base.Success<GenericResponse<T>>(message);
        }
        public virtual GenericResponse<T> NotFound(string message = null)
        {
            return base.NotFound<GenericResponse<T>>(message);
        }

        public GenericResponse<T> InternalServerError()
        {
            return base.InternalServerError<GenericResponse<T>>();
        }

        public GenericResponse<T> NoModifield()
        {
            return base.NoModifield<GenericResponse<T>>();
        }

        public GenericResponse<T> Modifield()
        {
            return base.NoModifield<GenericResponse<T>>();
        }

        public GenericResponse<T> BadRequest(string message = null)
        {
            return base.BadRequest<GenericResponse<T>>(message);
        }

        public GenericResponse<T> UnprocessableRequest(string message = null)
        {
            return base.UnprocessableRequest<GenericResponse<T>>(message);
        }
        
        public GenericResponse<T> Forbidden(string message = null)
        {
            return base.Forbidden<GenericResponse<T>>(message);
        }

        public GenericResponse<T> Conflict(string message)
        {
            return base.Conflict<GenericResponse<T>>(message);
        }

        public GenericResponse<T> Unauthorized(string message)
        {
            return base.Unauthorized<GenericResponse<T>>(message);
        }
    }
}