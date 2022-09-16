
namespace BlazorServer.Web.Api.Wcf.Services;

[DataContract]
public class CookieFault
{
  [DataMember]
  [AllowNull]
  public string Text { get; set; }
}

[DataContract]
public class CookieResponse
{
  [DataMember]
  public int Id { get; set; }

  [DataMember]
  public string Message { get; set; }
}

[ServiceContract]
public interface ICookieService
{
  [OperationContract]
  Task<CookieResponse> GetRandomCookie();
}
