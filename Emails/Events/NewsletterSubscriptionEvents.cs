namespace MinimalWebApiMassTransit.Emails.Events;

public record NewsletterSubscriptionConfirmed(Guid SubscriberId, string EmailAddress);

public record NewsletterSubscriptionDenied(string EmailAddress);