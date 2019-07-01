using DemoPhotoAlbum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPhotoAlbum.Repositories {
  /// <summary>
  /// Defines a contract for how data should be returned from a data source.
  /// </summary>
  public interface IPhotoAlbumRepository {
    /// <summary>
    /// Returns <see cref="PhotoAlbum"/>s from the data source. Blocks until completion.
    /// </summary>
    /// <param name="userId">(Optional) The user Id to filter by.</param>
    /// <returns>A collection of <see cref="PhotoAlbum"/>s.</returns>
    IEnumerable<PhotoAlbum> GetPhotoAlbums(int? userId = null);
    /// <summary>
    /// Asynchronously returns <see cref="PhotoAlbum"/>s from the data source.
    /// </summary>
    /// <param name="userId">(Optional) The user Id to filter by.</param>
    /// <returns>A collection of <see cref="PhotoAlbum"/>s.</returns>
    Task<IEnumerable<PhotoAlbum>> GetPhotoAlbumsAsync(int? userId = null);
  }
}
