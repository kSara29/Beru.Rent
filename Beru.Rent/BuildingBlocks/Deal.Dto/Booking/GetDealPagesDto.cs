namespace Deal.Dto.Booking;

public class GetDealPagesDto<T>
{
    public List<T> DealPageDto { get; set; }
    public int TotalPage { get; set; }

    public GetDealPagesDto(List<T> dealPageDto, int totalPage)
    {
        DealPageDto = dealPageDto;
        TotalPage = totalPage;
    }
}