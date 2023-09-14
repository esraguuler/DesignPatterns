using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee esra = new Employee { Name = "Esra Güler" };
            Employee buse = new Employee { Name = "Buse Koca" };

            esra.AddSubordinate(buse);

            Employee seda = new Employee { Name = "Seda Kabakcı" };
            buse.AddSubordinate(seda);

            Employee derin = new Employee { Name = "Derin Demiroğ" };
            esra.AddSubordinate(derin);

            Console.WriteLine(esra.Name);
            foreach (Employee manager in esra)
            {
                Console.WriteLine(manager.Name);

                foreach (Employee employee in manager)
                {
                    Console.WriteLine(employee.Name);
                }
            }

            Console.ReadLine();
        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }



    class Employee : IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }


        public string Name { get; set; }
        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
