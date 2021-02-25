using System;

namespace back_template_mongo.BLL.Exceptions
{
  public class  PasswordLengthException : ApplicationException
  {
    public PasswordLengthException(string message) : base(message)
    {
    }
  }
}