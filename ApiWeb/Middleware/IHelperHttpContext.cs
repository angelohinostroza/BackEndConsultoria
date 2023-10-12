using CommonModels;

namespace ApiWeb.Middleware
{
    public interface IHelperHttpContext : IDisposable
    {
        public InfoRequest GetInfoRequest(HttpContext request);
    }
}
