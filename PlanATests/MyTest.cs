using Foundation;
using UIKit;
using PlanA;
using System;
using NUnit.Framework;

namespace PlanATests
{
    [TestFixture]
    public class MyTest
    {
        [Test]
        public void LoginPass()
        {
            SQLHandler sqlHandler = new SQLHandler("applicationdatabase.crzemhmmicsu.us-east-2.rds.amazonaws.com", "3306", "PlanA", "planA", "shalyssa");
            Assert.True(sqlHandler.GetLogin("landonclark97", "Password"));
        }

        [Test]
        public void LoginFail()
        {
            SQLHandler sqlHandler = new SQLHandler("applicationdatabase.crzemhmmicsu.us-east-2.rds.amazonaws.com", "3306", "PlanA", "planA", "shalyssa");
            Assert.False(sqlHandler.GetLogin("landonclark97", "bob"));
        }

        [Test]
        public void CreateAccountPass()
        {
            SQLHandler sqlHandler = new SQLHandler("applicationdatabase.crzemhmmicsu.us-east-2.rds.amazonaws.com", "3306", "PlanA", "planA", "shalyssa");
            Assert.True(sqlHandler.CreateAccount("Donny", "Dave", "horus@xavier.edu", "John", "Bill"));
        }

        [Test]
        public void CreateAccountFail()
        {
            SQLHandler sqlHandler = new SQLHandler("applicationdatabase.crzemhmmicsu.us-east-2.rds.amazonaws.com", "3306", "PlanA", "planA", "shalyssa");
            Assert.False(sqlHandler.CreateAccount("landonclark97", "bob", "bill@xavier.edu", "John", "Bill"));
        }

        [Test]
        [Ignore("another time")]
        public void Ignore()
        {
            Assert.True(false);
        }
    }
}
