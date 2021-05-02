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
        public static List<User> users = new List<User>();
        public static List<Flights> flight = new List<Flights>();
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

        //use to store flights has to match flight class with user if you add to one class add to other class
        public List<Flights> myFlight
            { get; set; }
        /*Program.users[0].myFlight.Add(new Flights("a","a","a"));*/
        // add already existing flight not ^
        /*public ArrayList listOfFlgihts = new ArrayList();*/


        public User(string username, string pass, string email)
        {
            this.Name = username;
            this.Password = pass;
            Email = email;
            myFlight = new List<Flights>();
        }

        // listOfFlights.Add((Flights) flight );
    }

    public class Flights
    {
        public string flightName
        { get; set; }
        public string Password
        { get; set; }
        public string Email
        { get; set; }
        //use to store passengers for the flight
        List<User> myUsers = new List<User>();

        /*Program.users[0].myUsers.Add(Bob);*/
        public Flights(string username, string pass, string email)
        {
            this.flightName = username;
            this.Password = pass;
            Email = email;
          
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

