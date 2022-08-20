using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Craiyon {
    public class CraiyonClient : IDisposable {
        private HttpClient _client;
        private bool _disposed = false;

        public CraiyonClient() { 
            _client = new HttpClient();
        }

        /// <summary>
        /// Generate images
        /// </summary>
        /// <param name="prompt">prompt</param>
        /// <returns>generated images (base64 encoded)</returns>
        public CraiyonImages GenerateImage(string prompt) {
            return GenerateImageAsync(prompt).Result;
        }

        /// <summary>
        /// Generate images asynchronously
        /// </summary>
        /// <param name="prompt">prompt</param>
        /// <returns>generated images (base64 encoded)</returns>
        public async Task<CraiyonImages> GenerateImageAsync(string prompt) {
            var jsonString = JsonSerializer.Serialize(new Dictionary<string, string> { ["prompt"] = prompt });
            var postContent = new StringContent(jsonString, Encoding.UTF8, @"application/json");
            var response = await _client.PostAsync(Resources.Address, postContent);
            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<CraiyonImages>(content);
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            if (!_disposed) {
                if (disposing) {
                    _client.Dispose();
                }
                _disposed = true;
            }
        }

        ~CraiyonClient() {
            Dispose(false);
        }
    }
}
