﻿
using KattApp.Model;

namespace KattApp.Services
{
    public class UpploadImage
    {
        public async Task<FileResult> OpenMediaPickerAsync()
        {
            try
            {
                var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Please pick a photo"
                });
                if (result.ContentType == "image/png" ||
                   result.ContentType == "image/jpeg" ||
                   result.ContentType == "image/jpg")
                    return result;
                else
                    await App.Current.MainPage.DisplayAlert("Error Typr Image", "Please choose a new image", "OK");
                return null;
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<Stream> FileResultToStream(FileResult fileResult)
        {
            if (fileResult == null)
                return null;
            return await fileResult.OpenReadAsync();
        }

        public Stream ByteArrayToStream(byte[] bytes)
        {
            return new MemoryStream(bytes);
        }

        public string ByteBase64ToString(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        public byte[] StringToByteBase64(string text)
        {
            return Convert.FromBase64String(text);
        }

        public async Task<ImageFile> Upload(FileResult fileResult)
        {
            byte[] bytes;
           
            try
            {
                using(var ms = new MemoryStream())
                {
                    var stream = await FileResultToStream(fileResult);
                    stream.CopyTo(ms);
                    bytes = ms.ToArray();
                }

                return new ImageFile
                {
                    byteBase46 = ByteBase64ToString(bytes),
                    ContentType = fileResult.ContentType,
                    FileName = fileResult.FileName,
                };
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
