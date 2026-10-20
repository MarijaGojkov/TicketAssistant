using TicketAssistant;

SupportTicket ticket1 = new SupportTicket("Marija", "Can't proceed payment", Category.Payment, Priority.High);
SupportTicket ticket2 = new SupportTicket("Dusan", "Can't cancel the appointment", Category.Other, Priority.High);
SupportTicket ticket3 = new SupportTicket("Isac", "Can't log out", Category.Other, Priority.Medium);
SupportTicket ticket4 = new SupportTicket("Mirjana", "Can't open menu", Category.Menu, Priority.Low);
SupportTicket ticket5 = new SupportTicket("Dragana", "Can't log in", Category.Authentication, Priority.High);

List<SupportTicket> tickets = new List<SupportTicket>() { ticket1, ticket2, ticket3, ticket4, ticket5 };

ticket1.Resolve();
ticket3.Resolve();

foreach (SupportTicket ticket in tickets)
{
    if (ticket.Priority == Priority.High && ticket.Status != Status.Resolved)
    {
        Console.WriteLine(ticket.Description);
    }
}


