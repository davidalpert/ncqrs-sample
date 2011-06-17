using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleTwitter.Events;
using Ncqrs.Eventing.Denormalization;

namespace SimpleTwitter.ReadModel.Denormalizer
{
	public class TweetListItemDenormalizer : IDenormalizer<TweetPostedEvent>
	{
		public void DenormalizeEvent( TweetPostedEvent evnt )
		{
		}

		public void Handle( TweetPostedEvent evnt )
		{
			var context = new ReadModelDataContext();

			var newItem = new TweetListItem
			{
				Id = evnt.AggregateRootId,
				Message = evnt.Message,
				Who = evnt.Who,
				TimeStamp = evnt.TimeStamp
			};

			context.TweetListItems.InsertOnSubmit( newItem );
			context.SubmitChanges();
		}
	}
}
