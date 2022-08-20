# Craiyon.NET
### Overview
An unofficial API wrapper for [Craiyon](https://craiyon.com) (formerly DALL-E-MINI) to generate awesome images from text tokens.\
Simplest and easiest to use.

Inspired by [craiyon.py](https://github.com/FireHead90544/craiyon.py).

## Installation
you can get it from [NuGet](https://www.nuget.org/packages/Craiyon.NET)!\
..or just copy & paste codes in this repo
### Package Manager
```powershell
Install-Package Craiyon.NET -Version 0.0.1
```
### .NET CLI
```powershell
dotnet add package Craiyon.NET --version 0.0.1
```
## Usage
### Generate and save images
```csharp
var craiyon = new Craiyon.CraiyonClient(); // Create new instance
var images = craiyon.GenerateImage("what you want to see"); // Generate images

images.SaveImages("directory", "filename"); // Save images
```
↓ when you set `"filename"` to `"craiyon-net"`
![image](https://user-images.githubusercontent.com/78198198/185727898-ff38e600-5f80-47a3-9da3-21f9db7c8289.png)

### Generate images asynchronously
```csharp
var craiyon = new Craiyon.CraiyonClient(); // Create new instance
var images = craiyon.GenerateImageAsync("what you want to see"); // Generate images
```

### Generate images and convert into System.Drawing.Bitmap
```csharp
var craiyon = new Craiyon.CraiyonClient(); // Create new instance
var images = craiyon.GenerateImage("what you want to see"); // Generate images

Bitmap[] bmps = images.ToBitmaps(); // Get bitmaps
```
## macOS support
Since System.Drawing.Commons does not work on macOS, images need to be saved from a byte array.
```csharp
var craiyon = new Craiyon.CraiyonClient(); // Create new instance
var images = craiyon.GenerateImage("what you want to see"); // Generate images

byte[][] byteArrayImgs = images.ToByteArrays(); // Get byte arrays
for (int i = 0; i < byteArrayImgs; i++) {
    var ms = new System.IO.MemoryStream(byteArrayImgs[i]);
    var fs = new System.IO.FileStream("filepath to save", FileMode.Create)
    ms.WriteTo(fs); // Write image data to filestream
}
```
