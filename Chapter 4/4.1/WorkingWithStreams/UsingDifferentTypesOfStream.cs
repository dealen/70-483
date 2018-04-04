using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithStreams
{
    public class UsingDifferentTypesOfStream : IRun
    {
        public void Run()
        {
            CompressingDataWithGZipStream();
            UsingbufferedStream();
        }

        private void CompressingDataWithGZipStream()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            string folder = @"C:\Temp";
            string uncompressedFilePath = Path.Combine(folder, "uncompressed.dat");
            string compressedFilePath = Path.Combine(folder, "compressed.dat");
            byte[] dataToCompress = Enumerable.Repeat((byte)'a', 1024 * 1024).ToArray();

            using (FileStream uncompressedFileStream = File.Create(uncompressedFilePath))
            {
                uncompressedFileStream.Write(dataToCompress, 0, dataToCompress.Length);
            }

            using (FileStream compressedFileStream = File.Create(compressedFilePath))
            {
                using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                {
                    compressionStream.Write(dataToCompress, 0, dataToCompress.Length);
                }
            }

            FileInfo uncompressedFileInfo = new FileInfo(uncompressedFilePath);
            FileInfo compressedFileInfo = new FileInfo(compressedFilePath);

            Console.WriteLine($"Uncompressed file length: {uncompressedFileInfo.Length}");
            Console.WriteLine($"Compressed file length: {compressedFileInfo.Length}");
            uncompressedFileInfo.Delete();
            compressedFileInfo.Delete();
        }

        private void UsingbufferedStream()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            string path = @"C:\Temp\bufferedStream.txt";

            using (FileStream fs = File.Create(path))
            {
                using (BufferedStream bs = new BufferedStream(fs))
                {
                    using (StreamWriter sw = new StreamWriter(bs))
                    {
                        sw.WriteLine("A line of text");
                    }
                }
            }
        }
    }
}
