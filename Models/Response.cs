using System.Collections.Generic;

namespace Backend.Api.Models
{
    public class Response
    {
        public string Message { get; set; } = "";
        public object Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorMessage { get; set; }
    }
}
