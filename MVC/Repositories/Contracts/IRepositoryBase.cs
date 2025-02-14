using System.Linq.Expressions;

namespace Repositories.Contracts
{

    public interface IRepositoryBase<T>//Soyut bir IRepositoryBase tanımlanmıştır.
    {
        IQueryable<T> Findall (bool trackChanges);

        T? FindByCondition(Expression<Func<T,bool>> expression, bool trackChanges);

        void Create(T entity);
        void Remove(T entity);
        void Update (T entity);
    }

}

/*


IRepositoryBase genellikle Repository Pattern’in bir parçası olarak kullanılan bir arayüzdür ve her tür veri varlığı (entity) ile çalışan temel 
CRUD (Create, Read, Update, Delete) işlemlerini tanımlar. Unit of Work (UoW) deseni ile bir arada kullanıldığında, 
veri erişimini daha modüler ve yönetilebilir hale getirir.

IRepositoryBase<T> arayüzü, veri modelleri üzerinde yapılacak temel veri erişim işlemlerinin
soyut bir tanımını sağlar. Ancak burada sadece ne tür işlemler yapılacağı belirtilmiştir;
bu işlemlerin nasıl yapılacağı ise başka bir sınıfta, yani somut bir sınıfta uygulanmalıdır.

*/ 