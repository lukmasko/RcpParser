using System;

namespace RcpParser.Parser
{
   internal class AnalyzeDay
   {
      public AnalyzeDay(DateTime begin, DateTime end)
      {
         m_begin = begin;
         m_end = end;
         m_summary = m_end - m_begin;
         m_difference = m_end.AddHours(-8) - m_begin;
      }

      public string GetDate() { return m_begin.ToString("yyyy-MM-dd"); }
      public string GetBeginTime() { return m_begin.ToString("HH:mm"); }
      public string GetEndTime() { return m_end.ToString("HH:mm"); }
      public string GetSummary() { return m_summary.ToString("hh\\:mm\\:ss"); }
      public TimeSpan GetDifference() { return m_difference; }

      private DateTime m_begin;
      private DateTime m_end;
      private TimeSpan m_summary;
      private TimeSpan m_difference;
   }
}
