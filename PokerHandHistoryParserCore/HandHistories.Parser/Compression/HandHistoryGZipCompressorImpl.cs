using System.IO;
using System.IO.Compression;
using System.Text;
using HandHistories.Objects.Hand;

namespace HandHistories.Parser.Compression
{
    public class HandHistoryGZipCompressorImpl : IHandHistoryCompressor
    {
        public string CompressHandHistory(HandHistory parsedHandHistory)
        {
            return CompressHandHistory(parsedHandHistory.FullHandHistoryText);
        }

        public string CompressHandHistory(string fullHandText)
        {
            if (fullHandText == null) return null;

            //Transform string into byte[]  
            byte[] byteArray = new byte[fullHandText.Length];
            int indexBA = 0;
            foreach (char item in fullHandText)
            {
                byteArray[indexBA++] = (byte)item;
            }

            //Prepare for compress
            var ms = new MemoryStream();
            var sw = new GZipStream(ms, CompressionMode.Compress);

            //Compress
            sw.Write(byteArray, 0, byteArray.Length);
            //Close, DO NOT FLUSH cause bytes will go missing...
            //TODO: CoreConversion: Test to make sure Dispose works without Close
            sw.Dispose();

            //Transform byte[] zip data to string
            byteArray = ms.ToArray();
            var sB = new StringBuilder(byteArray.Length);
            foreach (var item in byteArray)
            {
                sB.Append((char)item);
            }
            //TODO: CoreConversion: Test to make sure Dispose works without Close
            ms.Dispose();
            return sB.ToString();
        }

        public string UncompressHandHistory(string compressedHandHistory)
        {
            if (compressedHandHistory == null) return null;

            var byteArray = new byte[compressedHandHistory.Length];

            var indexBa = 0;
            foreach (char item in compressedHandHistory)
                byteArray[indexBa++] = (byte)item;

            var memoryStream = new MemoryStream(byteArray);
            var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress);

            byteArray = new byte[1024];

            var stringBuilder = new StringBuilder();

            int readBytes;
            while ((readBytes = gZipStream.Read(byteArray, 0, byteArray.Length)) != 0)
            {
                for (var i = 0; i < readBytes; i++)
                    stringBuilder.Append((char)byteArray[i]);
            }

            //TODO: CoreConversion: Test to make sure Dispose works without Close
            gZipStream.Dispose();

            //TODO: CoreConversion: Test to make sure Dispose works without Close
            memoryStream.Dispose();


            return stringBuilder.ToString();
        }
    }
}
