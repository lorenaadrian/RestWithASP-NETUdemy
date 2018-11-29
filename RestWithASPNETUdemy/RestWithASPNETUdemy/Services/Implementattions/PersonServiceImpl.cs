using System;
using System.Collections.Generic;
using System.Threading;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services.Implementattions
{
    public class PersonServiceImpl : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            return;
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Anne",
                LastName = "Hickman",
                Address = "Belo Horizonte, Minas Gerais - Brasil",
                Gender = "Female"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person Name " + i,
                LastName = "Person Lastname " + i,
                Address = "Some Adrres " + i,
                Gender = "Gender " + i
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
