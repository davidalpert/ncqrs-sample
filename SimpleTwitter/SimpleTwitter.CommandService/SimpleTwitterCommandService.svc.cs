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

namespace SimpleTwitter.CommandService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SimpleTwitterCommandService" in code, svc and config file together.
    public class SimpleTwitterCommandService : ISimpleTwitterCommandService
    {
        static SimpleTwitterCommandService()
        {
            Bootstrapper.Bootstrap();
        }

        public void Excecute(PostNewTweetCommand command)
        {
            var svc = NcqrsEnvironment.Get<ICommandService>();
            svc.Execute(command);
        }
    }
}
