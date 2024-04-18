using RcpParser.Extensions;
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

         result.Append(prepareHorizontalLine());
         result.Append(prepareHeaderLine());
         result.Append(prepareHorizontalLine());

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

         result.Append(prepareHorizontalLine());

         string balance = (bilans > TimeSpan.Zero) ? "+" + bilans.ToString() : bilans.ToString();
         result.Append(prepareResumeLine(balance));
         result.Append(prepareEndLine());

         return result.ToString();
      }

      private string prepareLine(AnalyzeDay analyzeDay, TimeSpan balance)
      {
         string diff = (analyzeDay.GetDifference() > TimeSpan.Zero) ? "+" + analyzeDay.GetDifference().ToString() : analyzeDay.GetDifference().ToString();
         string bal = (balance > TimeSpan.Zero) ? "+" + balance.ToString() : balance.ToString();

         return String.Format("|  {0}  |  {1}  |  {2}  |  {3}  |  {4}  |  {5}  |\n",
                  analyzeDay.GetDate().ToString().PadRight(row_1_size),
                  analyzeDay.GetBeginTime().ToString().PadRight(row_2_size),
                  analyzeDay.GetEndTime().ToString().PadRight(row_3_size),
                  analyzeDay.GetSummary().ToString().PadRight(row_4_size),
                  diff.PadRight(row_5_size),
                  bal.PadRight(row_6_size));
      }

      private string prepareHeaderLine()
      {
         return String.Format("|  {0}  |  {1}  |  {2}  |  {3}  |  {4}  |  {5}  |\n",
            "Data".PadBoth(row_1_size),
            "Start".PadBoth(row_2_size),
            "Stop".PadBoth(row_3_size),
            "Czas".PadBoth(row_4_size),
            "Różnica".PadBoth(row_5_size),
            "Bilans".PadBoth(row_6_size) );
      }

      private string prepareHorizontalLine()
      {
         return String.Format("|{0}|{1}|{2}|{3}|{4}|{5}|\n",
            "-".PadRight(row_1_size + 4, '-'),
            "-".PadRight(row_2_size + 4, '-'),
            "-".PadRight(row_3_size + 4, '-'),
            "-".PadRight(row_4_size + 4, '-'),
            "-".PadRight(row_5_size + 4, '-'),
            "-".PadRight(row_6_size + 4, '-')
            );
      }

      private string prepareResumeLine(string balance)
      {
         return String.Format("|  {0}{1}{2}  |\n", 
            "Bilans miesięczny:", 
            "".PadRight(44, ' '), 
            balance);
      }

      private string prepareEndLine()
      {
         return String.Format("|{0}|\n", "".PadRight(75, '-'));
      }

      private const int row_1_size = 10;
      private const int row_2_size = 5;
      private const int row_3_size = 5;
      private const int row_4_size = 8;
      private const int row_5_size = 9;
      private const int row_6_size = 9;
   }
}
