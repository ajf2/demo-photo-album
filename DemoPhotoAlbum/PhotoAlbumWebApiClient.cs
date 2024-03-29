﻿using DemoPhotoAlbum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace DemoPhotoAlbum {
  /// <summary>
  /// Connects to the JSONPlaceholder Web API and returns album and photo data.
  /// </summary>
  public class PhotoAlbumWebApiClient {
    // A singleton HttpClient object, assigned with dependency injection in the constructor.
    private readonly HttpClient http;
    private const string baseUrl = "https://jsonplaceholder.typicode.com";

    public PhotoAlbumWebApiClient(HttpClient httpClient) {
      http = httpClient;
    }

    /// <summary>
    /// Gets all albums from the remote service.
    /// </summary>
    /// <returns>A collection of albums.</returns>
    public Task<IEnumerable<Album>> GetAlbumsAsync() {
      return GetAsync<IEnumerable<Album>>("albums");
    }

    /// <summary>
    /// Gets a collection of albums from the remote service.
    /// </summary>
    /// <param name="userId">The userId to filter by.</param>
    /// <returns>A collection of albums.</returns>
    public Task<IEnumerable<Album>> GetAlbumsAsync(int userId) {
      return GetAsync<IEnumerable<Album>>($"albums?userId={userId}");
    }

    /// <summary>
    /// Gets all the photos from the remote service.
    /// </summary>
    /// <returns>A collection of photos.</returns>
    public Task<IEnumerable<Photo>> GetPhotosAsync() {
      return GetAsync<IEnumerable<Photo>>("photos");
    }

    /// <summary>
    /// Gets a collection of photos from the remote service.
    /// </summary>
    /// <param name="albumId">The albumId to filter by.</param>
    /// <returns>A collection of photos.</returns>
    public Task<IEnumerable<Photo>> GetPhotosAsync(int albumId) {
      return GetAsync<IEnumerable<Photo>>($"photos?albumId={albumId}");
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
