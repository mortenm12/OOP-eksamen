using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StregSystem;
using StregSystem.Exeptions;

namespace UnitTest
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void IdTest()
        {
            User user1 = new User();
            Assert.AreEqual((uint)1, user1.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(NotAUserExeption))]
        public void Username()
        {
            User user1 = new User();
            user1.UserName = "user.name"; // this should make an exeption

            Assert.AreEqual("", user1.UserName);
        }

        [TestMethod]
        public void Username2()
        {
            User user1 = new User();
            user1.UserName = "username_1"; // this should make an exeption

            Assert.AreEqual("username_1", user1.UserName);
        }

        [TestMethod]
        public void UserEmail()
        {
            User user1 = new User();
            user1.Email = "local.test@domain.com";

            Assert.AreEqual("local.test@domain.com",user1.Email);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UserEmail2()
        {
            User user1 = new User();
            user1.Email = "local.test@_domain.com";
        }
    }
}
