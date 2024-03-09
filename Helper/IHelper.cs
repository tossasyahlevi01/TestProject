using TestProject.DTO;

namespace TestProject.Helper
{
    public interface IHelper
    {
        public Task<(string Token, bool cek)> GenerateToken2(UserLogonDTO Entity);

    }
}
