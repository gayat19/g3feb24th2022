using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using RevisionApplication.Models;
using RevisionApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisionTest
{
    public class TestUserRepo
    {
        [Test]
        [TestCase("Ramu")]
        [TestCase("Bimu")]
        public void TestGetAll(string name)
        {
            //Arrange
            //StoreContext context = new StoreContext();
            List<User> users = new List<User>
            {
                new User{Username="Ramu",Password="123",Role="Admin"},
                new User{Username="Somu",Password="123",Role="user"}
            };
           Mock<DbSet<User>> moqDbSet = new Mock<DbSet<User>>();
            var queriableUsers = users.AsQueryable();
            moqDbSet.As<IQueryable<User>>().Setup(usr => usr.Provider).Returns(queriableUsers.Provider);
            moqDbSet.As<IQueryable<User>>().Setup(usr => usr.Expression).Returns(queriableUsers.Expression);
            moqDbSet.As<IQueryable<User>>().Setup(usr => usr.ElementType).Returns(queriableUsers.ElementType);
            moqDbSet.As<IQueryable<User>>().Setup(usr => usr.GetEnumerator()).Returns(queriableUsers.GetEnumerator());

            Mock<StoreContext> mockContext = new Mock<StoreContext>();
            mockContext.Setup(ctx => ctx.Users).Returns(moqDbSet.Object);
            IRepo<string, User> repo = new UserRepo(mockContext.Object );

            //Act
            var result = repo.Get("Ramu");

            //Assert
            Assert.AreEqual(name, result.Username);
        }
    }
}
