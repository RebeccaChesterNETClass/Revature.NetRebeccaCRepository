﻿using System;

class Program
{
    static void Main(string[] args)
    {
        //int num = 1;
        //string word= "Hello";

        //Object Declaration and Instantiation (new instance of a class)(Intialization)
        Object obj1 = new Object();
        Object obj2 = new Object();
        Object obj3 = new(); //simplified version of same thing assumes Object will be the name
        
        DateTime currentTime = DateTime.Now;
        System.Console.WriteLine(currentTime);

        Car car1 = new Car();
        System.Console.WriteLine(car1); // Right now only prints car as it only prints the name of the class

        car1.color = "Blue";
        car1.make = "Chevy";
        car1.model = "1500";
        car1.year = 2017;

        System.Console.WriteLine(car1.color);
        System.Console.WriteLine(car1.year);
        System.Console.WriteLine(car1.mileage);//not set so defaults to 0 when run 

        System.Console.WriteLine("color: " + car1.color + ": Year:" + car1.year);
        System.Console.WriteLine(car1.color + car1.year);// not as pretty as above wont have spaces or anything

        car1.Honk(); //need the car to honk the car 
        car1.Drive(100);
        car1.Drive(100);

        Car car2 = new Car();

        car2.color = "White";
        car2.make = "Chevorlet";
        car2.model = "3500";
        car2.year = 2023;

        System.Console.WriteLine("Car 1 Mileage; " + car1.mileage);
        System.Console.WriteLine("Car 2 Mileage; " + car2.mileage);

        car2.Drive(50);
        System.Console.WriteLine("====After Driving Car 2 some more===");
        System.Console.WriteLine("Car 1 Mileage; " + car1.mileage);
        System.Console.WriteLine("Car 2 Mileage; " + car2.mileage);

        Car car3 = car2;  //you can do this but these will become same spot in memory and change to one will change the other 
        System.Console.WriteLine("car 3 color: " + car3.color);
        System.Console.WriteLine("car 3 mileage: " + car3.mileage);

        //Are car 3 and car2 the same car or borrowing each others information 
        System.Console.WriteLine("Car 1 Mileage; " + car2.mileage);
        System.Console.WriteLine("Car 2 Mileage; " + car3.mileage);        
        car3.Drive (50); 
        System.Console.WriteLine("Car 1 Mileage; " + car2.mileage);
        System.Console.WriteLine("Car 2 Mileage; " + car3.mileage);
        //Car3 anc Car2 are exact same car in memory see paint snippet for this 
        // you do not want to this except in rare cases 

        //You can reassign car three to separate it out and "break ties" with car2
        car3 = new();
        System.Console.WriteLine();
        System.Console.WriteLine("car 3 color: " + car3.color);
        System.Console.WriteLine("car 3 mileage: " + car3.mileage);
        car3.color = "Grey";
        car3.make = "Dodge";
        car3.model = "Charger";
        car3.mileage = 1100;
        car3.year = 2025;

        System.Console.WriteLine("=====Car 3 getting new values=====");
        System.Console.WriteLine("car 3 color: " + car3.color);
        System.Console.WriteLine("car 3 mileage: " + car3.mileage);

        car3.Drive (50);

        System.Console.WriteLine("====Car 3 driving some==== ");
        System.Console.WriteLine("car 3 color: " + car3.color);
        System.Console.WriteLine("car 3 mileage: " + car3.mileage);

        System.Console.WriteLine("===comparing cars after the change==");
        System.Console.WriteLine("Car 1 Mileage; " + car2.mileage);
        System.Console.WriteLine("Car 2 Mileage; " + car3.mileage);

        System.Console.WriteLine("==using Display Info =====");
        System.Console.WriteLine("Car1" + car1.DisplayInfo());
        System.Console.WriteLine("Car2" + car2.DisplayInfo());

        System.Console.WriteLine("====switching to ToString =====");
        System.Console.WriteLine("Car1" + car1.ToString());
        System.Console.WriteLine("Car2" + car2.ToString());

        //Because the To String exists now you can just call that class 
        System.Console.WriteLine("==Trying something new===");
        System.Console.WriteLine("Car1: " + car1);
        System.Console.WriteLine("Car2: " + car2);

        //He ChatGPT what is console.WriteLine definition 
        //writeline method calls ToString Methood 

        Car Car4 = new Car();
        Car car5 = new Car("Silver");
        Car car6 = new Car("Yellow", "VW", "Beetle", 2021, 15000);
        Car car7 = new Car("", "VW", "Beetle", 2021, 15000); //allows you to put in some and not all values    
        //System.Console.WriteLine("Car4: " + car4.ToString());
        //System.Console.WriteLine("Car5: " + car5.ToString());
       
       //System.Console.WriteLine(car7.color.ToUpper()); //this prints a blank line out put 
       System.Console.WriteLine(car7);     
        
        //How to copy over one objects values to another object 
        //no Arguement --methods in car ca file
        Car car8 = new();
        car8.color = car6.color;
        car8.make = car6.make;
        car8.model = car6.model;
        car8.year = car6.year; 


        //Full Arguemnet --methods in car ca file
        //Car car9= new(car6.color, car6.make, car6.model, car6.year, car6.mileage);
        
        //Copy --methods in car ca file
        Car car10 = new Car(car6);

    //Tomorow
        //Properties 
        //Scopes (static keyword as well)
        //Access Modifiers
    //need to do this week 
        //File input/ouotput
    //maybe next week
        //Inheritance
        //Polymorphism 
        
    }
}