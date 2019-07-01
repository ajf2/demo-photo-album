using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DemoPhotoAlbum.Models {
  /// <summary>
  /// Represents a photo retreived from the Web API.
  /// </summary>
  [DataContract]
  public class Photo {
    /// <summary>
    /// The ID of the album this photo belongs to.
    /// </summary>
    [DataMember(Name = "albumId")]
    public int AlbumId { get; set; }
    /// <summary>
    /// The ID of this photo.
    /// </summary>
    [DataMember(Name = "id")]
    public int Id { get; set; }
    /// <summary>
    /// The title of this photo.
    /// </summary>
    [DataMember(Name = "title")]
    public string Title { get; set; }
    /// <summary>
    /// The URL pointing to this photo's binary data.
    /// </summary>
    [DataMember(Name = "url")]
    public Uri Url { get; set; }
    /// <summary>
    /// The URL pointing to a thumbnail of this photo.
    /// </summary>
    [DataMember(Name = "thumbnailUrl")]
    public Uri ThumbnailUrl { get; set; }
  }
}
