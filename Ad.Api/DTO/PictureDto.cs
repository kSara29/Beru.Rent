﻿namespace Ad.Api.DTO;

public class PictureDto
{
    public string UserId { get; set; }
    public IFormFile PictureFile { get; set; }
    public Guid AdId { get; set; }
}