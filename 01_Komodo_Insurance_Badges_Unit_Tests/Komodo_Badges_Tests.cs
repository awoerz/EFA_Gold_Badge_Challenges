using _03_Komodo_Insurance_Badges_Class_Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _01_Komodo_Insurance_Badges_Unit_Tests
{
    [TestClass]
    public class Komodo_Badges_Tests
    {
        BadgeRepository TestBadgeRepo = new BadgeRepository();

        [TestInitialize]
        public void Arrange()
        {
            Badge newBadge = new Badge(1, new List<string>(){ "A1" });
            TestBadgeRepo.AddBadge(newBadge);
        }
        [TestMethod]
        public void ConfirmReceivingBadges()
        {
            //Arrange
            //Act
            Badge returnBadge = TestBadgeRepo.GetBadgeByID(1);
            //Assert
            Assert.IsTrue(returnBadge.GetType() == typeof(Badge));
        }
        [TestMethod]
        public void ConfirmAddingBadge()
        {
            //Arrange
            Badge anotherNewBadge = new Badge(2, new List<string>() { "A2" });
            int originalBadgeRepoLength = TestBadgeRepo.GetBadgeRepository().Count;
            //Act
            TestBadgeRepo.AddBadge(anotherNewBadge);
            int newBadgeRepoLength = TestBadgeRepo.GetBadgeRepository().Count;
            //Assert
            Assert.IsTrue(newBadgeRepoLength > originalBadgeRepoLength);
        }
        [TestMethod]
        public void ConfirmGetBadgeDictionary()
        {
            //Arrange
            //Act
            Dictionary<int, List<string>> badgeDictionary = TestBadgeRepo.GetBadgeDictionary();
            //Assert
            Assert.IsNotNull(badgeDictionary);
        }
    }
}
