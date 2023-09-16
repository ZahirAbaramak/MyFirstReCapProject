using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //generic constaint
    //class : referans tip
    //Ientity: sadece o sınıfı kullanıyor
    //new():Ientity kullanmaz ama Ientity nin referanslarını yazar
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        T Get(Expression<Func<T,bool>> filter);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        void Add(T Entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
