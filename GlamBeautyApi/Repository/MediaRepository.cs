using GBSApi.Connections;
using GBSApi.Dtos.Brand;
using GBSApi.Dtos.Category;
using GBSApi.Dtos.Media;
using GBSApi.Dtos.Unions;
using GBSApi.Entities;
using GBSApi.Interfaces.Media;
using GBSApi.Queries;
using Microsoft.EntityFrameworkCore;

namespace GBSApi.Repository;

public class MediaRepository : IMediaRepository
{
    private readonly PostgreDbContext _context;

    public MediaRepository(PostgreDbContext context)
    {
        _context = context;
    }

    public async Task<List<MediaMinDto>> GetMediasAsync(QueryMedia queryMedia)
    {
        var qMedias = _context.Media
            .Select(media => new MediaMinDto
            {
                Name = media.Name,
                MediaId = media.MediaId,
                Metadata = media.Metadata,
                Reference = media.Reference,
                Brand = media.Brand.Select(o => new BrandMinInnerDto
                {
                    Ranking = o.Ranking,
                    Name = o.Name,
                    Description = o.Description
                }).ToList()
            })
            .AsQueryable();

        if (!string.IsNullOrEmpty(queryMedia.SortBy))
            if (queryMedia.SortBy.Equals("name", StringComparison.OrdinalIgnoreCase))
                qMedias = qMedias.OrderBy(media => media.Name);

        var skipNum = (queryMedia.PegeNumber - 1) * queryMedia.PageSize;
        var skip = skipNum ?? 0;
        var pSize = queryMedia.PageSize ?? 0;
        return await qMedias.Skip(skip).Take(pSize).ToListAsync();
    }

    public async Task<MediaMinDto?> GetMediaByIdAsync(string id)
    {
        var media = await _context.Media
            .Select(media => new MediaMinDto
            {
                Name = media.Name,
                MediaId = media.MediaId,
                Metadata = media.Metadata,
                Reference = media.Reference,
                Brand = media.Brand.Select(o => new BrandMinInnerDto
                {
                    Ranking = o.Ranking,
                    Name = o.Name,
                    Description = o.Description
                }).ToList(),
                Category = media.Category.Select(o => new CategoryMinDto
                {
                    Name = o.Name,
                    CategoryId = o.CategoryId,
                    Desc = o.Description,
                    Type = o.Type
                }).ToList()
            }).FirstOrDefaultAsync(o => o.MediaId == Guid.Parse(id));
        return media;
    }

    public Task<Media?> GetMediaEntityByIdAsync(string id)
    {
        return _context.Media
            .Include(o => o.Brand)
            .FirstOrDefaultAsync(o => o.MediaId == Guid.Parse(id));
    }

    public async Task<Media> PostMediaAsync(Media media)
    {
        var result = await _context.Media.AddAsync(media);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Media?> PutMediaAsync(string id, MediaUpdateDto mediaEntity)
    {
        var media = await _context.Media.FirstOrDefaultAsync(o => o.MediaId == Guid.Parse(id));

        if (media == null) return null;
        if (!string.IsNullOrEmpty(mediaEntity.Name)) media.Name = mediaEntity.Name;
        if (!string.IsNullOrEmpty(mediaEntity.Metadata)) media.Metadata = mediaEntity.Metadata;
        if (!string.IsNullOrEmpty(mediaEntity.Reference)) media.Reference = mediaEntity.Reference;
        await _context.SaveChangesAsync();

        return media;
    }

    public async Task<bool> DeleteMediaAsync(string id)
    {
        var media = await GetMediaEntityByIdAsync(id);

        if (media == null) return false;
        _context.Media.Remove(media);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ExistsMedia(string id)
    {
        return await _context.Media.AnyAsync(o => o.MediaId == Guid.Parse(id));
    }

    public async Task<List<Media>> GetMediaFromList(List<Ids> mediasIdsList)
    {
        List<Media> media = [];
        foreach (var obj in mediasIdsList)
        {
            var mediaEntity = await GetMediaEntityByIdAsync(obj.Id);
            if (mediasIdsList != null) media.Add(mediaEntity!);
        }

        return media;
    }
}