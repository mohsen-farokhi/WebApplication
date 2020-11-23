using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTest.MockSample
{
    public interface IPropertyHolder
    {
        int CustomerId { get; set; }
    }
    public interface IPropertyProxy
    {
        IPropertyHolder PropertyHolder { get; set; }
    }

    public interface ICustomerRepository
    {
        Customer Get(int id);
        void IsValidCustomer(out bool result);
        bool IsValidCustomer(int id);
        int CustomerId { get; set; }
        IPropertyProxy PropertyProxy { get; set; }
        public int UsedCount { get; set; }
        Customer GetFromMongoDb(int id);
        Customer GetFromSqlServer(int id);
    }
}
