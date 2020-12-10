using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQpracticeNEW2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Print student name ---> Subjects

            var result = Student.GetAllStudetns().SelectMany(s => s.Subjects,

                (x, y) => new
                {
                    name = x.Name,
                    sub = y
                }

            );

            foreach( var x in result)
            {
                Console.WriteLine(x.name + " ----> "+ x.sub);
            }
            Console.WriteLine("------------------------");



            // doing the same thing but using SQL like syntax


            var r = from stu in Student.GetAllStudetns()
                    from sub in stu.Subjects
                    select new
                    {
                        n = stu.Name,
                        s = sub
                    };


            foreach (var rr in r)
            {
                Console.WriteLine(rr.n + " ----> " + rr.s);
            }


            // Casting the List into Lookup

            var look = Student.GetAllStudetns().ToLookup(x => x.Name);



            // using Group by on the employee class


            // print department and the count of persons in it 

          var group =  Employee.GetAllEmployees().GroupBy(x => x.Department);

            foreach (var item in group)
            {
                Console.WriteLine(item.Key +" --> " + item.Count());         

            }

            Console.WriteLine(" --------------------------------- ");


            // print the Average salary of each department

            foreach (var item in group)
            {
                Console.WriteLine(item.Key + " --> " + item.Average(x=> x.Salary));

            }

            // print employee dept , all employees in that department and their respective names and salary

            Console.WriteLine();

            foreach (var item in group)
            {
                Console.WriteLine(item.Key );

                foreach ( var emp in item)
                {
                    Console.WriteLine(emp.Name + " " + emp.Salary);
                }
                Console.WriteLine();

            }



        }
    }
}
