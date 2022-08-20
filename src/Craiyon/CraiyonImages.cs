using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace Craiyon {
    public class CraiyonImages {
        public string[]? images { get; set; } // jsonデシリアライズ用

        public byte[][] ToByteArrays() =>
            images.Select(s => Convert.FromBase64String(s.Replace(@"\n", ""))).ToArray();

        public Bitmap[] ToBitmaps() {
            var conv = new ImageConverter();
            return this.ToByteArrays().Select(s => (Bitmap)conv.ConvertFrom(s)).ToArray();
        }

        /// <summary>
        /// Save images as png
        /// </summary>
        /// <param name="directoryPath">path of directory to save images</param>
        /// <param name="filename">image filename</param>
        public void SaveImages(string directoryPath, string filename) {
            var bmps = this.ToBitmaps();
            for (int i = 0; i < bmps.Length; i++) {
                bmps[i].Save($@"{directoryPath}/{filename}-{i}.png", ImageFormat.Png);
            }
        }

        /// <summary>
        /// Save images as png
        /// </summary>
        /// <param name="directoryPath">path of directory to save images</param>
        public void SaveImages(string directoryPath) {
            var bmps = this.ToBitmaps();
            for (int i = 0; i < bmps.Length; i++) {
                bmps[i].Save($@"{directoryPath}/{Guid.NewGuid()}.png", ImageFormat.Png);
            }
        }

        /// <summary>
        /// Save single image as png
        /// </summary>
        /// <param name="index">index number of image (0 to 8)</param>
        /// <param name="filename">image filepath</param>
        /// <exception cref="InvalidOperationException"></exception>
        public void SaveImageAt(int index, string filename) {
            if (index < 0 || index > 8)
                throw new InvalidOperationException("Index number must be between 0 and 8.");

            this.ToBitmaps()[index].Save(filename);
        }
    }
}
