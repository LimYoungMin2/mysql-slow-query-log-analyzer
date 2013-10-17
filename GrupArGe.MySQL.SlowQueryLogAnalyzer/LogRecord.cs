using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrupArGe.MySQL.SlowQueryLogAnalyzer
{
  public class LogRecord
  {
    public DateTime Time { get; set; }
    public string UserName { get; set; }
    public TimeSpan QueryExecutionTime { get; set; }
    public TimeSpan LockTime { get; set; }

    public Int64 RowsSent { get; set; }
    public Int64 RowsExamined { get; set; }

    public List<string> Queries { get; set; }

    public LogRecord()
    {
      Queries = new List<string>();
    }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder(256);

      sb.AppendFormat("Time: {0}", this.Time);
      sb.AppendLine();

      sb.AppendFormat("User: {0}", this.UserName);
      sb.AppendLine();

      sb.AppendFormat("Execution Time: {0}", this.QueryExecutionTime);
      sb.AppendLine();

      sb.AppendFormat("Lock Time: {0}", this.LockTime);
      sb.AppendLine();

      sb.AppendFormat("Rows Sent: {0}", this.RowsSent);
      sb.AppendLine();

      sb.AppendFormat("Rows Examined: {0}", this.RowsExamined);
      sb.AppendLine();

      foreach (var query in this.Queries)
      {
        sb.AppendFormat("Query Text: {0}", query);
        sb.AppendLine();
      }

      sb.AppendLine();
      sb.AppendLine();

      return sb.ToString();
    }
  }
}
