using System.Runtime.InteropServices;
using TicketAssistant;

SupportTicket ticket1 = new SupportTicket("Marija", "Can't proceed payment", Category.Payment, Priority.High);
SupportTicket ticket2 = new SupportTicket("Dusan", "Can't cancel the appointment", Category.Other, Priority.High);
SupportTicket ticket3 = new SupportTicket("Isac", "Can't log out", Category.Other, Priority.Medium);
SupportTicket ticket4 = new SupportTicket("Mirjana", "Can't open menu", Category.Menu, Priority.Low);
SupportTicket ticket5 = new SupportTicket("Dragana", "Can't log in", Category.Authentication, Priority.High);

TicketService service = new TicketService();
service.Add(ticket1);
service.Add(ticket2);
service.Add(ticket3);
service.Add(ticket4);
service.Add(ticket5);


ticket1.Resolve();
ticket3.Resolve();

List<SupportTicket> all = service.GetAll();
Console.WriteLine(service.GetAll().Count);
all.Clear();
Console.WriteLine(service.GetAll().Count);

service.GetById(ticket2.Id);

Guid testId = Guid.NewGuid();

//service.GetById(testId);

service.Resolve(ticket2.Id);
Console.WriteLine(ticket2.Status);

service.Resolve(ticket2.Id);
Console.WriteLine(ticket2.Status);
