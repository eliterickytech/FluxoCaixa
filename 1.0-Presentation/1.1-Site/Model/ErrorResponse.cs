using System.Net;

namespace Site.Model
{
	public class ErrorResponse
	{
		public HttpStatusCode StatusCode { get; set; }

		public string Message { get; set; }
	}
}
