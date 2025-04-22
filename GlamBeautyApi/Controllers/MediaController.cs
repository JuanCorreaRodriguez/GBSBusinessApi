using GlamBeautyApi.Dtos.Media;
using GlamBeautyApi.Dtos.Unions;
using GlamBeautyApi.ErrorHandler;
using GlamBeautyApi.Interfaces.Media;
using GlamBeautyApi.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GlamBeautyApi.Controllers;

[Route("api/media")]
[ApiController]
public class MediaController : ControllerBase
{
    private readonly IMediaService _mediaService;

    public MediaController(IMediaService mediaService)
    {
        _mediaService = mediaService;
    }

    [HttpGet]
    [Authorize]
    public async Task<Result<List<MediaMinDto>>> GetAllMedia([FromQuery] QueryMedia queryMedia)
    {
        var medias = await _mediaService.GetMediasAsync(queryMedia);

        return medias.Count == 0
            ? Result<List<MediaMinDto>>.Failure(Errors.Errors.NoContent)
            : Result<List<MediaMinDto>>.Success(medias);
    }

    [HttpGet]
    [Authorize]
    [Route("{id}")]
    public async Task<Result<MediaMinDto>> GetMediaByIdAsync([FromRoute] string id)
    {
        if (id == "")
            return Result<MediaMinDto>.Failure(Errors.Errors.DtoError);

        var media = await _mediaService.GetMediaAsync(id);
        return media == null
            ? Result<MediaMinDto>.Failure(Errors.Errors.NoContent)
            : Result<MediaMinDto>.Success(media);
    }

    [HttpPost]
    [Authorize]
    [Consumes("application/json")]
    public async Task<Result<MediaMinDto>> AddMediaAsync(MediaCreateDto dto)
    {
        if (!ModelState.IsValid)
            return Result<MediaMinDto>.Failure(Errors.Errors.DtoError);

        var media = await _mediaService.CreateMediaAsync(dto);
        return Result<MediaMinDto>.Success(media);
    }

    [HttpPut]
    [Authorize]
    [Route("{id}")]
    public async Task<Result<MediaMinDto>> UpdateMediaAsync([FromRoute] string id, MediaUpdateDto dto)
    {
        if (!ModelState.IsValid)
            Result<MediaMinDto>.Failure(Errors.Errors.DtoError);

        var media = await _mediaService.UpdateMediaAsync(id, dto);
        return media != null
            ? Result<MediaMinDto>.Success(media)
            : Result<MediaMinDto>.Failure(Errors.Errors.NoContent);
    }

    [HttpDelete]
    [Authorize]
    public async Task<Result<Global>> DeleteMediaAsync([FromRoute] string id)
    {
        if (id == "")
            Result<Global>.Failure(Errors.Errors.DtoError);

        var result = await _mediaService.DeleteMediaAsync(id);

        return result
            ? Result<Global>.Success(new Global
            {
                id = id
            })
            : Result<Global>.Failure(Errors.Errors.NotFound);
    }
}