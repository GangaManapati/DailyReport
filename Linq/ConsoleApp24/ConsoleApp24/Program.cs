using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24
{
    internal class Program
    {

        //int[] n = { 1, 3, 4, 2, 2, 3, 22,};
        ////Console.WriteLine(n.Min());
        ////Console.WriteLine(n.Min());
        ////Console.WriteLine(n.Min());
        ////Console.WriteLine(n.Min());
        //string concatenatedNames = n.Aggregate("", (current, next) => current + (current == "" ? "" : ", ") );
        //Console.WriteLine($"Concatenated names: {concatenatedNames}");
        //Console.ReadLine(); 
        List<int> list = new List<int>() { 1, 3, 40, 5, 6, 7, 8, 9, 10, 11, 12 };
        // IEnumerable<int> list2 = from x in list where x%2==0 select x;
        //IEnumerable<int> list2 = list.Select((n, indexer) => new { number = n, Index = indexer })
        //    .Where(x => x.number % 2 == 0)
        //    .Select(x => x.Index);
        //foreach(int x in list2)
        //{
        //        Console.WriteLine(x);
        //}


        /* static void Main()
         {
             List<Person> people = new List<Person>
              {
             new Person { Name = "John", Age = 30, Friends = new List<string> { "Mike", "Sue" } },
             new Person { Name = "Jane", Age = 25, Friends = new List<string> { "Tom", "Anna" } },
             new Person { Name = "Tom", Age = 35, Friends = new List<string> { "John" } },
             new Person { Name = "Lucy", Age = 28, Friends = new List<string> { "Kate", "Sam", "Jim" } }
              };


             //var al = people.Select(p => new {Na=p.Name,A=p.Age}).OrderBy(s=>s.Na);
             var al = people.Select(p => new { Na = p.Name, A = p.Age }).OrderBy(s => s.A).ThenByDescending(q=>q.Na);
             foreach (var friend in al)
             {
                 Console.WriteLine(friend);
             }

             // SelectMany to flatten the list of friends
             IEnumerable<string> allFriends = people.SelectMany(p => p.Friends);

             foreach (var friend in allFriends)
             {
                 Console.WriteLine(friend);
             }

             Console.ReadLine();
         }
     }

     class Person
     {
         public string Name { get; set; }
         public int Age { get; set; }
         public List<string> Friends { get; set; }
     } */
        static void Main()
        {
            // Create a managed object
            Value = 221;

            
            IntPtr address = handle.AddrOfPinnedObject();

            // Print the address
            Console.WriteLine($"Address of obj: {address}");

            // Free the GCHandle
            handle.Free();
            Console.ReadLine();
        }
        

    }
}
