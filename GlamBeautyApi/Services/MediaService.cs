using GlamBeautyApi.Dtos.Media;
using GlamBeautyApi.Entities;
using GlamBeautyApi.Interfaces.Media;
using GlamBeautyApi.Mappers;

namespace GlamBeautyApi.Services;

public class MediaService : IMediaService
{
    private readonly IMediaRepository _mediaRepository;

    public MediaService(IMediaRepository mediaRepository)
    {
        _mediaRepository = mediaRepository;
    }

    public async Task<IEnumerable<Media>> GetMediasAsync()
    {
        return await _mediaRepository.GetMediasAsync();
    }

    public async Task<Media?> GetMediaAsync(string id)
    {
        return await _mediaRepository.GetMediaByIdAsync(id);
    }

    public async Task<Media> CreateMediaAsync(MediaCreateDto media)
    {
        return await _mediaRepository.PostMediaAsync(media.CreateToEntity());
    }

    public async Task<Media?> UpdateMediaAsync(string id, MediaUpdateDto media)
    {
        return await _mediaRepository.PutMediaAsync(media.UpdateToEntity());
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