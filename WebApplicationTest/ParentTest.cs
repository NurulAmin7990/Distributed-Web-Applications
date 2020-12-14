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
    public class ParentTest
    {
        //Attributes
        Parent parent;

        //Methods
        [TestMethod]
        public void CreateParent()
        {
            parent = new Parent { ParentId = 1, FamilyId = 2, Firstname = "a", Lastname = "a", DateOfBirth = DateTime.Now, Gender = "M" };
            ParentController pc = new ParentController(new FakeParentRepository(false));
            Assert.IsInstanceOfType(pc.Create(parent), typeof(ActionResult));
        }

        [TestMethod]
        public void ReadParent()
        {
            ParentController pc = new ParentController(new FakeParentRepository());
            Assert.IsInstanceOfType(pc.Details(1), typeof(ActionResult));
        }

        [TestMethod]
        public void UpdateParent()
        {
            parent = new Parent { ParentId = 1, FamilyId = 2, Firstname = "b", Lastname = "b", DateOfBirth = DateTime.Now, Gender = "M" };
            ParentController pc = new ParentController(new FakeParentRepository(false));
            Assert.IsInstanceOfType(pc.Create(parent), typeof(ActionResult));
        }

        [TestMethod]
        public void DeleteParent()
        {
            ParentController pc = new ParentController(new FakeParentRepository());
            Assert.IsInstanceOfType(pc.DeleteConfirmed(1), typeof(ActionResult));
        }

    }
}
