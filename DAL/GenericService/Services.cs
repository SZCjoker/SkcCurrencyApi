using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkcCurrencyApi.DAL.GenericService
{
    public static class Services
    {
               
        public static GenericOperator<T> GetOp<T>() where T : class
        {


            GenericOperator<T> op = new GenericOperator<T>();
            return op;
        }
        public static GenericQuery<T> GetQ<T>() where T : class
        {
            GenericQuery<T> query = new GenericQuery<T>();
            return query;
        }
    }
}
