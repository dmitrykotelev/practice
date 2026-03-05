using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4ModelBase.Database.DbManager
{
    public class Error
    {
        public ResponceStatus Status;
        public string Message;

        public Error()
        {
            Status = ResponceStatus.Success;
        }
        public Error(ResponceStatus status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}
