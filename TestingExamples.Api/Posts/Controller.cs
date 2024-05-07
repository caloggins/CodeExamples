using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TestingExamples.Core.Posts;

namespace TestingExamples.Api.Posts;

[ApiController]
public class Controller(IGetPostById getPostById)
{
    [HttpGet("/{guid:id}")]
    public async Task<Results<NotFound, Ok<Post>>> Get(Guid id)
    {
        var post = await getPostById.Handle(id);

        if (post is NoSuchPost)
            return TypedResults.NotFound();
        
        return TypedResults.Ok(post);
    }
    
    [HttpPost("/")]
    public async Task<Created> Post(Post post)
    {
        return TypedResults.Created();
    }
}