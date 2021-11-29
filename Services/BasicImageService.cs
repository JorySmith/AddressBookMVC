using AddressBookMVC.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookMVC.Services
{
    public class BasicImageService : IImageService 
        // The contcrete class member inherits the interface's
        // required methods but has its own implimentation
    {
        public string ConvertByteArrayToFile(byte[] fileData, string extension)
        {
            // Return a string.Empty if fileData is null
            if (fileData is null) return string.Empty;

            // Convert fileData toBase64String then return a string interpolation 
            string imageBase64Data = Convert.ToBase64String(fileData);
            return $"data:{extension};base64,{imageBase64Data}";
        }

        // Async method for converting file to byte array
        public async Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file)
        {
            // Copy user submitted IFormFile image to MemoryStream
            // Turn memoryStream.ToArray(), store into variable byte[] byteFile
            using MemoryStream memoryStream = new();
            await file.CopyToAsync(memoryStream);
            byte[] byteFile = memoryStream.ToArray();

            return byteFile;
        }
    }
}
