using System;
using System.Text;

namespace RcpParser.Parser
{
   public class CsvParser
   {
      public string Parse(string filename)
      {
         StringBuilder result = new StringBuilder();
         TimeSpan bilans = new TimeSpan();

         result.Append(prepareHeaderLine());

         foreach (var line in FileReader.ReadFile(filename))
         {
            try
            {
               var line_split = line.Split(';');
               AnalyzeDay daySummary = new AnalyzeDay(
                  DateTime.Parse(String.Format("{0} {1}:00", line_split[0], line_split[3])),
                  DateTime.Parse(String.Format("{0} {1}:00", line_split[0], line_split[4]))
               );

               bilans += daySummary.GetDifference();

               result.Append(prepareLine(daySummary, bilans));
            }
            catch (Exception) { }

         }

         string bal = (bilans > TimeSpan.Zero) ? "+" + bilans.ToString() : bilans.ToString();
         result.Append(String.Format("\nBilans miesięczny: {0}", bal));

         return result.ToString();
      }

      private string prepareLine(AnalyzeDay analyzeDay, TimeSpan balance)
      {
         string diff = (analyzeDay.GetDifference() > TimeSpan.Zero) ? "+" + analyzeDay.GetDifference().ToString() : analyzeDay.GetDifference().ToString();
         string bal = (balance > TimeSpan.Zero) ? "+" + balance.ToString() : balance.ToString();

         return String.Format("{0}{1}{2}{3}{4}{5}\n",
                  analyzeDay.GetDate().ToString().PadRight(row_1_size),
                  analyzeDay.GetBeginTime().ToString().PadRight(row_2_size),
                  analyzeDay.GetEndTime().ToString().PadRight(row_3_size),
                  analyzeDay.GetSummary().ToString().PadRight(row_4_size),
                  diff.PadRight(row_5_size),
                  bal.PadRight(row_6_size));
      }

      private string prepareHeaderLine()
      {
         return String.Format("{0}{1}{2}{3}{4}{5}\n\n",
            "Data".PadRight(row_1_size),
            "Start".PadRight(row_2_size),
            "Koniec".PadRight(row_3_size),
            "Czas pracy".PadRight(row_4_size),
            "Różnica".PadRight(row_5_size),
            "Bilans".PadRight(row_6_size) );
      }

      private const int row_1_size = 15;
      private const int row_2_size = 10;
      private const int row_3_size = 11;
      private const int row_4_size = 14;
      private const int row_5_size = 15;
      private const int row_6_size = 9;
   }
}
