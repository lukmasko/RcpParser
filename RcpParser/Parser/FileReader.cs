using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RcpParser.Parser
{
   internal class FileReader
   {
      public static IEnumerable<String> ReadFile(string path)
      {
         const Int32 BufferSize = 512;
         using (var fileStream = File.OpenRead(path))
         using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
         {
            String line;
            while ((line = streamReader.ReadLine()) != null)
            {
               yield return line;
            }
         }
      }
   }
}
