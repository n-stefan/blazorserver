﻿
namespace Services
{
    public class CookieDto
    {
        public int Id { get; }

        public string Message { get; }

        public string Error { get; }

        public const string CookieNotFound = "Cookie not found.";

        public const string AnErrorOccurred = "An error occurred.";

        public CookieDto(string error)
        {
            Error = error;
        }

        public CookieDto(int id, string message)
        {
            Id = id;
            Message = message;
        }
    }
}
