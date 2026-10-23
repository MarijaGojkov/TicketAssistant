namespace TicketAssistant;

internal class SupportTicket
{
    public Guid Id { get; }
    public string User { get; }
    public string Description { get; private set; }
    public Category Category { get; private set; }
    public Status Status { get; private set; }
    public DateTime CreatedAt { get; }
    public Priority Priority { get; private set; }

    public SupportTicket(string user, string description, Category category, Priority priority)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("Description is needed.", nameof(description));
        }

        Id = Guid.NewGuid();
        User = user;
        Description = description;
        Category = category;
        Status = Status.Pending;
        CreatedAt = DateTime.Now;
        Priority = priority;
    }

    public void Resolve()
    {
        if (Status == Status.Resolved)
        {
            throw new InvalidOperationException("This ticket is already resolved.");
        }

        Status = Status.Resolved;
    }
}
