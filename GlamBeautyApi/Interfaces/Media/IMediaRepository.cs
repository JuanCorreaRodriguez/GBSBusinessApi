using GlamBeautyApi.Dtos.Media;
using GlamBeautyApi.Dtos.Unions;
using GlamBeautyApi.Queries;

namespace GlamBeautyApi.Interfaces.Media;

public interface IMediaRepository
{
    Task<List<MediaMinDto>> GetMediasAsync(QueryMedia queryMedia);
    Task<MediaMinDto?> GetMediaByIdAsync(string id);
    Task<Entities.Media?> GetMediaEntityByIdAsync(string id);
    Task<Entities.Media> PostMediaAsync(Entities.Media media);
    Task<Entities.Media?> PutMediaAsync(string id, MediaUpdateDto mediaEntity);
    Task<bool> DeleteMediaAsync(string id);
    Task<bool> ExistsMedia(string id);
    Task<List<Entities.Media>> GetMediaFromList(List<Ids> mediasIdsList);
}