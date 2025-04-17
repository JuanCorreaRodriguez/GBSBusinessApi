using GlamBeautyApi.Connections;
using GlamBeautyApi.Entities;
using GlamBeautyApi.Interfaces.Media;
using Microsoft.EntityFrameworkCore;

namespace GlamBeautyApi.Repository;

public class MediaRepository : IMediaRepository
{
    private readonly PostgreDbContext _context;

    public MediaRepository(PostgreDbContext context)
    {
        _context = context;
    }

    public async Task<List<Media>> GetMediasAsync()
    {
        var medias = await _context.Media
            .Select(media => new Media
            {
                MediaId = media.MediaId,
                Metadata = media.Metadata,
                Reference = media.Reference
                // Brand = media.Brand
            })
            .ToListAsync();
        return medias;
    }

    public async Task<Media?> GetMediaByIdAsync(string id)
    {
        var media = await _context.Media
            .Select(media => new Media
            {
                MediaId = media.MediaId,
                Metadata = media.Metadata,
                Reference = media.Reference,
                Brand = media.Brand
            }).FirstOrDefaultAsync(o => o.MediaId == Guid.Parse(id));
        return media;
    }

    public async Task<Media> PostMediaAsync(Media media)
    {
        var result = await _context.Media.AddAsync(media);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Media?> PutMediaAsync(Media mediaEntity)
    {
        var media = await GetMediaByIdAsync(mediaEntity.MediaId.ToString());
        if (media == null) return null;

        if (!string.IsNullOrEmpty(mediaEntity.Metadata)) media.Metadata = mediaEntity.Metadata;
        if (!string.IsNullOrEmpty(mediaEntity.Reference)) media.Reference = mediaEntity.Reference;

        await _context.SaveChangesAsync();
        return media;
    }

    public async Task<bool> DeleteMediaAsync(string id)
    {
        var media = await GetMediaByIdAsync(id);

        if (media == null) return false;
        _context.Media.Remove(media);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ExistsMedia(string id)
    {
        return await _context.Media.AnyAsync(o => o.MediaId == Guid.Parse(id));
    }
}