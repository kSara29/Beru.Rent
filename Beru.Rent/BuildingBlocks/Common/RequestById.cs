using FastEndpoints;

namespace Common;


public class RequestById
{
    [QueryParam] public Guid? Id { get; set; }
};