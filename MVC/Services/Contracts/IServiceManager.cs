namespace Services.Contracts
{

    public interface IServiceManager
    {

        IProductServices ProductServices {get;}
        ICategoryServices  CategoryServices {get;}
        
    }



}