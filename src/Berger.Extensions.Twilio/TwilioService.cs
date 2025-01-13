using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;

namespace Berger.Extensions.Twilio
{
	public class TwilioService
	{
		private readonly string _accountSid;
		private readonly string _authToken;
		private readonly string _sender;

		public TwilioService(string accountSid, string authToken, string sender)
		{
			_accountSid = accountSid;
			_authToken = authToken;
			_sender = sender;
		}
		public async Task<MessageResource> Send(string receiver, string body)
		{
			TwilioClient.Init(_accountSid, _authToken);

			var messageOptions = new CreateMessageOptions(new PhoneNumber(receiver))
			{
				From = new PhoneNumber(_sender),
				Body = body
			};

			return await MessageResource.CreateAsync(messageOptions);
		}
	}
}