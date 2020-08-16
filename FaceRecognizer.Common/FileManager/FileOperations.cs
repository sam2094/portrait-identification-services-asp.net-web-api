using System;
using System.IO;

namespace FaceRecognizer.Common.FileManager
{
    public class FileOperations : IFileOperations
    {
        public byte[] ReadAllBytes(string path)
        {
            try
            {
                return File.ReadAllBytes(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
