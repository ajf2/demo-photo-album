using DemoPhotoAlbum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPhotoAlbum.Repositories {
  public interface IPhotoAlbumRepository {
    IEnumerable<Album> GetPhotoAlbums();
    Task<IEnumerable<Album>> GetPhotoAlbumsAsync();
    IEnumerable<Album> GetPhotoAlbums(int userId);
    Task<IEnumerable<Album>> GetPhotoAlbumsAsync(int userId);
  }
}
