namespace BulkyBook.Data.IRepositories
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        ICoverTypeRepository CoverTypes { get; }
        IProductRepository Products { get; }
        void Save();
    }
}
