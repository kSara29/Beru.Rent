using FastEndpoints;

namespace Ad.Dto.RequestDto;

public class FindMainPageRequestDto
{ 
    [QueryParam] public int Page { get; set; }
    [QueryParam] public string SortDate { get; set; }
    [QueryParam] public string SortPrice { get; set; }
    [QueryParam] public string CategoryName { get; set; }
    [QueryParam] public string Finder { get; set; }
}