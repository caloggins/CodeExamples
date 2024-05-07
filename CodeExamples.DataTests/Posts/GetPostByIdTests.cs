using MockQueryable.FakeItEasy;
using CodeExamples.Core.Posts;
using CodeExamples.Data;
using CodeExamples.Data.Posts;

namespace CodeExamples.DataTests.Posts;

public class GetPostByIdTests
{
    private readonly IList<Post> posts;
    private readonly IDataStore<Post> repository;

    public GetPostByIdTests()
    {
        posts = A.CollectionOfDummy<Post>(10);
        repository = A.Fake<IDataStore<Post>>();
        A.CallTo(() => repository.Posts).ReturnsLazily(posts.BuildMock);
    }
    
    [Fact]
    public async void Handle_WhenPostExists_ReturnsPost()
    {
        var id = Guid.Parse("F28E234A-EAB8-42D3-8C75-715C2ACF5AE0");
        var expected = new Post { Id = id };
        posts.Add(expected);
        
        var sut = new GetPostById(repository);

        var result = await sut.Handle(id);

        result.Should().Be(expected);
    }

    [Fact]
    public async void Handle_WhenPostDoesNotExist_ResultsCorrectResult()
    {
        var sut = new GetPostById(repository);

        var id = Guid.Parse("F28E234A-EAB8-42D3-8C75-715C2ACF5AE0");
        var result = await sut.Handle(id);

        result.Should().BeOfType<NoSuchPost>();
    }
}

