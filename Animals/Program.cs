using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList animals = new ArrayList();

            Console.WriteLine("Welcome to Animal Playland!!!");
            Console.WriteLine("Which animal would you like to interact with?\n\t1. Dog\n\t2. Cat");
            string input = Console.ReadLine();

            IAnimal animal = null;
            switch (input)
            {
                case "1":
                    animal = AnimalFactory.GetAnimal<Dog>();
                    break;
                case "2":
                    animal = AnimalFactory.GetAnimal<Cat>();
                    break;
                default:
                    Console.WriteLine("Not a valid selection...");
                    break;
            }

            Console.WriteLine("What activity would you like to do with the " + animal.Name().ToString() + ".\n\t1. Speak\n\t2. Sit\n\t3. Play");
            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine(animal.Speak());
                    break;
                case "2":
                    Console.WriteLine(animal.Sit());
                    break;
                case "3":
                    Console.WriteLine(animal.Play());
                    break;
                default:
                    Console.WriteLine("Not a valid selection...");
                    break;
            }

            Console.ReadLine();
        }

        public static class AnimalFactory
        {
            public static IAnimal GetAnimal<T>() where T : IAnimal
            {
                return Activator.CreateInstance<T>();
            }
        }
        
        public interface IAnimal
        {
            string Name();
            string Speak();
            string Sit();
            string Play();
        }

        public class Cat : IAnimal
        {
            public string Name()
            {
                return "Cat";
            }

            public string Speak()
            {
                return "Meow";
            }

            public string Sit()
            {
                return "I dont want to.";
            }

            public string Play()
            {
                return "I will when I want to";
            }
        }

        public class Dog : IAnimal
        {
            public string Name()
            {
                return "Dog";
            }

            public string Speak()
            {
                return "Bark";
            }
 
            public string Sit()
            {
                return "I am sitting.";
            }

            public string Play()
            {
                return "Where is the BALL!!!";
            }
        }
    }
}
