class TicketStorage
{
    public Dictionary<int, Ticket> tickets;
    public int ticketIdCounter = 1;


    public TicketStorage()
    {
        Ticket ticket1 = new(1, "Speeding", 205.00, 205.00, false, 0); 
        Ticket ticket2 = new(2, "Failure to Yeild Right of Way", 50.00, 25.00, false, 0);
        Ticket ticket3 = new(3, "SeltBelt Violation", 30.85, 30.85, false, 0); ticketIdCounter++;
        tickets = new();
        tickets.Add(1, ticket1);
        tickets.Add(ticket2.ticketId, ticket2);
        tickets.Add(ticket3.ticketId, ticket3);
    }
}