﻿using System;
using System.Data.Common;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;

class Program
{
    static TicketService ts;
    static DriverService ds;
    static Driver? currentDriver = null; 


    static void Main(string[] args)
    {
        System.Console.WriteLine("Welcome to the Ticket Application");
        string path = @"C:\Users\U713PY\RevatureTraining.NET\Revature.NetRebeccaCRepository\RebeccaProject1-app-db.txt";
        string connectionString = File.ReadAllText(path);

        //System.Console.WriteLine(connectionString); //need to delete later 

        DriverRepo dr = new(connectionString);
        ds = new(dr);

        TicketRepo tr = new(connectionString, dr);
        ts = new(tr);
        LoginMenu();
    }


    private static void LoginMenu()
    {
        bool keepGoing = true;
        while (keepGoing)
        {
            System.Console.WriteLine("Please Pick an Option Down Below:");
            System.Console.WriteLine("=================================");
            System.Console.WriteLine("[1] Register as a Driver (new user to the application.)");
            System.Console.WriteLine("[2] Log in as registered Driver (returning customer)");
            System.Console.WriteLine("[0] Quit");
            System.Console.WriteLine("=================================");

            int input = int.Parse(Console.ReadLine() ?? "0");
            input = ValidateCmd(input, 2);
            keepGoing = DecideUserOption(input);
        }
        System.Console.WriteLine("You have successfully logged in");
    }

    private static void MainMenu()
    {
        bool keepGoing = true;
        while (keepGoing)
        {
            System.Console.WriteLine("Please Pick an Option Down Below:");
            System.Console.WriteLine("=================================");
            System.Console.WriteLine("[1] View All Unpaid Tickets");
            System.Console.WriteLine("[2] View a specific Ticket");
            System.Console.WriteLine("[3] Check Balance/Due Date on Ticket");
            System.Console.WriteLine("[4] Pay (partial/full) amount on Ticket");
            System.Console.WriteLine("[0] Quit");
            System.Console.WriteLine("=================================");

            int input = int.Parse(Console.ReadLine() ?? "0");

            input = ValidateCmd(input, 4);

            //Extracted to method - uses switch case to determine what to do next.
            keepGoing = DecideNextOption(input);
        }
    }
    private static bool DecideUserOption(int input)
    {
        switch (input)
        {
            case 1:
                Register(); break;
            case 2:
                Login(); break;
            case 0:
            default:
                return false;
        }

        return true;
    }

 

    private static bool DecideNextOption(int input)
    {
        switch (input)
        {
            case 1:
                {
                    RetrievingAllUnpaidTickets();
                    break;
                }
            case 2:
                {
                    RetrievingSpecificTicket();
                    break;
                }
            case 3:
                {
                    CheckBalanceDue();
                    break;
                }
            case 4:
                {
                    PayAmountOnTicket();
                    break;
                }
            case 0:
            default:
                {
                    return false;
                }
        }

        return true;
    }

    private static void Register()
    {
        System.Console.WriteLine("Please Enter Your UserName as your first and last name: ");
        string username = Console.ReadLine() ?? "";

        System.Console.WriteLine("Please Enter a Password for your accout: ");
        string password = Console.ReadLine() ?? "";
        Driver? newDriver = new(0, username, password, "user");
        newDriver = ds.Register(newDriver); 
        if (newDriver != null)
        {
            System.Console.WriteLine("New Driver Registered!");
        }
        else
        {
            System.Console.WriteLine("Registration Failed! Please Try Again!");
        }
    }

    private static void Login()
    {
        while (currentDriver == null)
        {
            System.Console.WriteLine("Please Enter Your Username: ");
            string username = Console.ReadLine() ?? "";

            System.Console.WriteLine("Please Enter Your Password: ");
            string password = Console.ReadLine() ?? "";

            //Setting the currentUser variable signifies Logging in. If Login() fails it will remain null.
            currentDriver = ds.Login(username, password);
            if (currentDriver == null)
                System.Console.WriteLine("Login Failed. Please Try Again.");
        }
        MainMenu();
    }
   
    static void RetrievingAllUnpaidTickets() //this works
    {
        List<Ticket> tickets = ts.GetUnpaidTickets();

        System.Console.WriteLine("=== List of Unpaid Tickets ===");
        foreach (Ticket t in tickets)
        {
            System.Console.WriteLine(t);
        }
        System.Console.WriteLine("=================================");
    }

    static void RetrievingSpecificTicket() // this has been fixed and works 
    {
        System.Console.WriteLine("Please enter a Ticket ID (0 to Exit Process): ");
        int input = int.Parse(Console.ReadLine() ?? "0");
        var retrievedticket = ts.GetTicket(input);

        System.Console.WriteLine("=== Specific Tickets ===");
        System.Console.WriteLine(retrievedticket);
        System.Console.WriteLine("=================================");
    }
    private static void CheckBalanceDue()
    {
        Ticket? retrievedTicket = PromptUserForTicket();
        decimal ticketBalance = retrievedTicket.Balance;
        long ticketDueDate = retrievedTicket.DueDate;

        System.Console.WriteLine("Ticket Balance: " + ticketBalance+ "and is due on " + ticketDueDate);
        System.Console.WriteLine();
    }

    static void PayAmountOnTicket()
    {
        Ticket? ticket = PromptUserForTicket();
        if (ticket == null) return;

        System.Console.WriteLine("Please enter the amount you would like to pay on your ticket: " + ticket.TicketId);
        decimal payment = Decimal.Parse(Console.ReadLine() ?? "0");

        ts.MakeAPay(ticket, payment);

        System.Console.WriteLine("The new balance for " + ticket.TicketId + " is: " + ticket.Balance);
        System.Console.WriteLine();
    }
    
    static Ticket? PromptUserForTicket()
    {
        
        Ticket? retrievedTicket = null;
        while (retrievedTicket == null)
        {
            System.Console.WriteLine("Please enter a Ticket ID (0 to Exit Process): ");
            int input = int.Parse(Console.ReadLine() ?? "0");
            
            if (input == 0) return null;

            retrievedTicket = ts.GetTicket(input); 
        }
        
        return retrievedTicket;

        
        
        
    }

    static int ValidateCmd(int cmd, int maxOption)
    {
        while (cmd < 0 || cmd > maxOption)
        {
            System.Console.WriteLine("Invalid Command - Please Enter a command 1-" + maxOption + "; or 0 to Quit");
            cmd = int.Parse(Console.ReadLine() ?? "0");
        }
        return cmd;
    }    
}
  


