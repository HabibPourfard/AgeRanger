using System.Collections.Generic;
using AgeRanger.Data.EntityDataModel;

namespace AgeRanger.Data.Interfaces
{
    public interface IGeneralRepository
    {
        List<AgeGroup> GetAgeGroups();
        List<Person> GetPeople();
        Person GetPerson(int id);
        void SavePerson(Person person);
    }
}