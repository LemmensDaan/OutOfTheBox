using MediatR;
using Microsoft.AspNetCore.Mvc;
using OutOfTheBox.Web.Base;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace OutOfTheBox.Web.Controllers
{
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    public class ApiControllerBase : ControllerBase
    {
        private readonly IMediator _mediator;
        private HttpStatusCode _statusCode = HttpStatusCode.OK;

        public ApiControllerBase(IMediator mediator)
        {
            this._mediator = mediator ?? throw new ArgumentNullException();
        }

        #region Execute requests
        protected async Task<IActionResult> ExecutePostRequest<T>(IRequest<T> request)
        {
            _statusCode = HttpStatusCode.Created;
            return await ExecuteRequest<T>(request);
        }
        protected async Task<IActionResult> ExecutePutRequest<T>(IRequest<T> request)
        {
            _statusCode = HttpStatusCode.OK;
            return await ExecuteRequest<T>(request);
        }
        protected async Task<IActionResult> ExecuteDeleteRequest<T>(IRequest<T> request)
        {
            _statusCode = HttpStatusCode.OK;
            return await ExecuteRequest<T>(request);
        }
        #endregion

        protected async Task<IActionResult> ExecuteRequest<T>(IRequest<T> request)
        {
            var response = new Response<T>();
            try
            {
                if (request == null) throw new NullReferenceException("The received request cannot be null");
                var result = await _mediator.Send(request);
                response = new Response<T>(_statusCode, result);
                return StatusCode((int)_statusCode, response);
            }
            catch (NullReferenceException nex)
            {
                _statusCode = HttpStatusCode.BadRequest;
                response = new Response<T>(_statusCode, "OOps, Stoelendans has the hickups", new string[] { nex.Message });
            }
            catch (ValidationException vex)
            {
                _statusCode = HttpStatusCode.BadRequest;
                response = new Response<T>(_statusCode, "OOps, nice try", new string[] { vex.Message });
            }
            catch (Exception ex)
            {
                _statusCode = HttpStatusCode.InternalServerError;
                response = new Response<T>(_statusCode, "Try later again", new string[] { ex.Message });
            }

            return StatusCode((int)_statusCode, response);
        }
    }
}
