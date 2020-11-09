//Libraries
using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication;
using WebApplication.Models;

//Package
namespace WebApplicationTest
{
    //Class
    [TestClass]
    public class FamilyTest
    {
        //Attributes
        DatabaseEntities db = new DatabaseEntities();
        Family family;

        //Constructor
        public FamilyTest()
        {
        }

        //Methods
        [TestMethod]
        public void createFamily()
        {
            //Create family object and set attribute values
            family = new Family() { FamilyId = 1, ContactNumber = "123456789", Email = "Example123@Example.com", AddressLine = "Example Road", AddressArea = "Example", AddressPostcode = "AB1 23CD" };
            //Use db method to create a family object and store it in database
                db.Families.Add(family);
            //Result variable that 
            int result = db.SaveChanges();
            //Assert method to test
            Assert.AreEqual(result, 1);
        }
    }
}
