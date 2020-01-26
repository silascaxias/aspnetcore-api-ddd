using System.Net;

namespace Api.Application.ViewModels.Response
{
    public enum ResponseStatusEnum
    {
        Success = HttpStatusCode.OK,
        Created = HttpStatusCode.Created,
        Error = HttpStatusCode.InternalServerError,
        BadRequest = HttpStatusCode.BadRequest,
        Unauthorized = HttpStatusCode.Unauthorized,
        NotFound = HttpStatusCode.NotFound,
        NoModified = HttpStatusCode.NotModified,
        Unprocessable = HttpStatusCode.UnprocessableEntity,
        Forbidden = HttpStatusCode.Forbidden,
        Conflict = HttpStatusCode.Conflict
    }
}