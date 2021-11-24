using AddressBookMVC.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookMVC.Services
{
    public class BasicImageService : IImageService
    {
        public string ConvertByteArrayToFile(byte[] fileData, string extension)
        {
            if (fileData is null) return string.Empty;

            string imageBase64Data = Convert.ToBase64String(fileData);
            return $"data:{extension};base64,{imageBase64Data}";
        }

        public Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
