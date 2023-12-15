﻿using Ad.Application.Lib.Contracts.Tag;
using Ad.Domain.Core.Models;

namespace Ad.Infrastructure.Lib.Database;

public class TagRepository: ITagRepository
{
    public Task<bool> CreateTagAsync(Tag tag)
    {
        // after db connection there will be saving in db
        Console.WriteLine("saving tag in db");
        throw new NotImplementedException();
    }

    public Task<bool> DeleteTagAsync(Tag tag)
    {
        // after db connection there will be deleting from db
        Console.WriteLine("deleting tag from db");
        throw new NotImplementedException();
    }

    public Task<Tag> GetTagById(string id)
    {
        // after db connection there will be returning tag from db by id
        Console.WriteLine("returning tag from db by id");
        throw new NotImplementedException();
    }
}