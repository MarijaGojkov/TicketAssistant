using TicketAssistant;

SupportTicket ticket1 = new SupportTicket("Marija", "Can't proceed payment", Category.Payment, Priority.High);
SupportTicket ticket2 = new SupportTicket("Dusan", "Can't cancel the appointment", Category.Other, Priority.High);
SupportTicket ticket3 = new SupportTicket("Isac", "Can't log out", Category.Other, Priority.Medium);
SupportTicket ticket4 = new SupportTicket("Mirjana", "Can't open menu", Category.Menu, Priority.Low);
SupportTicket ticket5 = new SupportTicket("Dragana", "Can't log in", Category.Authentication, Priority.High);
SupportTicket ticket6 = new SupportTicket("Dragana", "Can't log in", Category.Authentication, Priority.High);
TicketService service = new TicketService();
service.Add(ticket1);
service.Add(ticket2);
service.Add(ticket3);
service.Add(ticket4);
service.Add(ticket5);
service.Add(ticket6);

List<SupportTicket> all = service.GetAll();
Console.WriteLine($"Before clear. Number of tickets: {service.GetAll().Count}");
all.Clear();
Console.WriteLine($"After clear. Number of tickets: {service.GetAll().Count}");

Guid testId = Guid.NewGuid();
//service.GetById(testId);

service.Resolve(ticket2.Id);
Console.WriteLine($"Ticket 2 status: {ticket2.Status}");

List<SupportTicket> resolved = service.GetByStatus(Status.Resolved);
Console.WriteLine($"Resolved: {resolved.Count}");

List<SupportTicket> unresolved = service.GetUnresolvedByPriority();
Console.WriteLine($"Unresolved: {unresolved.Count}");

service.Resolve(ticket1.Id);
service.Resolve(ticket3.Id);
service.Resolve(ticket4.Id);
service.Resolve(ticket5.Id);

List<SupportTicket> pending = service.GetByStatus(Status.Pending);
if (pending.Count == 0)
{
    Console.WriteLine("No tickets found.");
}
else
{
    Console.WriteLine($"Pending: {pending.Count}");
}
