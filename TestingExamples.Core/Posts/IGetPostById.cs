﻿namespace TestingExamples.Core.Posts;

public interface IGetPostById
{
    Task<Post> Handle(Guid id);
}