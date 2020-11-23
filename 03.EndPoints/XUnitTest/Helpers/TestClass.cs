using System;
namespace XUnitTest
{
    public class TestClass
    {
        public int Sum(int a, int b)
        {
            var result = a + b;
            return (result);
        }

        public int TestWithException()
        {
            throw new Exception();
        }
    }
}
