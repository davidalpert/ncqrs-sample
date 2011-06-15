using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SimpleTwitter.Commands;
using Ncqrs;
using Ncqrs.Commanding.ServiceModel;
using SimpleTwitter.CommandExecutors;
using Ncqrs.Eventing.Storage;
using Ncqrs.Eventing.Storage.SQL;

namespace SimpleTwitter.CommandService
{
    public static class Bootstrapper
    {
        public static void Bootstrap()
        {
            NcqrsEnvironment.SetDefault<ICommandService>(InitializeCommandService());
        }

        private static IEventStore InitializeEventStore()
        {
            return new SimpleMicrosoftSqlServerEventStore("Data Source=.\\SQLEXPRESS;Integrated Security=SSPI;User Instance=True;AttachDbFilename=|DataDirectory|\\EventStore.mdf;");
        }

        private static ICommandService InitializeCommandService()
        {
            var service = new InProcessCommandService();
            service.RegisterExecutor(new PostNewTweetCommandExecutor());
            return service;
        }
    }
}
