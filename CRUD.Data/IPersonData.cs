using System.Collections.Generic;
using System.Linq;
using CRUD.Core;

namespace CRUD.Data
{
    /// <summary>
    /// 
    /// Temporary data source class
    /// for future database swaping
    /// 
    /// </summary>
    public interface IPersonData
    {
        IEnumerable<Persons> GetAll();
    }

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
        public IEnumerable<Persons> GetAll() => from individual in people
                                                    orderby individual.Name
                                                    select individual;
    }
}
