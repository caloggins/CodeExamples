namespace CodeExamples.Core.Posts;

public class NoSuchPost : Post
{
    public NoSuchPost() => Id = Guid.NewGuid();
}