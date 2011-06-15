using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Domain;
using SimpleTwitter.Events;

namespace SimpleTwitter.Domain
{
    public class Tweet : AggregateRootMappedByConvention
    {
        private string message;
        private string who;
        private DateTime timestamp;

        /// <summary>
        /// Initializes a new instance of the Tweet class.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="who"></param>
        /// <param name="timestamp"></param>
        public Tweet(string message, string who)
        {
            var e = new TweetPostedEvent
            {
                Message = message,
                Who = who,
                TimeStamp = DateTime.UtcNow
            };

            ApplyEvent(e);
        }

        protected void OnTweetPosted(TweetPostedEvent e)
        {
            message = e.Message;
            who = e.Who;
            timestamp = e.TimeStamp;
        }
    }
}
