using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Web;

namespace TestRESTApi
{
    class ZipPacker
    {
        public byte[] Pack(string dataToZip, Encoding encoding)
        {
            string fileName = "export_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".csv";
            byte[] fileBytes = encoding.GetBytes(dataToZip);

            string fileNameZip = "Export_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";

            using (var outStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(outStream, ZipArchiveMode.Create, true))
                {
                    var fileInArchive = archive.CreateEntry(fileName, CompressionLevel.Optimal);
                    using (var entryStream = fileInArchive.Open())
                    using (var fileToCompressStream = new MemoryStream(fileBytes))
                    {
                        fileToCompressStream.CopyTo(entryStream);
                    }
                }
                return outStream.ToArray();
            }
        }
    }

}