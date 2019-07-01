using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DemoPhotoAlbum.Models {
  /// <summary>
  /// Represents an album of photos.
  /// </summary>
  public class PhotoAlbum {
    /// <summary>
    /// The ID of the user this album belongs to.
    /// </summary>
    public int UserId { get; set; }
    /// <summary>
    /// The ID of this album.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// The title of this album.
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// The photos contained in this album.
    /// </summary>
    public IEnumerable<Photo> Photos { get; set; }
  }
}
