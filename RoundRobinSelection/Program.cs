using System;
using System.Collections.Generic;
using System.Linq;
using RoundRobinSelection.Extension;

namespace RoundRobinSelection
{
    class Program
    {
        static void Main(string[] args)
        {
            DoArrayHelperSelectByRoundRobin();

            DoCollectionByRoundRobinValueType();

            DoCollectionByRoundRobinReferenceType();
        }

        static void DoArrayHelperSelectByRoundRobin()
        {
            string[] colorNames = {"red", "orange", "blue", "green", "yellow"};

            int counter = 0;
            int lastSelectedIndex = -1;

            do
            {
                var selectedElement = ArrayHelper.SelectByRoundRobin(colorNames, lastSelectedIndex);

                lastSelectedIndex++;

                Console.WriteLine($"{selectedElement} | Last selected index is {lastSelectedIndex}");
                
                counter++;
            } while (counter < colorNames.Length);
        }

        static void DoCollectionByRoundRobinValueType()
        {
            string[] applianceNames = { "television", "microwave", "washer", "dryer", "refridgerator" };

            int counter = 0;
            int? lastSelectedIndex = null;

            do
            {
                var selectedElement = applianceNames.RoundRobin(x => x, lastSelectedIndex);

                lastSelectedIndex = selectedElement.Item2;

                Console.WriteLine($"{selectedElement.Item1} | Last selected index is {lastSelectedIndex}");

                counter++;
            } while (counter < applianceNames.Length);
        }

        static void DoCollectionByRoundRobinReferenceType()
        {
            int counter = 0;
            int? lastSelectedIndex = null;

            var people = Person.GetPeople().ToArray();

            do
            {
                var selectedElement = people.RoundRobin(x => x.Age, lastSelectedIndex);

                lastSelectedIndex = selectedElement.Item2;

                Console.WriteLine($"{selectedElement.Item1.FirstName} {selectedElement.Item1.LastName} age {selectedElement.Item1.Age} | Last selected index is {lastSelectedIndex}");

                counter++;
            } while (counter < people.Count());
        }

        public class Person
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public int Age { get; set; }

            public static IEnumerable<Person> GetPeople()
            {
                List<Person> peopleList = new List<Person>
                {
                    new Person {Age = 28, FirstName = "John", LastName = "Smith"},
                    new Person {Age = 32, FirstName = "Pepper", LastName = "Poppy"},
                    new Person {Age = 29, FirstName = "Carl", LastName = "Cunningham"}
                };


                return peopleList;
            } 
        }
    }
}
