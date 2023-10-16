using System;
using System.Linq;
using System.IO;

namespace linq
{
    public class Employee
    {
        public int birthYear;
        public string firstName;
        public string lastName;

        public static Employee[] GetEmployees()
        {
            Employee[] actors = new Employee[] {
        new Employee { birthYear = 1964, firstName = "K", lastName = "R" },
        new Employee { birthYear = 1968, firstName = "O", lastName = "ra" },
        new Employee { birthYear = 1960, firstName = "J", lastName = "S" },
        new Employee { birthYear = 1964, firstName = "S", lastName = "z" },
        new Employee { birthYear = 1964, firstName = "S", lastName = "p" },
      };
            return (actors);
        }

        public static Employee[] GetAllEmployees()
        {
            Employee[] actors = new Employee[] {
        new Employee { birthYear = 1964, firstName = "K", lastName = "R" },
        new Employee { birthYear = 1968, firstName = "O", lastName = "ra" },
        new Employee {  firstName = "J", lastName = "S" },
        new Employee { birthYear = 1964, firstName = "S", lastName = "z" },
        new Employee { birthYear = 1964, firstName = "S", lastName = "p" },
        new Employee { birthYear = 1964, firstName = "S", lastName = "p" },
      };
            return (actors);
        }
    }
    public class Program
    {
        public static void Main()
        {

            //int firstAlphabetically = Employee.GetEmployees().Count();
            Employee[] firstAlphabetically = Employee.GetEmployees().OrderBy(x => x.firstName).ThenBy(x => x.lastName).ToArray();

            foreach (var student in firstAlphabetically)
            {
                Console.WriteLine(student.lastName);
            }

            int firstAlphabetically1 = Employee.GetEmployees().Reverse().Count();
            Console.WriteLine("Total elements : - " + firstAlphabetically1);

            var order = Employee.GetEmployees().GroupBy(x => x.firstName).Count();
            Console.WriteLine(order);

            Employee[] firstAlphabetically2 = Employee.GetEmployees().OrderBy(x => x.firstName).ThenBy(x => x.lastName).Take(3).ToArray();

            foreach (var student in firstAlphabetically2)
            {
                Console.WriteLine(student.lastName);
            }
            Console.WriteLine(typeof(int));

            Employee[] firstAlphabetically3 = Employee.GetEmployees().OrderBy(x => x.firstName).ThenBy(x => x.lastName).TakeWhile(x => x.birthYear > 6).ToArray();

            foreach (var student in firstAlphabetically3)
            {
                Console.WriteLine(student.lastName);
            }

            Console.WriteLine("----------------------- lookup----------");
            var Emp = Employee.GetEmployees().ToLookup(x => x.lastName).ToList();

            foreach (var KeyValurPair in Emp)
            {
                Console.WriteLine(KeyValurPair.Key);
            }

            var birth = Employee.GetEmployees().Select(x => x.birthYear).Aggregate((a, b) => a + b);
            var birth1 = Employee.GetEmployees().Select(x => x.birthYear).Sum();
            var birth2 = Employee.GetEmployees().Select(x => x.birthYear).Skip(2).Sum();
            Console.WriteLine(birth2);


            //var single1 = Employee.GetEmployees().Single(x => x.firstName == "k");
            //string namee = single1.firstName;
            //Console.WriteLine(single1);

            int[] objList = { 1, 4, 5, 7 };
            string[] objList1 = { "fa", "g", "h" };
            Console.WriteLine("------------ to string----");
            var str = objList1.ToArray();
            var oftype = objList1.OfType<string>();
            Console.WriteLine(str);
            foreach (var item in oftype)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("");
            Console.WriteLine("---------------------");
            int val = objList.SingleOrDefault(i => i == 5);
            int first = objList.First();
            int firstordefault = objList.FirstOrDefault();
            int last = objList.Last();
            int lastordefault = objList.LastOrDefault();
            Console.WriteLine("Element from objList: {0}", lastordefault);

            Console.WriteLine("---------empty default -----------");
            var emptydefault = Employee.GetAllEmployees().Select(x => x.birthYear).Take(4).DefaultIfEmpty();
            foreach (var item in emptydefault)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------distinct -----------");
            var empdistinct = Employee.GetAllEmployees().Select(x => x.birthYear).Distinct();
            foreach (var item in empdistinct)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("--------------file read and write -----------");
            FileStream f = new FileStream("C:/Users/DELL/projects/file1.txt", FileMode.OpenOrCreate);//creating file stream  
            for (int i = 65; i <= 90; i++)
            {
                f.WriteByte((byte)(i + 32));
            }
            f.Close();//closing streama
            Console.ReadKey();

        }
    }
}

