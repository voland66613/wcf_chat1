using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace MyChatHost
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (var host = new ServiceHost(typeof(ServiceChat)))
            {
                host.Open();
                Console.WriteLine("Host is running!");
                Console.ReadLine();
            }



            //Testing DB

            /* In the database, the table column where the user's gender value will be uploaded in my case should be called sex__sex and have the int type.
             * (general view 1XXX_2XXX where 1XXX is the name of the field of the T data type in the object class that you write to the database, and 2XXX is the name of the enumeration type field in
             * class T. These names are written with "_". I have a sex enum type field in the Sex class called _sex, hence
             * I have the name of the column of the table with data about the field written in two characters "_", namely sex__sex):
             sex - a field of data type Sex (class Sex) in the UsersAccaunt class
             _sex - a field of type sex (sex enumeration) in the Sex class * /
            /*
            UsersAccaunt usersaccaunt = new UsersAccaunt()
            {
                Login = "Johny",
                Password = "123Fuck123",
                Name = "Semeon",
                Age = 15,
                sex = new Sex(sex.Male)
            };

            
            using (UsersAccauntContext ua = new UsersAccauntContext())
            {
                ua.UsersAccaunts.Add(usersaccaunt);
                ua.SaveChanges();
            }
            

            using (UsersAccauntContext ua = new UsersAccauntContext()) 
            {
                List<UsersAccaunt> list = ua.UsersAccaunts.ToList();
                foreach (var l in list) 
                {
                    Console.WriteLine(l.Id + " ; " + l.Login + " ; " + l.Password + " ; " + l.Name + " ; " + l.Age + " ; " + l.sex);                
                }
            }
                

                Console.ReadLine();
            */


            /*
            try
            {
                using (UsersAccauntContext ua = new UsersAccauntContext())
                {
                    UsersAccaunt temp = new UsersAccaunt();
                    temp = ua.UsersAccaunts.FirstOrDefault(ob => ob.Login == "BulletMaster" && ob.Password == "an7163");

                    if (temp != null)
                    {
                        ua.UsersAccaunts.Remove(temp);
                        ua.SaveChanges();
                        Console.WriteLine("Object is removed from data base! ");

                    }
                    else
                    {
                        Console.WriteLine("Object is not found in data base! ");
                    }

                }
            }
            catch
            {
                Console.WriteLine("Thomething is wrong with deleting an object from DataBase! ");
            }
            */





            Console.ReadLine();
        }
         
    }
}
