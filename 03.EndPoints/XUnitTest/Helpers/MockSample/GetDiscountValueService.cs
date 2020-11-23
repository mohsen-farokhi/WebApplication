using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTest.MockSample
{
    public class TestProtected
    {
        protected virtual int GetInt()
        {
            return (1);
        }
    }

    public enum DbEngine
    {
        Mongo,
        SqlServer
    }
    public class GetDiscountValueService
    {
        private readonly ICustomerRepository _customerRepository;
        public GetDiscountValueService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public int Execute(int customerId)
        {
            var customer = _customerRepository.Get(customerId);
            _customerRepository.UsedCount += 1;
            switch (customer.CustomerType)
            {
                case CustomerType.Usual:
                    return (1000);
                case CustomerType.Silver:
                    return (2000);
                case CustomerType.Gold:
                    return (10000);
            }
            return (0);
        }

        public bool IsValidCustomer(int customerId)
        {
            _customerRepository.IsValidCustomer(out bool temp);
            return (temp);
        }

        public Customer GetCustomer(int customerId,DbEngine dbEngine)
        {
            Customer customer = new Customer();
            switch (dbEngine)
            {
                case DbEngine.Mongo:
                    customer = _customerRepository.GetFromMongoDb(customerId);
                    break;
                case DbEngine.SqlServer:
                    customer = _customerRepository.GetFromSqlServer(customerId);
                    break;
            }
            return (customer);
        }
    }
}
