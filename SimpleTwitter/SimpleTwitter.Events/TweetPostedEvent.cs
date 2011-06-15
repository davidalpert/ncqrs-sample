using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Domain;

namespace SimpleTwitter.Events
{
    [Serializable]
    public class TweetPostedEvent : DomainEvent
    {
        public string Message { get; set; }
        public string Who { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
