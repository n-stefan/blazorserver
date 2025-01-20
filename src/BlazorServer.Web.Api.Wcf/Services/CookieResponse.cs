
namespace BlazorServer.Web.Api.Wcf.Services;

[DataContract]
public class CookieResponse
{
  [DataMember]
  public int Id { get; set; }

  [DataMember]
  public string? Message { get; set; }
}
