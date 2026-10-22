namespace TicketAssistant;

internal class TicketService
{
    private readonly List<SupportTicket> _supportTickets = [];

    public void Add(SupportTicket supportTicket)
    {
        if (supportTicket == null)
        {
            throw new ArgumentNullException(nameof(supportTicket), "Ticket cannot be null.");
        }
        if (_supportTickets.Contains(supportTicket))
        {
            throw new InvalidOperationException("Ticket has already been added.");
        }
        _supportTickets.Add(supportTicket);
    }

    public List<SupportTicket> GetAll()
    {
        return new List<SupportTicket>(_supportTickets);
    }

    public SupportTicket GetById(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Given Id is empty.", nameof(id));
        }

        foreach (SupportTicket ticket in _supportTickets)
        {
            if (ticket.Id == id)
            {
                return ticket;
            }
        }

        throw new TicketNotFoundException(id);
    }

    public void Resolve(Guid id)
    {
        SupportTicket ticket = GetById(id);
        ticket.Resolve();
    }
}
