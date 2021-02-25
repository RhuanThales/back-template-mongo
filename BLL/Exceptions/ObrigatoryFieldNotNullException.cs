using System;

namespace back_template_mongo.BLL.Exceptions
{
  public class  ObrigatoryFieldNotNullException : ApplicationException
  {
    public ObrigatoryFieldNotNullException(string message) : base(message)
    {
    }
  }
}