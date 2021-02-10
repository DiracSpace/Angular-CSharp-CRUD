using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Core
{
    /// <summary>
    /// 
    /// The Person data model
    /// 
    /// </summary>
    public class Persons
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Direction { get; set; }
    }
}
