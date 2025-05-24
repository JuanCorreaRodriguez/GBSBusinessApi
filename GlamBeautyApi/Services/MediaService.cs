using GBSApi.Dtos.Media;
using GBSApi.Interfaces.Media;
using GBSApi.Mappers;
using GBSApi.Queries;

namespace GBSApi.Services;

public class MediaService : IMediaService
{
    private readonly IMediaRepository _mediaRepository;

    public MediaService(IMediaRepository mediaRepository)
    {
        _mediaRepository = mediaRepository;
    }

    public async Task<List<MediaMinDto>> GetMediasAsync(QueryMedia queryMedia)
    {
        return await _mediaRepository.GetMediasAsync(queryMedia);
    }

    public async Task<MediaMinDto?> GetMediaAsync(string id)
    {
        return await _mediaRepository.GetMediaByIdAsync(id);
    }

    public async Task<MediaMinDto> CreateMediaAsync(MediaCreateDto media)
    {
        var mediaRes = await _mediaRepository.PostMediaAsync(media.CreateToEntity());
        return mediaRes.EntityToMinDto();
    }

    public async Task<MediaMinDto?> UpdateMediaAsync(string id, MediaUpdateDto media)
    {
        var mediaRes = await _mediaRepository.PutMediaAsync(id, media);
        return mediaRes.EntityToMinDto();
    }

    public async Task<bool> ExistsMedia(string id)
    {
        return await _mediaRepository.ExistsMedia(id);
    }

    public async Task<bool> DeleteMediaAsync(string id)
    {
        return await _mediaRepository.DeleteMediaAsync(id);
    }
}