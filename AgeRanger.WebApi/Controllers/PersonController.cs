using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using AgeRanger.Model;
using AgeRanger.WebApi.Mapping;

namespace AgeRanger.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PersonDetailController : ApiController
    {
        private readonly Data.Interfaces.IGeneralRepository _generalRepository;

        public PersonDetailController(Data.Interfaces.IGeneralRepository generalRepository)
        {
            _generalRepository = generalRepository ;
        }

        //Todo: remove this and use IOC
        public PersonDetailController()
        {
            _generalRepository = new Data.Repositories.GeneralRepository();
        }

        // GET 
        public List<PersonDetail> Get()
        {
            try
            {
                var ageGroups = _generalRepository.GetAgeGroups();
                var people = _generalRepository.GetPeople();

                return people.Select(person => person.ToDetails(ageGroups)).ToList();
            }
            catch
            {
                throw new Exception("An error occurred");
            }
        }

        // GET api/PersonDetail/5
        public PersonDetail Get(int id)
        {
            try
            {
                var ageGroups = _generalRepository.GetAgeGroups();
                var person = _generalRepository.GetPerson(id);

                if (person == null) { throw new Exception("Couldn't find person"); }

                return person.ToDetails(ageGroups);
            }
            catch(Exception ex)
            {
                throw new Exception("An error occurred");
            }
        }

        // POST api/PersonDetail
        public void Post([FromBody]PersonDetail person)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Validation failed");
            }

            try
            {
                _generalRepository.SavePerson(person.ToDataModel());
            }
            catch
            {
                throw new Exception("An error occurred");
            }
        }

    }
}
