using System.Collections.Generic;
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
        IEnumerable<Persons> GetPeopleByName(string name);
        Persons GetById(int id);
        Persons Update(Persons updatedPerson);
        Persons Add(Persons newPerson);
        Persons Delete(int id);
        int Commit();
    }
}
