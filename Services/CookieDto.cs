
namespace Services
{
    public class CookieDto
    {
        public int Id { get; }

        public string Message { get; }

        public CookieDto(int id, string message)
        {
            Id = id;
            Message = message;
        }
    }
}
