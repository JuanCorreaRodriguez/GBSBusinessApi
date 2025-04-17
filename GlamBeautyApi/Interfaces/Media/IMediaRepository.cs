namespace GlamBeautyApi.Interfaces.Media;

public interface IMediaRepository
{
    Task<List<Entities.Media>> GetMediasAsync();
    Task<Entities.Media?> GetMediaByIdAsync(string id);
    Task<Entities.Media> PostMediaAsync(Entities.Media media);
    Task<Entities.Media?> PutMediaAsync(Entities.Media mediaEntity);
    Task<bool> DeleteMediaAsync(string id);
    Task<bool> ExistsMedia(string id);
}