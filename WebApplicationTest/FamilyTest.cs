//Libraries
using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication;
using WebApplication.Controllers;
using WebApplication.Models;

//Package
namespace WebApplicationTest
{
    //Class
    [TestClass]
    public class FamilyTest
    {
        //Attributes
        FamilyController familyController;
        Family family;

        //Constructor
        public FamilyTest()
        {
            //Initialize the controller for use
            familyController = new FamilyController();
        }

        //Methods
        [TestMethod]
        public void createFamily()
        {
            //Create family object and set attribute values
            family = new Family() { FamilyId = 1, ContactNumber = "123456789", Email = "Example123@Example.com", AddressLine = "Example Road", AddressArea = "Example", AddressPostcode = "AB1 23CD" };
            //Use controller method to create a family object and store it in database
            familyController.Create(family);
            //Result variable
            var result = familyController.Create();
            //Assert method to test
            Assert.AreEqual(result.GetType(), typeof(ActionResult));
        }
    }
}
