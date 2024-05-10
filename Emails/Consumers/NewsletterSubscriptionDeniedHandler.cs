using MassTransit;
using MinimalWebApiMassTransit.Emails.Events;

namespace MinimalWebApiMassTransit.Emails.Consumers;

public class NewsletterSubscriptionDeniedHandler(ILogger<NewsletterSubscriptionDeniedHandler> logger) : IConsumer<NewsletterSubscriptionDenied>
{
    public Task Consume(ConsumeContext<NewsletterSubscriptionDenied> context)
    {
        logger.LogInformation("Newsletter subscription denied");
        return Task.CompletedTask;
    }
}