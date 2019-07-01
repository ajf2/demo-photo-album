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

    public IEnumerable<Album> GetPhotoAlbums() {
      return GetPhotoAlbumsAsync().Result;
    }

    public IEnumerable<Album> GetPhotoAlbums(int userId) {
      return GetPhotoAlbumsAsync(userId).Result;
    }

    public async Task<IEnumerable<Album>> GetPhotoAlbumsAsync() {
      IEnumerable<Album> emptyAlbums = await this.client.GetAlbumsAsync();
      IEnumerable<Photo> photos = (await Task.WhenAll(emptyAlbums.Select(a => this.client.GetPhotosAsync(a.Id)))).SelectMany(p => p);
      IEnumerable<Album> photoAlbums = emptyAlbums.Select(a => {
        a.Photos = photos.Where(p => p.AlbumId == a.Id);
        return a;
      });
      return photoAlbums;
    }

    public async Task<IEnumerable<Album>> GetPhotoAlbumsAsync(int userId) {
      IEnumerable<Album> emptyAlbums = await this.client.GetAlbumsAsync(userId);
      IEnumerable<Photo> photos = (await Task.WhenAll(emptyAlbums.Select(a => this.client.GetPhotosAsync(a.Id)))).SelectMany(p => p);
      IEnumerable<Album> photoAlbums = emptyAlbums.Select(a => {
        a.Photos = photos.Where(p => p.AlbumId == a.Id);
        return a;
      });
      return photoAlbums;
    }
  }
}
