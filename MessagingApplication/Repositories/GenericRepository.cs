using MessagingApplication.Extensions;
using MessagingApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingApplication.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected List<T> _list;

        public GenericRepository(List<T> list)
        {
            _list = list;
        }
        public void Add(T model)
        {
            _list.Add(model);
        }

        public void Delete(T model)
        {
            _list.Remove(model);
        }

        public List<T> GetAll()
        {
            return _list;
        }
    }
}
