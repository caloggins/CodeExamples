using Microsoft.EntityFrameworkCore;
using CodeExamples.Core.Posts;

namespace CodeExamples.Data.Posts;

public class GetPostById(IDataStore<Post> dataStore) : IGetPostById
{
    public async Task<Post> Handle(Guid id)
    {
        return await dataStore.Posts
            .FirstOrDefaultAsync(o => o.Id == id) ?? new NoSuchPost();
    }
}