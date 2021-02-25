using System;

namespace back_template_mongo.BLL.Exceptions
{
    public class  IntegrityException : ApplicationException
    {
        public IntegrityException(string message) : base(message)
        {
        }
    }

}