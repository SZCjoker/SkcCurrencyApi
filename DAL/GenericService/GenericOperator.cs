using SkcCurrencyApi.DAL.Interface;
using SkcCurrencyApi.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace SkcCurrencyApi.DAL.GenericService
{
    public class GenericOperator<T> where T : class
    {
        //private readonly DatabaseContext _context;
        //public GenericOperator(DatabaseContext context)
        //{
        //    _context = context;
        //}

        public T[] AllDatas()
        {
            IRepository<T> Repository = new GenericRepository<T>();
            var Result = Repository.GetAll().ToArray();
            return Result;
        }

        
        public T DataByKey(Expression<Func<T, bool>> predicate)
        {
            IRepository<T> Repository = new GenericRepository<T>();
            var Result = Repository.Get(predicate);
            return Result;
        }
        public T[] DatasByKeys(Expression<Func<T, bool>> predicate)
        {
            IRepository<T> Repository = new GenericRepository<T>();
            var Result = Repository.Query(predicate);
            return Result.ToArray();
        }

        
        public int DataCount(Expression<Func<T, bool>> predicate)
        {
            IRepository<T> Repository = new GenericRepository<T>();
            var Result = Repository.Query(predicate).Count();
            return Result;
        }

        public T[] Queries(Expression<Func<T, bool>> predicate)
        {
            IRepository<T> Repository = new GenericRepository<T>();
            var Result = Repository.Query(predicate).ToArray();
            return Result;
        }

        public bool Create(T data)
        {
            try
            {
                IRepository<T> Repository = new GenericRepository<T>();
                Repository.Create(data);
                return true;
            }

            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Expression<Func<T, bool>> predicate, T data)
        {
            try
            {

                IRepository<T> Repository = new GenericRepository<T>();
                // Repository.Create(data);
                Repository.CreateOrUpdate(predicate, data);
                return true;
            
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }

    }
}
