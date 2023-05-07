using System.Text.RegularExpressions;
namespace MeLevaAi.Api.Validations
{
  public class StringValidation
  {

    public static bool IsValidEmail(string value)
    {
      return new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Match(value).Success;
    }
  }
}