
namespace BlazorServer.Web.Api.Wcf.Services;

[DataContract]
public class CookieFault
{
  [DataMember]
  [AllowNull]
  public string Text { get; set; }
}
