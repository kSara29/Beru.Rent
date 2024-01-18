namespace Deal.Application.DTO.Disput;

public record CloseDisputDto(
    string DealId,
    DateTime ClosedAt
);
