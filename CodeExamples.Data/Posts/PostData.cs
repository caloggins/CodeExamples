using Microsoft.EntityFrameworkCore;
using CodeExamples.Core.Posts;

namespace CodeExamples.Data.Posts;

public class PostData : 
    DbContext,
    IDataStore<Post>
{
    public IQueryable<Post> Posts => Set<Post>();

    public async Task<Post> AddAsync(Post entity, CancellationToken token) =>
        (await AddAsync<Post>(entity, token)).Entity;
}