using System;
using RcpParser;
using System.Windows.Forms;
using RcpParser.Parser;
using System.IO;

namespace RcpParser
{
   public partial class ViewForm : Form
   {
      public ViewForm()
      {
         InitializeComponent();
      }

      private void button1_Click(object sender, EventArgs e)
      {
         var filePath = string.Empty;

         using (OpenFileDialog openFileDialog = new OpenFileDialog())
         {
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog.Filter = "csv files (*.csv)|*.csv";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() != DialogResult.OK)
               return;
            filePath = openFileDialog.FileName;
         }
         
         CsvParser csvParser = new CsvParser();
         result_view_ctrl.Text = csvParser.Parse(filePath);
      }
   }
}
