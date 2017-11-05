using AutoRespect.Infrastructure.ErrorHandling;

namespace AutoRespect.Shared.Errors.Common
{
    public class ServerError : Error
    {
        public ServerError() : base("3DD50389-301C-43CD-BB08-75B9D50D2AFE", "Server error") //TODO: make better description ...
        {
        }
    }
}