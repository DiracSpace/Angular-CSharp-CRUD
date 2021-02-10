using System.Collections.Generic;
using System.Linq;
using CRUD.Core;

namespace CRUD.Data
{
    public class InMemoryPersonData : IPersonData
    {
        /// <summary>
        /// 
        /// Constructor for generating
        /// template data
        /// 
        /// </summary>

        readonly List<Persons> people;
        public InMemoryPersonData()
        {
            people = new List<Persons>()
            {
                new Persons { 
                    Id = 1,
                    Name = "Roberto",
                    LastName = "De León",
                    Age = 22,
                    Email = "roberto@gmail.com",
                    Direction = "Some Street"
                },
                new Persons {
                    Id = 2,
                    Name = "Kevin",
                    LastName = "De León",
                    Age = 14,
                    Email = "kevin@gmail.com",
                    Direction = "Another Street"
                },
                new Persons {
                    Id = 3,
                    Name = "Jesse",
                    LastName = "De León",
                    Age = 10,
                    Email = "jesse@gmail.com",
                    Direction = "Yet Another Street"
                }
            };
        }

        /// <summary>
        /// 
        /// returns a list of people ordered by the 
        /// individuals name
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Persons> GetPeopleByName(string name = null) => from individual in people
                                                                           where string.IsNullOrEmpty(name) || individual.Name.StartsWith(name)
                                                                           orderby individual.Name
                                                                           select individual;

        public Persons GetById(int id) => people.SingleOrDefault(individual => individual.Id == id);

        public Persons Add(Persons newPerson)
        {
            people.Add(newPerson);
            newPerson.Id = people.Max(individual => individual.Id) + 1;
            return newPerson;
        }

        public Persons Update(Persons updatedPerson)
        {
            var person = people.SingleOrDefault(individual => individual.Id == updatedPerson.Id);
            if (person != null)
            {
                person.Name = updatedPerson.Name;
                person.LastName = updatedPerson.LastName;
                person.Age = updatedPerson.Age;
                person.Email = updatedPerson.Email;
                person.Direction = updatedPerson.Direction;
            }
            return updatedPerson;
        }

        public int Commit() => 0;

        public Persons Delete(int id)
        {
            var person = people.SingleOrDefault(individual => individual.Id == id);
            if (person != null) 
            {
                people.Remove(person); 
            }
            return person;
        }
    }
}
