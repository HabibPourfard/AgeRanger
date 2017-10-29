using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgeRanger.Data.EntityDataModel;
using AgeRanger.Data.Interfaces;

namespace AgeRanger.Data.Repositories
{
    public class GeneralRepository : IGeneralRepository
    {
        #region Person
        public List<Person> GetPeople()
        {
            using (var context = new AgeRangerEntities())
            {
                return context.People.ToList();
            }
        }

        public Person GetPerson(int id)
        {
            using (var context = new AgeRangerEntities())
            {
                return context.People.SingleOrDefault(x => x.Id == id);
            }
        }

        public void SavePerson(Person person)
        {
            using (var context = new AgeRangerEntities())
            {
                if (person.Id == 0)
                {
                    context.People.Add(person);
                }
                else
                {
                    context.Entry(person).State = EntityState.Modified;
                }
                context.SaveChanges();
            }
        }
        #endregion

        #region AgeGroup
        public List<AgeGroup> GetAgeGroups()
        {
            using (var context = new AgeRangerEntities())
            {

                return context.AgeGroups.ToList();
            }
        }
        #endregion
    }
}
