﻿namespace EventManagement.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using EventManagement.Data.Models;
    using EventManagement.Repository;

    /// <summary>
    /// This class connects the Repository class to our main program file.
    /// </summary>
    public class BusinessLogic : IEventLogic, ILogic
    {
        private ITicketRepository ticketRepo;
        private IEventRepository eventRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogic"/> class.
        /// Constructor for the class which takes two parameters.
        /// </summary>
        /// <param name="ticketRepo">instance of Ticket Repository.</param>
        /// <param name="eventRepository">instance of Event Repository.</param>
        public BusinessLogic(ITicketRepository ticketRepo, IEventRepository eventRepository)
        {
            this.ticketRepo = ticketRepo;
            this.eventRepository = eventRepository;
        }

        /// <summary>
        /// Method to change the discount value for the specifc Guest.
        /// </summary>
        /// <param name="id">Ticket Id of the Guest.</param>
        /// <param name="newDiscount">New Value to be Updated.</param>
        public void ChangeTicketDiscount(int id, int newDiscount)
        {
            this.ticketRepo.ChangeDiscount(id, newDiscount);
        }

        /// <summary>
        /// Method which returns all the tickets that has been sold.
        /// </summary>
        /// <returns>List of Tickets.</returns>
        public IList<Ticket> GetAllTickets()
        {
            return this.ticketRepo.GetAll().ToList();
        }

        /// <summary>
        /// This method provide the information about total sale of the every Event.
        /// </summary>
        /// <returns>List with Event name and its Total Sale.</returns>
        public IList<TotalEventSale> GetEventSale()
        {
            var q1 = from ticket in this.ticketRepo.GetAll()
                     group ticket by new
                     {
                         ticket.Event.Id,
                         ticket.Event.Name,
                     }
                    into grp
                     select new TotalEventSale
                     {
                         EventName = grp.Key.Name,
                         TicketPrice = grp.Sum(x => x.Price),
                     };
            return q1.ToList();
        }

        /// <summary>
        /// This method return all the detailed information about the specific Ticket.
        /// </summary>
        /// <param name="id">Ticket Id.</param>
        /// <returns>Instance of required Ticket.</returns>
        public Ticket GetOneTicket(int id)
        {
            return this.ticketRepo.GetOne(id);
        }

        /// <summary>
        /// This method allow the user to add new Event to its Database.
        /// </summary>
        /// <param name="entity">Instance of Type Event.</param>
        public void add(Event entity)
        {
            this.eventRepository.Insert(entity);
        }

        /// <summary>
        /// This method gives all the Events in the Database.
        /// </summary>
        /// <returns>List of the type Event.</returns>
        public IList<Event> getAllEvent()
        {
            return this.eventRepository.GetAll().ToList();
        }

        /// <summary>
        /// This method allow the user to delete the specific Event from the Database.
        /// </summary>
        /// <param name="id">Id of the Event of type Integer.</param>
        /// <returns>Boolean Value if Event is deleted or not.</returns>
        public bool remove(int id)
        {
            return this.eventRepository.Remove(id);
        }

        /// <summary>
        /// This method is used to change the Event place in case Plans are changed.
        /// </summary>
        /// <param name="id">Event Id of type Integer.</param>
        /// <param name="newPlace">Name of New Place of Type String.</param>
        public void updatePlace(int id, string newPlace)
        {
            this.eventRepository.ChangePlace(id, newPlace);
        }
    }
}
