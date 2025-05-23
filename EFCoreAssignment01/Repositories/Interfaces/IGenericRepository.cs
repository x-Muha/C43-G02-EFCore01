namespace EFCoreAssignment01.Repositories.Interfaces
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        Task<bool> Delete(int id);
        Task<bool> Insert(TModel E);
        Task<IEnumerable<TModel>> Select();
        Task<TModel?> Select(int id);
        Task<int> Update(TModel E, int id);
    }
}