using ParkingLotManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.Repository
{
    internal class TicketRepository
    {
        private Dictionary<long, Ticket> ticketRepository;
        private long lastSavedId;
        public TicketRepository()
        {
            this.ticketRepository = new Dictionary<long, Ticket>();
            this.lastSavedId = 0;
        }
        public Ticket Save(Ticket ticket)
        {
            lastSavedId++;
            ticket.Id = lastSavedId;
            ticketRepository.Add(lastSavedId, ticket);
            Console.WriteLine("Saved Ticket with Id: " + lastSavedId);
            return ticket;
        }

        public Ticket GetById(long id)
        {
            if (!ticketRepository.ContainsKey(id))
            {
                return null;
            }
            return ticketRepository[id];

        }

        public Ticket GetTicketByNumber(string ticketNumber)
        {
            foreach (var ticket in ticketRepository.Values)
            {
                if (ticket.Number == ticketNumber)
                {
                    return ticket;
                }
            }
            return null;
        }
    }
}
