
namespace BlazorServer.Core.Dtos;

public class CookieDto
{
  public int Id { get; set; }

  public string? Message { get; set; }

  public string? Error { get; }

  public const string CookieNotFound = "Cookie not found.";

  public const string AnErrorOccurred = "An error occurred.";

  public CookieDto() { }

  public CookieDto(string? error) =>
    Error = error;

  public CookieDto(int id, string? message)
  {
    Id = id;
    Message = message;
  }
}
