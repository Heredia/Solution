using Model.Enums;
using System;

namespace Model.Models
{
    public class UserLogModel
    {
        public UserLogModel(long userId, LogType logType, string message = null)
        {
            UserId = userId;

            LogType = logType;

            Message = message;

            DateTime = DateTime.Now;
        }

        public DateTime DateTime { get; set; }

        public LogType LogType { get; set; }

        public string Message { get; set; }

        public long UserId { get; set; }

        public long UserLogId { get; set; }
    }
}