using CodeExamples.Core.Posts;

namespace CodeExamples.Data;

public interface IDataStore<T> where T : class
{
    IQueryable<T> Posts { get; }
    Task<Post> AddAsync(T entity, CancellationToken token);
    Task<int> SaveChangesAsync(CancellationToken token);
}
