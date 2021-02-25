using System;

namespace back_template_mongo.BLL.Exceptions
{
  public class  CannotDeleteException : ApplicationException
  {
    public CannotDeleteException(string message) : base(message)
    {
    }
  }
}