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

    public IEnumerable<PhotoAlbum> GetPhotoAlbums() {
      return GetPhotoAlbumsAsync().Result;
    }

    public IEnumerable<PhotoAlbum> GetPhotoAlbums(int userId) {
      return GetPhotoAlbumsAsync(userId).Result;
    }

    public async Task<IEnumerable<PhotoAlbum>> GetPhotoAlbumsAsync() {
      IEnumerable<Album> emptyAlbums = await this.client.GetAlbumsAsync();
      IEnumerable<Photo> photos = (await Task.WhenAll(emptyAlbums.Select(a => this.client.GetPhotosAsync(a.Id)))).SelectMany(p => p);
      IEnumerable<PhotoAlbum> photoAlbums = emptyAlbums.Select(a => new PhotoAlbum(a, photos));
      return photoAlbums;
    }

    public async Task<IEnumerable<PhotoAlbum>> GetPhotoAlbumsAsync(int userId) {
      IEnumerable<Album> emptyAlbums = await this.client.GetAlbumsAsync(userId);
      IEnumerable<Photo> photos = (await Task.WhenAll(emptyAlbums.Select(a => this.client.GetPhotosAsync(a.Id)))).SelectMany(p => p);
      IEnumerable<PhotoAlbum> photoAlbums = emptyAlbums.Select(a => new PhotoAlbum(a, photos));
      return photoAlbums;
    }
  }
}
