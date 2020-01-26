namespace Api.Application.ViewModels.Response
{
    public static class GenericResponseExtensions
    {
        public static GenericResponse<object> AsSuccessGenericResponse(this object data)
        {
            return new GenericResponse<object>(data);
        }

        public static GenericResponse<object> AsNoModifieldGenericResponse(this object data)
        {
            return new GenericResponse<object>(data).NoModifield();
        }

        public static GenericResponse<object> AsNotFoundResponse(this object data, string message = null)
        {
            return new GenericResponse<object>(data).NotFound(message);
        }

        public static GenericResponse<object> AsBadRequestResponse(this object data, string message = null)
        {
            return new GenericResponse<object>(data).BadRequest(message);
        }

        public static GenericResponse<object> AsUnprocessableResponse(this object data, string message = null)
        {
            return new GenericResponse<object>(data).UnprocessableRequest(message);
        }

        public static GenericResponse<object> AsSuccessResponse(this object data, string message = null)
        {
            return new GenericResponse<object>(data).Success(message);
        }

        public static GenericResponse<object> AsConflictResponse(this object data, string message = null)
        {
            return new GenericResponse<object>(data).Conflict(message);
        }

        public static GenericResponse<object> AsUnauthorizedResponse(this object data, string message = null)
        {
            return new GenericResponse<object>(data).Unauthorized(message);
        }

        public static GenericResponse<object> AsInternalServerErrorResponse(this object data)
        {
            return new GenericResponse<object>(data).InternalServerError();
        }

        public static GenericResponse<object> AsForbiddenResponse(this object data, string message = null)
        {
            return new GenericResponse<object>(data).Forbidden(message);
        }
    }
}