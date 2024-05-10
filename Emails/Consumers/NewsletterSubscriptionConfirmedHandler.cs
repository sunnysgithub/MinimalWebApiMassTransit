using MassTransit;
using MinimalWebApiMassTransit.Emails.Events;

namespace MinimalWebApiMassTransit.Emails.Consumers;

public class NewsletterSubscriptionConfirmedHandler(ILogger<NewsletterSubscriptionConfirmedHandler> logger) : IConsumer<NewsletterSubscriptionConfirmed>
{
    public Task Consume(ConsumeContext<NewsletterSubscriptionConfirmed> context)
    {
        logger.LogInformation("Newsletter subscription confirmed");
        return Task.CompletedTask;
    }
}