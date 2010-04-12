namespace Lingual.Tests.Domain
{
    public interface IRepository<T>
    {
        T Get(long id);
    }
}