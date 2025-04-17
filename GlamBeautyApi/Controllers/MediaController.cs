using GlamBeautyApi.Dtos.Media;
using GlamBeautyApi.Interfaces.Media;
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
    // [Authorize]
    public async Task<IActionResult> GetAllMedia()
    {
        var medias = await _mediaService.GetMediasAsync();
        if (!medias.Any()) return NoContent();
        return Ok(medias);
    }

    [HttpGet("{id}")]
    // [Authorize]
    public async Task<IActionResult> GetMediaByIdAsync([FromRoute] string id)
    {
        if (id == "")
            return BadRequest(ModelState);

        var media = await _mediaService.GetMediaAsync(id);
        if (media == null) return NotFound("Media not found");
        return Ok(media);
    }

    [HttpPost]
    // [Authorize]
    [Consumes("application/json")]
    public async Task<IActionResult> AddMediaAsync(MediaCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var media = await _mediaService.CreateMediaAsync(dto);
        return Ok(media);
    }

    [HttpPut]
    // [Authorize]
    [Route("{id}")]
    public async Task<IActionResult> UpdateMediaAsync([FromRoute] string id, MediaUpdateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var media = await _mediaService.UpdateMediaAsync(id, dto);
        if (media == null) NotFound("Media does not exist");
        return Ok(media);
    }

    [HttpDelete]
    // [Authorize]
    public async Task<IActionResult> DeleteMediaAsync([FromRoute] string id)
    {
        if (id == "")
            return BadRequest(ModelState);

        var result = await _mediaService.DeleteMediaAsync(id);
        if (!result) return NotFound("Something went wrong deleting media");
        return Ok(result);
    }
}