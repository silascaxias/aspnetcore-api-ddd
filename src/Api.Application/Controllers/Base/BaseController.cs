using Api.Application.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers.Base
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        public BaseController() {}

        public override OkObjectResult Ok(object result)
        {
            if (!(result is BaseResponse))
            {
                return base.Ok(result.AsSuccessResponse());
            }
            return base.Ok(result);
        }

        public override UnprocessableEntityObjectResult UnprocessableEntity(object error)
        {
            if (!(error is BaseResponse))
            {
                return base.UnprocessableEntity(error.AsUnprocessableResponse());
            }
            return base.UnprocessableEntity(error);
        }
    }
}