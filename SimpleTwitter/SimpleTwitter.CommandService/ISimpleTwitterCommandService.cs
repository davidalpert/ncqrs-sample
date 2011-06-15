using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SimpleTwitter.Commands;

namespace SimpleTwitter.CommandService
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISimpleTwitterCommandService" in both code and config file together.
	[ServiceContract]
	public interface ISimpleTwitterCommandService
	{
		[OperationContract]
		void Excecute(PostNewTweetCommand command);
	}
}
