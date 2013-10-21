using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace GrupArGe.MySQL.SlowQueryLogAnalyzer
{
  public partial class MainForm : Form
  {
    string logFilePath = @"C:\WORKS\slow.log";
    string _NL = Environment.NewLine;
    CultureInfo _culture = new CultureInfo("en-US");

    public MainForm()
    {
      InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {      
      openFileDialog1.Filter = "log files (*.log)|*.log|All files (*.*)|*.*";
    }

    /* Sample Record
      # Time: 131013 12:16:42
      # User@Host: backup[backup] @ localhost [127.0.0.1]
      # Query_time: 46.004400  Lock_time: 0.000000 Rows_sent: 6166242  Rows_examined: 6166242
      SET timestamp=1381655802;
      SELECT * FROM `table_name`;
    */
    
    public void AnalyzeLogFile(string filePath)
    {
      _txtDebug.Clear();
      _txtDebug.AppendText("Analyzing...");
      _txtDebug.Update();

      List<LogRecord> records = new List<LogRecord>();
      
      try
      {
        using (StreamReader reader = new StreamReader(filePath))
        {
          string line;
          LogRecord record = new LogRecord();
          bool queryLinesProcessed = false;
          DateTime lastRecordTime = new DateTime();
          bool recordHasTimeValue = false;

          while ((line = reader.ReadLine()) != null)
          {
            if (queryLinesProcessed && line[0] == '#') // new record starting
            {
              if (recordHasTimeValue == false)
              {
                record.Time = lastRecordTime;
              }

              records.Add(record);
              record = new LogRecord();
              queryLinesProcessed = false;
              recordHasTimeValue = false;
            }

            // # Time line does not exist in every record
            if (line.Contains("# Time"))
            {
              recordHasTimeValue = true;
              lastRecordTime = record.Time = ParseTime(line);
            }
            else if (line.Contains("# User"))
            {
              record.UserName = ParseUserName(line);
            }
            else if (line.Contains("# Query_time"))
            {
              // # Query_time: 46.004400  Lock_time: 0.000000 Rows_sent: 6166242  Rows_examined: 6166242
              record.QueryExecutionTime = ParseQueryTime(line);
              record.LockTime = ParseLockTime(line);
              record.RowsSent = ParseRowsSent(line);
              record.RowsExamined = ParseRowsExamined(line);
            }
            else
            {
              record.Queries.Add(line);
            }

            if (line[0] != '#')
            {
              queryLinesProcessed = true;
            }            
          }
          
          records.Add(record);
        }
      }
      catch (Exception exc)
      {
        _txtDebug.AppendText(exc.Message);
      }

      string recordCountMsg = "";

      if (records.Count == 0)
      {
        recordCountMsg = "No Records Found!";
      }
      else if (records.Count == 1)
      {
        recordCountMsg = "1 Record Found!";
      }
      else
      {
        recordCountMsg = String.Format("{0} Records Found!", records.Count);
      }

      StringBuilder sb = new StringBuilder();
      //_txtDebug.AppendText(recordCountMsg + _NL + _NL);
      sb.Append(recordCountMsg);
      sb.AppendLine();
      sb.AppendLine();
      
      foreach (var record in records)
      {
        sb.Append(record.ToString());
        //_txtDebug.AppendText(record.ToString());
      }

      _txtDebug.Text = sb.ToString();
    }

    private long ParseRowsExamined(string line)
    {
      // # Query_time: 46.004400  Lock_time: 0.000000 Rows_sent: 6166242  Rows_examined: 6166242
      var splitted = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
      return Int64.Parse(splitted[8]);
    }

    private long ParseRowsSent(string line)
    {
      // # Query_time: 46.004400  Lock_time: 0.000000 Rows_sent: 6166242  Rows_examined: 6166242
      var splitted = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
      return Int64.Parse(splitted[6]);
    }

    

    private TimeSpan ParseQueryTime(string line)
    {
      // # Query_time: 46.004400  Lock_time: 0.000000 Rows_sent: 6166242  Rows_examined: 6166242
      var splitted = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
      double seconds = Double.Parse(splitted[2], _culture);
      return TimeSpan.FromSeconds(seconds);
    }

    private TimeSpan ParseLockTime(string line)
    {
      // # Query_time: 46.004400  Lock_time: 0.000000 Rows_sent: 6166242  Rows_examined: 6166242
      var splitted = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
      double seconds = Double.Parse(splitted[4], _culture);
      return TimeSpan.FromSeconds(seconds);
    }

    private string ParseUserName(string line)
    {
      //# User@Host: backup[backup] @ localhost [127.0.0.1]
      var s = line.IndexOf('[');
      var e = line.IndexOf(']');
      var userName = line.Substring(s + 1, e - s - 1);
      return userName;
    }

    private DateTime ParseTime(string line)
    {
      DateTime dt = new DateTime();
      string dateTimeString = "";

      try
      {
        //# Time: 131013 12:16:42
        string search = "Time:";
        int startIndex = line.IndexOf(search) + search.Length;
        dateTimeString = line.Substring(startIndex).Trim().Replace("  ", " 0");
        dt = DateTime.ParseExact(dateTimeString, "yyMMdd HH:mm:ss", _culture);
      }
      catch(Exception exc)
      {
        _txtDebug.AppendText(exc.Message);
      }

      return dt;
    }

    private void EH_BtnBrowse_Click(object sender, EventArgs e)
    {
      openFileDialog1.FileName = "";

      var dialogResult = openFileDialog1.ShowDialog();

      if (dialogResult == DialogResult.OK)
      {
        _txtLogFilePath.Text = openFileDialog1.FileName;
      }
    }

    private void EH_BtnAnalyze_Click(object sender, EventArgs e)
    {
      logFilePath = _txtLogFilePath.Text;
      AnalyzeLogFile(logFilePath);
    }

  }
}