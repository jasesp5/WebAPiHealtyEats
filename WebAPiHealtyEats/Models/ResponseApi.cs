using System.Net;

namespace WebAPiHealtyEats.Models
{
    
    public class ResponseApi
    {
        public ResponseApi()
        {
            ErrorMessages = new List<string>();
        }

        public HttpStatusCode StatusCode { get; set; }

        public bool IsSucess { get; set; } = true;

        public List<string> ErrorMessages { get; set; }

        public Object Result { get; set; }

    }
}

