using AutoRespect.Shared.Errors.Design;

namespace AutoRespect.Shared.Errors.DataTransfer
{
    public class ServerError : Error
    {
        public ServerError() : base("3DD50389-301C-43CD-BB08-75B9D50D2AFE", "Server error") //TODO: make better description ...
        {
        }
    }
}