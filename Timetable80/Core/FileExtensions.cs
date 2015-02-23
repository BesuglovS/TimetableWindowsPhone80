using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace InternetTest.Core
{
    public static class FileExtensions
    {
        public static async Task<bool> FileExists(this StorageFolder folder, string fileName)
        {
            try { StorageFile file = await folder.GetFileAsync(fileName); }
            catch { return false; }
            return true;
        }

        public static async Task<String> ReadFileContentsAsync(string fileName)
        {
            String result = "";

            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;

            if (local != null)
            {
                var file = await local.OpenStreamForReadAsync(fileName);

                using (StreamReader streamReader = new StreamReader(file, Encoding.UTF8))
                {
                    result = streamReader.ReadToEnd();
                }
            }

            return result;
        }
        
        public static async Task WriteDataToFileAsync(string fileName, string content)
        {
            byte[] data = Encoding.UTF8.GetBytes(content);

            var folder = ApplicationData.Current.LocalFolder;
            var file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);

            using (var s = await file.OpenStreamForWriteAsync())
            {
                await s.WriteAsync(data, 0, data.Length);
            }
        }
    }
}
