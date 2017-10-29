using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgeRanger.Data.EntityDataModel;
using AgeRanger.Model;

namespace AgeRanger.WebApi.Mapping
{
    public static class Translate
    {
        public static PersonDetail ToDetails(this Data.EntityDataModel.Person person, List<AgeGroup> ageGroups)
        {
             return new PersonDetail
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Age = person.Age,
                AgeGroupName = person.Age.HasValue ? ageGroups.Single(g => person.Age >= g.MinAge && (!g.MaxAge.HasValue || person.Age < g.MaxAge)).Description : string.Empty
            };
        }

        public static Data.EntityDataModel.Person ToDataModel(this PersonDetail person)
        {
            return new Person()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Age = person.Age
            };
        }
    }
}