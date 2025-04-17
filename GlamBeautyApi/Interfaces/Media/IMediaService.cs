using GlamBeautyApi.Dtos.Media;

namespace GlamBeautyApi.Interfaces.Media;

public interface IMediaService
{
    Task<IEnumerable<Entities.Media>> GetMediasAsync();
    Task<Entities.Media?> GetMediaAsync(string id);
    Task<Entities.Media> CreateMediaAsync(MediaCreateDto media);
    Task<Entities.Media?> UpdateMediaAsync(string id, MediaUpdateDto media);
    Task<bool> ExistsMedia(string id);
    Task<bool> DeleteMediaAsync(string id);
}