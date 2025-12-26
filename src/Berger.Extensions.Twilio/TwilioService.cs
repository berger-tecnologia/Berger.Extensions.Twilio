using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;

namespace Berger.Extensions.Twilio
{
	public class TwilioService
	{
		private readonly string _accountSid;
		private readonly string _authToken;
		private readonly string _source;

		public TwilioService(string accountSid, string authToken, string source)
		{
            _source = source;
			_authToken = authToken;
            _accountSid = accountSid;
        }
		public async Task<MessageResource> Send(string target, string body)
		{
			TwilioClient.Init(_accountSid, _authToken);

			var messageOptions = new CreateMessageOptions(new PhoneNumber(target))
			{
				From = new PhoneNumber(_source),
				Body = body
			};

			return await MessageResource.CreateAsync(messageOptions);
		}
	}
}