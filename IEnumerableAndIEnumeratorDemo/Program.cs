using System;
using System.Collections;
using System.Collections.Generic;

namespace IEnumerableAndIEnumeratorDemo
{
    internal class Program
    {
        //IEnumerable <T> : generic
        //IEnumerable : non-generic

        /// <summary>
        /// IEnumerable<T>: contains a single method that you must implement when implementing this interface
        /// GetEnumerator() : returns an IEnumerator<T> object
        /// The returned IEnumerator<T> provides the ability to iterate through the collection
        /// by exposing a current property that points at the object we are currently at in the collection 
        /// </summary>
        /// <param name="args"></param>
          
        ///WHEN IT IS RECOMMENDED TO USE THE IEnurable interface:
        ///
        /// you data collection represents a massive database table
        /// you dont want to copy the entire data into memory, causing performance issues in your application
        /// 
        /// WHENIT'S NOT RECOMMENDED 
        /// You need the results right away and arepossibly  mutating/editing objects later on.
        /// In this case, use an Array or List


        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();

            DogShelter shelter = new DogShelter();
            
            foreach(Dog dog in shelter)//GetEnumerator error
                if (!dog.isNaughty)
                    dog.GiveTreat(2);
                else
                    dog.GiveTreat(1);

            Console.WriteLine("-----------------------");
            Console.WriteLine("Enumerable Method");
            Console.WriteLine("-----------------------");

            //Enumerable: unkown collection
            IEnumerable<int> unknownCollection;
            Console.WriteLine("A list Colelction:");
            unknownCollection = getCollection(1);

            foreach(int k in unknownCollection)
                Console.Write(k + " ");

            Console.WriteLine();

            Console.WriteLine("A queue collection");
            unknownCollection = getCollection(2);
            foreach (int k in unknownCollection)
                Console.Write(k + " ");

            Console.WriteLine();
            Console.WriteLine("-----------------------");
            Console.WriteLine("List Collection: SUM");
            Console.WriteLine("-----------------------");
            CollectionSum(getCollection(1));

            Console.WriteLine("-----------------------");
            Console.WriteLine("Queue Collection: SUM");
            Console.WriteLine("-----------------------");
            CollectionSum(getCollection(2));

            Console.WriteLine("-----------------------");
            Console.WriteLine("array collection : SUM ");
            Console.WriteLine("-----------------------");
            CollectionSum(getCollection(4));
        }

        static void CollectionSum(IEnumerable<int> anyCollection)
        {
            int sum = 0;
            foreach (int num in anyCollection)
                sum += num;

            Console.WriteLine("TOTAL: " + sum);
        }
        //
        static IEnumerable <int> getCollection(int option)
        {
          
            List <int> numbersList = new List<int>() { 1,2,3,4,5};    
            Queue<int> numbersQueue = new Queue<int>();
            numbersQueue.Enqueue(1);
            numbersQueue.Enqueue(2);
            numbersQueue.Enqueue(3);
            numbersQueue.Enqueue(4);
            numbersQueue.Enqueue(5);

            switch(option)
            {
                case 1: 
                    return numbersList;
                case 2: 
                    return numbersQueue;
                default:
                    return new int[] { 1,2,3,4,5};
            }
        }
    }

    class Dog
    {
        public string Name { get; set; }
        public bool isNaughty { get; set; }

        public Dog(string Name, bool isNaugty)
        {
            this.Name = Name;
            this.isNaughty = isNaugty;  
        }

        public void GiveTreat(int numberOfTreats)
        {
            Console.WriteLine("Dog: {0} said woof {1} times!", Name, numberOfTreats);
        }
    }


    class DogShelter : IEnumerable<Dog>
    {
        public List<Dog> dogs;


        public DogShelter()
        {
            dogs = new List<Dog>()
            {
                new Dog("Casper", false),
                new Dog("Sif", true),
                new Dog("Oreo", true),
                new Dog("Pixel", false)
            };
        }

        IEnumerator<Dog> IEnumerable<Dog>.GetEnumerator()
        {
            //throw new NotImplementedException();
            return dogs.GetEnumerator();//return individual dogs
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
