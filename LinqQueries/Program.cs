using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqQueries
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>()
            {
                new Person("Spencer", "Oakes", 1, 71, 34, Gender.Male),
                new Person("Lebron", "James", 2, 80, 34, Gender.Male),
                new Person("Sarah", "Smith", 3, 55, 22, Gender.Female),
                new Person("Krista", "Johnson", 4, 59, 54, Gender.Female),
                new Person("Mike", "Williams", 5, 67, 61, Gender.Male),
                new Person("Mary", "Annie", 6, 54, 19, Gender.Female),
                new Person("Mo", "Williams", 7, 77, 21, Gender.Male),
                new Person("Sean", "McVay", 8, 68, 27, Gender.Male),
                new Person("Josh", "Tyson", 9, 72, 35, Gender.Male),
                new Person("Kobe", "Bryant", 10, 80, 39, Gender.Male),
                new Person("Chipper","Jones",  11, 76, 40, Gender.Male),
                new Person("Lauren", "Ellie", 12, 63, 26, Gender.Female),
                new Person("Oprah", "Winfry", 13, 64, 59, Gender.Female),
                new Person("Michelle", "Jones", 14, 70, 18, Gender.Female)
            };

            SeparatingLine();

            var orderedByKey = from p in people
                               group p by p.Age into ageGroup
                               orderby ageGroup.Key
                               select ageGroup;

            foreach (var key in orderedByKey)
            {
                Console.WriteLine($"{key.Key}");
                foreach (var item in key)
                {
                    Console.WriteLine($" {item.Age}");
                }
            }

            SeparatingLine();

            var lambdaGrouping = people.Where(p => p.Age > 20)              // an example of using lambda instead
                                       .GroupBy(p => p.Gender);

            foreach (var item in lambdaGrouping)
            {
                Console.WriteLine($"Gender: {item.Key}");

                foreach (var p in item)
                {
                    Console.WriteLine($" {p.FirstName}, {p.Age}");
                }
            }

            SeparatingLine();

            int[] arrayOfNumbers = { 14, 2, 34, 39, 47, 987, 123, 90, 15, 5, 6, 21, 12, 11, 84, 79, 109 };

            var numbers = from n in arrayOfNumbers
                          orderby n
                          let evenOrOdd = (n % 2 == 0) ? "Even Numbers" : "Odd Numbers"
                          group n by evenOrOdd into nums
                          orderby nums.Count()
                          select nums;

            foreach (var num in numbers)
            {
                Console.WriteLine($"{num.Key}");
                foreach (var i in num)
                {
                    Console.WriteLine($" {i}");
                }
            }

            SeparatingLine();

            var peopleMultiGrouping = from p in people
                                      let ageGroup =
                                            p.Age < 20                              
                                                ? "Young"                           
                                                : p.Age >= 20 && p.Age <= 30        
                                                    ? "Adult"                       
                                                    : "More Adult"                       
                                      group p by ageGroup;

            foreach (var p in peopleMultiGrouping)
            {
                Console.WriteLine($"{p.Key}");
                foreach (var i in p)
                {
                    Console.WriteLine($" {i.Age}");
                }
            }

            SeparatingLine();

            var howManyOfEachGroup = from p in people
                                     group p by p.Gender into g
                                     orderby g.Count()
                                     select new { Gender = g.Key, NumOfPeople = g.Count() };

            foreach (var amount in howManyOfEachGroup)
            {
                Console.WriteLine($"{amount.Gender}");
                Console.WriteLine($"{amount.NumOfPeople}");
            }

            Console.ReadLine();
        }

        private static void SeparatingLine()
        {
            Console.WriteLine(new string('-', 50));
        }
    }
}
