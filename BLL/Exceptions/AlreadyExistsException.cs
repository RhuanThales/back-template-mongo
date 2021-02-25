using System;

namespace back_template_mongo.BLL.Exceptions
{
  public class  AlreadyExistsException : ApplicationException
  {
    public AlreadyExistsException(string message) : base(message)
    {
    }
  }
}