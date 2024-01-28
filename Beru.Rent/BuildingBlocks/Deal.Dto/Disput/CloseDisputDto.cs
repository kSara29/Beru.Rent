namespace Deal.Dto.Disput;

public record CloseDisputDto(
    string DealId,
    DateTime ClosedAt
);
