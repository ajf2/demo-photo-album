using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoPhotoAlbum.Models;

namespace DemoPhotoAlbum.Repositories {
  /// <summary>
  /// Uses a Web API to fetch album and photo data.
  /// </summary>
  public class PhotoAlbumRepository : IPhotoAlbumRepository {
    // Remote Web API client, assigned through dependency injection in the constructor.
    private readonly PhotoAlbumWebApiClient client;

    public PhotoAlbumRepository(PhotoAlbumWebApiClient client) {
      this.client = client;
    }

    /// <summary>
    /// Returns <see cref="PhotoAlbum"/>s from the remote service. Blocks until completion.
    /// </summary>
    /// <param name="userId">The user Id to filter by.</param>
    /// <returns>A collection of <see cref="PhotoAlbum"/>s.</returns>
    public IEnumerable<PhotoAlbum> GetPhotoAlbums(int userId) {
      return GetPhotoAlbumsAsync(userId).Result;
    }

    /// <summary>
    /// Asynchronously returns <see cref="PhotoAlbum"/>s from the remote service.
    /// </summary>
    /// <param name="userId">The user Id to filter by.</param>
    /// <returns>A collection of <see cref="PhotoAlbum"/>s.</returns>
    public async Task<IEnumerable<PhotoAlbum>> GetPhotoAlbumsAsync(int userId) {
      IEnumerable<Album> emptyAlbums = await client.GetAlbumsAsync(userId);
      // Get the photos for each of the emptyAlbums and run the requests in parallel.
      IEnumerable<Photo> photos = (await Task.WhenAll(emptyAlbums.Select(a => client.GetPhotosAsync(a.Id)))).SelectMany(p => p);
      IEnumerable<PhotoAlbum> photoAlbums = emptyAlbums.Select(a => new PhotoAlbum {
        UserId = a.UserId,
        Id = a.Id,
        Title = a.Title,
        Photos = photos.Where(p => p.AlbumId == a.Id)
      });
      return photoAlbums;
    }
  }
}
