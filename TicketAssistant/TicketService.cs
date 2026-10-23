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

        // TODO: check by Id instead of reference once tickets come from a database (if (_supportTickets.Any(t => t.Id == supportTicket.Id)))
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

        SupportTicket? ticket = _supportTickets.FirstOrDefault(t => t.Id == id);

        if (ticket == null)
        {
            throw new TicketNotFoundException(id);
        }

        return ticket;
    }

    public void Resolve(Guid id)
    {
        SupportTicket ticket = GetById(id);
        ticket.Resolve();
    }

    public List<SupportTicket> GetByStatus(Status status)
    {
        return _supportTickets.Where(t => t.Status == status).ToList();
    }

    public List<SupportTicket> GetUnresolvedByPriority()
    {
        return _supportTickets.Where(t => t.Status != Status.Resolved).OrderBy(t => t.Priority).ToList();
    }
}
