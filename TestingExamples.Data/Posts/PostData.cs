using Microsoft.EntityFrameworkCore;
using TestingExamples.Core.Posts;

namespace TestingExamples.Data.Posts;

public class PostData : 
    DbContext,
    IDataStore<Post>
{
    public IQueryable<Post> Posts => Set<Post>();

    public async Task<Post> AddAsync(Post entity, CancellationToken token) =>
        (await AddAsync<Post>(entity, token)).Entity;
}