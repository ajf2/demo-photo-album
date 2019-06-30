using DemoPhotoAlbum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace DemoPhotoAlbum {
  public class PhotoAlbumWebApiClient {
    /// <summary>
    /// A singleton HttpClient object.
    /// </summary>
    private static readonly HttpClient http = new HttpClient();
    private const string baseUrl = "https://jsonplaceholder.typicode.com";

    /// <summary>
    /// Gets a collection of albums from the remote service.
    /// </summary>
    /// <param name="userId">(Optional) The userId to filter by.</param>
    /// <returns>A collection of albums.</returns>
    public Task<IEnumerable<Album>> GetAlbumsAsync(int? userId) {
      string urlSegment = "albums";
      if (userId.HasValue) {
        urlSegment += $"?userId={userId}";
      }
      return GetAsync<IEnumerable<Album>>(urlSegment);
    }

    /// <summary>
    /// Gets a collection of photos from the remote service.
    /// </summary>
    /// <param name="albumId">(Optional) The albumId to filter by.</param>
    /// <returns>A collection of photos.</returns>
    public Task<IEnumerable<Photo>> GetPhotosAsync(int? albumId) {
      string urlSegment = "photos";
      if (albumId.HasValue) {
        urlSegment += $"?albumId={albumId}";
      }
      return GetAsync<IEnumerable<Photo>>(urlSegment);
    }

    /// <summary>
    /// Performs an HTTP GET request and deserialises it to the specified type.
    /// </summary>
    /// <typeparam name="T">The type of data to deserialise to.</typeparam>
    /// <param name="route">The URL route to get data from.</param>
    /// <returns>The deserialised data.</returns>
    private async Task<T> GetAsync<T>(string route) where T : class {
      var serializer = new DataContractJsonSerializer(typeof(T));
      var stream = await http.GetStreamAsync($"{baseUrl}/{route}");
      var response = serializer.ReadObject(stream) as T;
      return response;
    }
  }
}
