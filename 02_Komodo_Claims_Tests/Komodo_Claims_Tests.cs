using _02_Komodo_Claims_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _02_Komodo_Claims_Tests
{
    [TestClass]
    public class Komodo_Claims_Tests
    {
        [TestMethod]
        public void AbleToAddClaimToRepo()
        {
            //Arrange
            Claim newClaim = new Claim();
            ClaimRepository newClaimRepo = new ClaimRepository();
            //Act
            bool claimAdded = newClaimRepo.AddClaimToRepo(newClaim);
            //Assert
            Assert.IsTrue(claimAdded);
        }
    }
}
