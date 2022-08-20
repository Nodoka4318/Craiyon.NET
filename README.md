# Craiyon.NET
### Overview
An unofficial API wrapper for [Craiyon](https://craiyon.com) (formerly DAL-E-MINI) to generate awesome images from text tokens.\
Simplest and easiest to use.

Inspired by [craiyon.py](https://github.com/FireHead90544/craiyon.py).

## Installation
TODO

## Usage
### Generate and save images
```csharp
var craiyon = new Craiyon.CraiyonClient(); // Create new instance
var images = craiyon.GenerateImage("what you want to see"); // Generate image

images.SaveImages("directory"); // Save images
```

### Generate images asynchronously
```csharp
var craiyon = new Craiyon.CraiyonClient(); // Create new instance
var images = craiyon.GenerateImageAsync("what you want to see"); // Generate image
```

### Generate images and convert into System.Drawing.Bitmap
```csharp
var craiyon = new Craiyon.CraiyonClient(); // Create new instance
var images = craiyon.GenerateImageAsync("what you want to see"); // Generate image

Bitmap[] bmps = images.ToBitmaps(); // Get bitmaps
```
