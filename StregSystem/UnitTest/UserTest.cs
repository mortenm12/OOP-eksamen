using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StregSystem;

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
    }
}
