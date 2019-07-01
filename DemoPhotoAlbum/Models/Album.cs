using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DemoPhotoAlbum.Models {
  /// <summary>
  /// Represents an album retreived from the Web API.
  /// </summary>
  [DataContract]
  public class Album {
    /// <summary>
    /// The ID of the user this album belongs to.
    /// </summary>
    [DataMember(Name = "userId")]
    public int UserId { get; set; }
    /// <summary>
    /// The ID of this album.
    /// </summary>
    [DataMember(Name = "id")]
    public int Id { get; set; }
    /// <summary>
    /// The title of this album.
    /// </summary>
    [DataMember(Name = "title")]
    public string Title { get; set; }
  }
}
