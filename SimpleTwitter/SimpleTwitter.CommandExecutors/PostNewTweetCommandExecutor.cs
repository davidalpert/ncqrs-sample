using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding.CommandExecution;
using SimpleTwitter.Commands;
using Ncqrs.Domain;
using SimpleTwitter.Domain;

namespace SimpleTwitter.CommandExecutors
{
	public class PostNewTweetCommandExecutor : CommandExecutorBase<PostNewTweetCommand>
	{
		protected override void ExecuteInContext( IUnitOfWorkContext context, PostNewTweetCommand command )
		{
			var newTweet = new Tweet( command.Message, command.Who );

			context.Accept();
		}
	}
}
