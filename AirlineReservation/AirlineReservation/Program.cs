using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineReservation
{
   


    static class Program
    {
        //gives access to these lists to all forms so data can be added and stored
        //serves as database
        public static List<User> users = new List<User>();
        public static List<Flights> flight = new List<Flights>();
        public static User currentUser = new User("", "", "", false);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Register());
        }

        

    }

    public class User
    {
        public string Name
        { get; set; }
        public string Password
        { get; set; }
        public string Email
        { get; set; }
        public bool Admin
        { get; set; }

        //use to store flights has to match flight class with user if you add to one class add to other class
        public List<Flights> myFlight
            { get; set; }
        /*Program.users[0].myFlight.Add(new Flights("a","a","a"));*/
        // add already existing flight not ^
        


        public User(string username, string pass, string email, bool admin)
        {
            this.Name = username;
            this.Password = pass;
            this.Email = email;
            this.Admin = admin;
            myFlight = new List<Flights>();
        }

        // listOfFlights.Add((Flights) flight );
    }

    public class Flights
    {
        //create variables to be stored in the flight
        public string FlightNumber
        { get; set; }
        public string From
        { get; set; }
        public string Destination
        { get; set; }
        public string Price
        { get; set; }
        public string Time
        { get; set; }
        public int Capacity
        { get; set; }
        //use to store passengers for the flight
        public List<User> myPassengers
        { get; set; }
       
        

        /*Program.users[0].myUsers.Add(Bob);*/
        public Flights(string flightNumber, string from, string destination, string price, string time, int capacity)
        {
            this.FlightNumber = flightNumber;
            this.From = from;
            this.Destination = destination;
            this.Price = price;
            this.Time = time;
            this.Capacity = capacity;
            myPassengers = new List<User>();

        }
    }

    class Passengers
    {
        ArrayList passengers = new ArrayList();
        public User passenger
        { get; set; }
        public Passengers(User passenger)
        {
            passengers.Add(passenger);
        }
    }



}

