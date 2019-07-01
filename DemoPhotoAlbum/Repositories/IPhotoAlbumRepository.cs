using DemoPhotoAlbum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPhotoAlbum.Repositories {
  public interface IPhotoAlbumRepository {
    IEnumerable<PhotoAlbum> GetPhotoAlbums();
    Task<IEnumerable<PhotoAlbum>> GetPhotoAlbumsAsync();
    IEnumerable<PhotoAlbum> GetPhotoAlbums(int userId);
    Task<IEnumerable<PhotoAlbum>> GetPhotoAlbumsAsync(int userId);
  }
}
