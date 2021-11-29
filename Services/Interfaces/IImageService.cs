using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookMVC.Services.Interfaces
{
    public interface IImageService
    {
        // An interface is a contract with a set of default methods that must be
        // performed by class members but class members determine how to impliment the methods 
        public Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file);
        public string ConvertByteArrayToFile(byte[] fileData, string extension);
    }
}
