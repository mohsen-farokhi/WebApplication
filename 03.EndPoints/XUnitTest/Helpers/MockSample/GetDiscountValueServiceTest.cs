using Moq;
using Moq.Protected;
using System;
using Xunit;

namespace XUnitTest.MockSample
{
    public class GetDiscountValueServiceTest
    {
        [Fact]
        public void When_CustomerIsUsual_Get1000()
        {
            Mock<ICustomerRepository> mockCustomerRepository =
                new Mock<ICustomerRepository>();

            mockCustomerRepository.Setup(c => c.Get(It.IsAny<int>())).Returns(new Customer
            {
                CustomerType = CustomerType.Usual
            });

            GetDiscountValueService service =
                new GetDiscountValueService(mockCustomerRepository.Object);

            var result = service.Execute(2);
            Assert.Equal(1000, result);
        }

        [Fact]
        public void TestOutputParameters()
        {
            Mock<ICustomerRepository> mockCustomerRepository =
                new Mock<ICustomerRepository>();
            bool result = true;
            mockCustomerRepository.Setup(c => c.IsValidCustomer(out result));

            GetDiscountValueService service =
                new GetDiscountValueService(mockCustomerRepository.Object);
            service.IsValidCustomer(1);
            Assert.True(result);
        }

        [Fact]
        public void TestProperties()
        {
            Mock<ICustomerRepository> mockCustomerRepository =
                new Mock<ICustomerRepository>();

            mockCustomerRepository.Setup(c => c.CustomerId).Returns(1);

            GetDiscountValueService service =
                new GetDiscountValueService(mockCustomerRepository.Object);

        }

        [Fact]
        public void TestNestedProperties()
        {
            Mock<ICustomerRepository> mockCustomerRepository =
                new Mock<ICustomerRepository>();
            mockCustomerRepository.Setup(c => c.PropertyProxy.PropertyHolder.CustomerId).Returns(1);
        }

        [Fact]
        public void CheckStateManagement()
        {
            Mock<ICustomerRepository> mockCustomerRepository =
                new Mock<ICustomerRepository>();
            mockCustomerRepository.SetupProperty(c => c.UsedCount); // نگهداری مقدار
            //mockCustomerRepository.SetupAllProperties(); // نگهداری تمام مقدار
            mockCustomerRepository.Setup(c => c.Get(It.IsAny<int>())).Returns(new Customer
            {
                CustomerType = CustomerType.Usual
            });

            GetDiscountValueService service =
                new GetDiscountValueService(mockCustomerRepository.Object);

            var result = service.Execute(2);
            Assert.Equal(1000, result);
        }

        [Fact]
        public void CheckDatabaseEngine() // تست عملکرد سیستم
        {
            Mock<ICustomerRepository> mockCustomerRepository =
                new Mock<ICustomerRepository>();

            GetDiscountValueService service =
                new GetDiscountValueService(mockCustomerRepository.Object);

            var result = service.GetCustomer(1, DbEngine.Mongo);

            //mockCustomerRepository.Verify(c=>c.GetFromMongoDb(It.IsAny<int>()));
            mockCustomerRepository.Verify(c => c.GetFromMongoDb(It.IsAny<int>()), Times.Once);//یکبار باید اجرا شود
            mockCustomerRepository.Verify(c => c.GetFromMongoDb(It.IsAny<int>()), Times.Never);//نباید اجرا شود
            //mockCustomerRepository.VerifySet(c => c.CustomerId = 1); // باید حتما به این مقدار ست شده باشد

        }

        [Fact]
        public void CheckException()
        {
            Mock<ICustomerRepository> mockCustomerRepository =
                new Mock<ICustomerRepository>();

            mockCustomerRepository.Setup(c => c.Get(12345)).Throws<Exception>();

            GetDiscountValueService service =
                new GetDiscountValueService(mockCustomerRepository.Object);
        }

        [Fact]
        public void CheckSeq()
        {
            Mock<ICustomerRepository> mockCustomerRepository =
                new Mock<ICustomerRepository>();
            mockCustomerRepository.SetupSequence(c => c.IsValidCustomer(1)).Returns(true).Returns(false);

            GetDiscountValueService service =
                new GetDiscountValueService(mockCustomerRepository.Object);

        }

        [Fact]
        public void CheckProtected()
        {
            Mock<TestProtected> mock = new Mock<TestProtected>();
            mock.Protected().Setup("GetInt");
        }


    }
}
