using CommonModels;

namespace ApiConsultoria.Middleware
{
    public interface IHelperHttpContext : IDisposable
    {
        public InfoRequest GetInfoRequest(HttpContext request);
    }
}
