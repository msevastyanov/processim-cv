using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProcessSIM.ServiceLayer.Models;

namespace ProcessSIM.Application.Extensions
{
    public static class RequestResultExtensions
    {
        public static JsonResult ToJsonResult(this RequestResult result)
        {
            if (result.Succeeded)
            {
                return new JsonResult(new
                {
                    status = "success"
                });
            }
            else
            {
                return new JsonResult(new
                {
                    status = "fail",
                    message = result.Errors.First()
                });
            }
        }

        public static JsonResult ToJsonResult<T>(this RequestResult<T> result)
        {
            if (result.Succeeded)
            {
                return new JsonResult(new
                {
                    status = "success",
                    data = result.Content
                });
            }
            else
            {
                return new JsonResult(new
                {
                    status = "fail",
                    message = result.Errors.First()
                });
            }
        }
    }
}