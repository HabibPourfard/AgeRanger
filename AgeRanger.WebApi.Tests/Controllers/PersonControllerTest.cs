using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AgeRanger.Data.EntityDataModel;
using AgeRanger.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgeRanger.WebApi;
using AgeRanger.WebApi.Controllers;
using Moq;

namespace AgeRanger.WebApi.Tests.Controllers
{
    [TestClass]
    public class PersonControllerTest
    {
        [TestMethod]
        public void GetPersonTest()
        {
            var testAgeGroups = new List<AgeGroup>()
            {
                new AgeGroup() {Id = 11, MinAge = 199, MaxAge = 4999, Description = "Vampire"},
                new AgeGroup() {Id = 12, MinAge = 4999, Description = "Kauri tree"},
            };

            var mock = new Mock<Data.Interfaces.IGeneralRepository>();
            mock.Setup(m => m.GetAgeGroups()).Returns(testAgeGroups);
            mock.Setup(m => m.GetPerson(It.IsAny<int>())).Returns(new Person() { Id = 1, FirstName = "Mini", LastName = "Me", Age = 9999 });
            

            // Arrange
            var controller = new PersonDetailController(mock.Object);

            var result = controller.Get(1);

            Assert.IsTrue(result.AgeGroupName == "Kauri tree");
        }
    }
}
