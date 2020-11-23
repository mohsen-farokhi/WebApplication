using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace XUnitTest
{
    public class MyDataAttribute : DataAttribute // استفاده از اتریبیوت برای دیتا پرووایدر
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var data = new List<object[]>();
            data.Add(new object[] { 1, 2, 3 });
            data.Add(new object[] { 4, 5, 9 });
            return (data);
        }
    }

    public static class DataProvider // خروجی گرفتن دیتا از یک کلاس بجای استفاده از دیتای هاردکد
    {
        public static List<object[]> MyData()
        {
            var data = new List<object[]>();
            data.Add(new object[] { 1, 2, 3 });
            data.Add(new object[] { 4, 5, 9 });
            return (data);
        }
    }

    public class TestFixture // یک نمونه برای تمام تست ها
    {
        public TestClass test = new TestClass();
    }
    public class UnitTest1 : IClassFixture<TestFixture>
    {
        private readonly ITestOutputHelper _output; // ابزار کامنت نویسی
        private TestClass _testController;
        public UnitTest1(ITestOutputHelper output, TestFixture testFixture)
        {
            _output = output;
            _testController = testFixture.test;
        }

        [Fact]
        [Trait("GroupTitle", "Group1")] // دسته بندی تستها
        public void Should_Return3_When_Sum2And1()
        {
            int result = _testController.Sum(2, 1);
            Assert.Equal(3, result);
        }

        //[Fact(Skip ="comment")] // غیر فعال سازی تست
        [Fact]
        [Trait("GroupTitle", "Group2")]
        public void Should_Throw_Exception()
        {
            _output.WriteLine("Hello Mohsen");// کامنت نویسی در تست
            Assert.Throws<Exception>(() => _testController.TestWithException());
        }

        [Theory]
        [InlineData(1, 2, 3)] // ورودی و خروجی های متفاوت
        [InlineData(4, 5, 9)]
        public void ShareData(int val1, int val2, int output)
        {
            var result = _testController.Sum(val1, val2);
            Assert.Equal(output, result);
        }

        [Theory]
        [MemberData(nameof(DataProvider.MyData),MemberType = typeof(DataProvider))] // استفاده از دیتا پرووایدر
        public void ShareMemberData(int val1, int val2, int output)
        {
            var result = _testController.Sum(val1, val2);
            Assert.Equal(output, result);
        }

        [Theory]
        [MyData] // استفاده از اتریبیوت دیتا پرووایدر
        public void ShareDataAttribute(int val1, int val2, int output)
        {
            var result = _testController.Sum(val1, val2);
            Assert.Equal(output, result);
        }
    }
}
