using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Concreates;
using Repositories.Contracts;

namespace Repositories.Bases
{
public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, new() //Abstract sınıf
{
    protected RepositoryContext _context; 

        public RepositoryBase(RepositoryContext context) //DI ve IoC
        { 
            _context = context;
        }

        public void Create(T entity)
        {

            _context.Set<T>().Add(entity);
        }

        //Set<T>(), Entity Framework'te belirli bir tabloya erişim sağlar. Bu metotta, Set<T>() ilgili T türündeki tabloyu temsil eder ve sorguların( CRUD) o tablo üzerinde çalışmasını sağlar.



        public IQueryable<T> Findall(bool trackChanges) //IRepositoryBase'den implement edilir.
        {
            return trackChanges                 //koşul
            ? _context.Set<T>()                 // trackChanges=true ise
            : _context.Set<T>().AsNoTracking(); //trackChanges=false ise

        }

        public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges
            ? _context.Set<T>().Where(expression).SingleOrDefault()
            :  _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();


        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}



            /*
            
            Ternary operatörü, C# ve birçok programlama dilinde kullanılan bir 
            kısaltılmış koşul ifadesidir. Bir koşula bağlı olarak iki farklı değerden 
            birini döndürmek için kullanılır ve genellikle if-else yapılarını 
            sadeleştirmek amacıyla tercih edilir.

            koşul ? doğruysa_değer : yanlışsa_değer;

            
            */


            /*
            Abstract sınıflar, doğrudan örneği (instance) oluşturulamayacak sınıflardır. 
            Yani, new anahtar kelimesi ile bu sınıftan bir nesne oluşturamazsın.
            Abstract sınıflar genellikle bir hiyerarşi içinde diğer sınıflar için bir temel oluşturur.
            Alt sınıflar, bu abstract sınıfı miras alarak (inheritance) 
            onun özelliklerini ve metotlarını devralır.
            
            */