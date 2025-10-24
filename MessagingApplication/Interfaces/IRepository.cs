using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingApplication.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T model);
        List<T> GetAll();
        void Delete(T model);
    }
}