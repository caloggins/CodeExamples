using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using CodeExamples.Core.Posts;
using Controller = CodeExamples.Api.Posts.Controller;

namespace CodeExamples.ApiTests.Posts;

public class ControllerTests
{
    private readonly IGetPostById getPostById;

    public ControllerTests()
    {
        getPostById = A.Fake<IGetPostById>();
        var dummy = A.Dummy<NoSuchPost>();
        A.CallTo(() => getPostById.Handle(A<Guid>._)).Returns(dummy);
    }
    
    [Fact]
    public async void Get_WhenNothingIsFound_ReturnsNotFound()
    {
        var sut = new Controller(getPostById);

        var results = (await sut.Get(Guid.Empty));

        results.Result.Should().NotBeNull();
    }
    
    [Fact]
    public async void Get_WhenItemExists_ReturnsItem()
    {
        var post = A.Dummy<Post>();
        var id = Guid.Parse("79205db90fc449f585749d45a6d078f2");
        A.CallTo(() => getPostById.Handle(id)).Returns(post);
        
        var sut = new Controller(getPostById);

        var results = (Ok<Post>)(await sut.Get(id)).Result;

        results.Value.Should().BeEquivalentTo(post);
    }

    [Fact]
    public async void Post_WhenItSaves_ReturnsCorrectResponse()
    {
        var post = A.Dummy<Post>();
        var sut = new Controller(getPostById);

        var results = await sut.Post(post);
        
        results.StatusCode.Should().Be(201);
    }
}