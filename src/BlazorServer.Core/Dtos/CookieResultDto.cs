
namespace BlazorServer.Core.Dtos;

public class CookieResultDto
{
  public CookieContainerDto? Data { get; set; }

  public CookieErrorDto[]? Errors { get; set; }
}
