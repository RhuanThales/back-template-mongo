using System;

namespace back_template_mongo.BLL.Exceptions
{
  public class  IncorrectPasswordException : ApplicationException
  {
    public IncorrectPasswordException(string message) : base(message)
    {
    }
  }
}