using Microsoft.AspNetCore.SignalR;
using TestProject.DTO;

namespace TestProject.Models
{
    public class GeneralResponses
    {
        public bool Authenticated { get; set; }
        public string Message { get; set; }
        public bool IsError { get; set; }
        public GeneralContent Content { get; set; }
    }

    public class DetailContent
    {
        public string Message { get; set; }
        public bool IsError { get; set; }
    }
    public class GeneralContent
    {
        public DetailContent Detail { get; set; }
        public List<UserDTO> ListUser { get; set; }
        public UserDTO DetailUser { get; set; }

        public string Token { get; set; }
    }
}
