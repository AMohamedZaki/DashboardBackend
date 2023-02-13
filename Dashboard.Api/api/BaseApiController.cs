using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Zanobia.Helper;

namespace Zanobia.Api.api
{
    public class BaseApiController : Controller
    {

        protected async Task<IActionResult> Execute<Tin, Tout>(Func<Tin, Task<Tout>> ExecutionDelegate, Tin inputEntity, string successResponseMessage = "")
        {

            Tout result;
            var baseResponse = new BaseResponse<object>();
            try
            {
                result = await ExecutionDelegate(inputEntity);
                if (result != null)
                {
                    baseResponse.Data = result;
                    if (result.GetType().Name.Contains(nameof(PagedList<Tout>)))
                    {
                        baseResponse.TotalRecords = ((dynamic)result).Count;
                    }
                    baseResponse.ResponseMessage = string.IsNullOrEmpty(successResponseMessage) ? "Data Sent Successfully" : successResponseMessage;
                    return Ok(baseResponse);
                }
                else
                {
                    baseResponse.ResponseMessage = "Please check request data again.";
                    return Ok(baseResponse);
                }
            }
            catch (Exception ex)
            {
                baseResponse.Data = null;
                baseResponse.ResponseMessage = ex.Message;
                baseResponse.StatusCode = StatusCodes.Status400BadRequest;
                // this change is for now later we will log the error in file txt using nolg
                return Ok(baseResponse);
            }
        }
    }
}
