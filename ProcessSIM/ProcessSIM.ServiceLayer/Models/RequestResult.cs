using System.Collections.Generic;
using System.Linq;

namespace ProcessSIM.ServiceLayer.Models
{
    public class RequestResult
    {
        public List<string> Errors { get; private set; } = new List<string>();

        public bool Succeeded
        {
            get { return !Errors.Any(); }
        }

        public static RequestResult Success()
        {
            return new RequestResult();
        }

        public static RequestResult Failed(params string[] errors)
        {
            return new RequestResult()
            {
                Errors = errors.ToList()
            };
        }
    }

    public class RequestResult<ContentType>
    {
        public List<string> Errors { get; private set; } = new List<string>();

        public bool Succeeded
        {
            get { return !Errors.Any(); }
        }

        public ContentType Content { get; private set; }

        public static RequestResult<ContentType> Success(ContentType content)
        {
            return new RequestResult<ContentType>()
            {
                Content = content
            };
        }

        public static RequestResult<ContentType> Failed(params string[] errors)
        {
            return new RequestResult<ContentType>()
            {
                Errors = errors.ToList()
            };
        }
    }
}