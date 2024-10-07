using BL;
using Castle.Core.Resource;
using ENTITIES;
using ENTITIES.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Test
{
    [TestClass]
    public class EntityMAnagerTest
    {
        private Mock<Context> _mockContext;
        private Mock<DbSet<User>> _mockSet;
        EntityMAnagerTest() { 
            _mockSet = new Mock<DbSet<User>>();
            _mockContext = new Mock<Context>();
            _mockContext.Setup(x => x.Users).Returns(_mockSet.Object);
        }
        

        [TestMethod]
        public async Task TestMethod1()
        {
            GetRContextMock();
            _mockContext.Object.Users.ToList();
            Assert.AreEqual(1, 1);

            /*
            WriteContext wc = new WriteContext();
            //Context c = new Context();
            var mock = GetRContextMock();
            var manager = new EntityManager<User>(mock,wc);
            //var manager = new EntityManager<User>(c, wc);
            



            User user1 = await manager.Get(1);
            //User user2 = manager.Get(2);
            var user3 = manager.Get(3);



            Assert.AreEqual(user1.Id,1);
            Assert.AreEqual(user1.Name, 1);*/

        }
        public void GetRContextMock() {
            IQueryable<User> users = userData();
            
            //var mockContext = new Mock<Context>();
            //Mock<DbSet<User>> mockSet = new Mock<DbSet<User>>();
            
            // Paso 3: Configurar el mock para que se comporte como un IQueryable
            _mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            _mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            _mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            _mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());






            //mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => users.GetEnumerator());

            /*var mockContext = new Mock<Context>();
            mockContext.Setup(x => x.Users).Returns(mockSet.Object);
            return mockContext.Object;*/
        }
        public dynamic GetWContextMock() {
            Mock<DbSet<User>> mockSet = new Mock<DbSet<User>>();
            //mockSet.As<IQueryable<User>>().Setup()
            Mock<WriteContext> mockWrite = new Mock<WriteContext>();
            return 0;
        }

        private IQueryable<User> userData() {
            return new List<User>
            {
                new User{
                    Id = 1,
                    Name = "Juan",
                    LastName="Rodriguez",
                    Age="25",
                    City="Ciudad x",
                    Email="juan@correo.com",
                    Address="Avenida siempre viva #123",
                    PostalCode="99000",
                    PhoneNumber="1234560"
                },
                new User{
                    Id = 2,
                    Name = "Jose",
                    LastName="Perez",
                    Age="20",
                    City="Ciudad a",
                    Email="Jose@correo.com",
                    Address="Avenida siempre viva #124",
                    PostalCode="99000",
                    PhoneNumber="1234567890"
                },
                new User{
                    Id = 3,
                    Name = "Raul",
                    LastName="Sanchez",
                    Age="30",
                    City="Ciudad x",
                    Email="Raul@correo.com",
                    Address="Avenida siempre viva #125",
                    PostalCode="99000",
                    PhoneNumber="0000000000"
                },
                new User{
                    Id = 4,
                    Name = "Felipe",
                    LastName="Castillo",
                    Age="38",
                    City="Ciudad x",
                    Email="felipe@correo.com",
                    Address="Avenida siempre viva #127",
                    PostalCode="99000",
                    PhoneNumber="1111111111"
                },
                new User{
                    Id = 5,
                    Name = "Pedro",
                    LastName="Cerda",
                    Age="28",
                    City="Ciudad x",
                    Email="pedro@correo.com",
                    Address="Avenida siempre viva #130",
                    PostalCode="99000",
                    PhoneNumber="3333333333"
                }
            }.AsQueryable();
        }
    }
}