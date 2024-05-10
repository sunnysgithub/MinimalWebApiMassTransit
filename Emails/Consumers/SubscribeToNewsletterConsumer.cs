using MassTransit;
using MinimalWebApiMassTransit.Emails.Commands;
using MinimalWebApiMassTransit.Emails.Events;

namespace MinimalWebApiMassTransit.Emails.Consumers;

public class SubscribeToNewsletterConsumer : IConsumer<SubscribeToNewsletter>
{
    public async Task Consume(ConsumeContext<SubscribeToNewsletter> context)
    {
        var emailAddress = context.Message.EmailAddress;
        if (string.IsNullOrEmpty(emailAddress) || emailAddress.Contains("test"))
        {
            await context.Publish(new NewsletterSubscriptionDenied(emailAddress));
            return;
        }
        await context.Publish(new NewsletterSubscriptionConfirmed(Guid.NewGuid(), emailAddress));
    }
}