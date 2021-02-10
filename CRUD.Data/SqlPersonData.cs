using CRUD.Core;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Data
{
    public class SqlPersonData : IPersonData
    {
        private readonly PersonDbContext database;
        public SqlPersonData(PersonDbContext database)
        {
            this.database = database;
        }

        public Persons Add(Persons newPerson)
        {
            database.Add(newPerson);
            return newPerson;
        }

        public int Commit() => database.SaveChanges();

        public Persons Delete(int id)
        {
            var person = GetById(id);
            if (person != null)
            {
                database.Person.Remove(person);
            }
            return person;
        }

        public Persons GetById(int id) => database.Person.Find(id);

        public IEnumerable<Persons> GetPeopleByName(string name)
        {
            var resultSet = from individual in database.Person
                            where individual.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                            orderby individual.Name
                            select individual;
            return resultSet;
        }

        public Persons Update(Persons updatedPerson)
        {
            var entity = database.Person.Attach(updatedPerson);
            entity.State = EntityState.Modified;
            return updatedPerson;
        }
    }
}
