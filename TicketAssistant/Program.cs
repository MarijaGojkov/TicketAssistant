using TicketAssistant;

SupportTicket ticket = new SupportTicket("Marija", "Can't book an appointment", Category.Other, Priority.High);

Console.WriteLine(ticket.Status);
ticket.Resolve();
Console.WriteLine(ticket.Status);

