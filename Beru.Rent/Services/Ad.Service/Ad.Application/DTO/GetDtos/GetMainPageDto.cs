using Ad.Domain.Models;

namespace Ad.Application.DTO.GetDtos;

public class GetMainPageDto<T>
{
    public List<T> MainPageDto { get; set; }
    public int TotalPage { get; set; }

    public GetMainPageDto(List<T> mainPageDto, int totalPage)
    {
        MainPageDto = mainPageDto;
        TotalPage = totalPage;
    }
}