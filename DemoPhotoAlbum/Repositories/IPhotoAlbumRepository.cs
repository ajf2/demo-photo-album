using DemoPhotoAlbum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPhotoAlbum.Repositories {
  public interface IPhotoAlbumRepository {
    IEnumerable<PhotoAlbum> GetPhotoAlbums(int? userId = null);
    Task<IEnumerable<PhotoAlbum>> GetPhotoAlbumsAsync(int? userId = null);
  }
}
