using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoPhotoAlbum.Models;

namespace DemoPhotoAlbum.Repositories {
  public class PhotoAlbumRepository : IPhotoAlbumRepository {
    private readonly PhotoAlbumWebApiClient client;

    public PhotoAlbumRepository(PhotoAlbumWebApiClient client) {
      this.client = client;
    }

    public IEnumerable<PhotoAlbum> GetPhotoAlbums(int? userId = null) {
      return GetPhotoAlbumsAsync(userId).Result;
    }

    public async Task<IEnumerable<PhotoAlbum>> GetPhotoAlbumsAsync(int? userId = null) {
      IEnumerable<Album> emptyAlbums = userId.HasValue ? await client.GetAlbumsAsync(userId.Value) : await client.GetAlbumsAsync();
      // Get the photos for each of the emptyAlbums and run the requests in parallel.
      IEnumerable<Photo> photos = (await Task.WhenAll(emptyAlbums.Select(a => client.GetPhotosAsync(a.Id)))).SelectMany(p => p);
      IEnumerable<PhotoAlbum> photoAlbums = emptyAlbums.Select(a => new PhotoAlbum(a, photos));
      return photoAlbums;
    }
  }
}
