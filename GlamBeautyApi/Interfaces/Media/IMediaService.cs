using GlamBeautyApi.Dtos.Media;
using GlamBeautyApi.Queries;

namespace GlamBeautyApi.Interfaces.Media;

public interface IMediaService
{
    Task<List<MediaMinDto>> GetMediasAsync(QueryMedia queryMedia);
    Task<MediaMinDto?> GetMediaAsync(string id);
    Task<MediaMinDto> CreateMediaAsync(MediaCreateDto media);
    Task<MediaMinDto?> UpdateMediaAsync(string id, MediaUpdateDto media);
    Task<bool> ExistsMedia(string id);
    Task<bool> DeleteMediaAsync(string id);
}