namespace Atelier2.Models.Repositories
{
    public interface IRepository <Product>
    {
        Product Get(int Id);
        IEnumerable<Product> GetAll();
        Product Add(Product p);
        Product Update(Product p);
        Product Delete(int Id);
    }
}
