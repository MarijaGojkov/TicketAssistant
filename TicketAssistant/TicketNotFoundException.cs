namespace TicketAssistant;

internal class TicketNotFoundException : Exception
{
    public TicketNotFoundException(Guid id)
        : base($"Ticket with id {id} does not exist.") // before running the constructor, call parent constructor 
    {
    }
}
