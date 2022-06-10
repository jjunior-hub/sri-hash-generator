using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sri_hash_generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void selecionarArquivo_Click(object sender, EventArgs e)
        {


            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "CSV files (*.csv)|*.csv|Excel Files|*.xls;*.xlsx";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {


                    this.progressBar1.Visible = true;
                    this.progressBar1.Minimum = 1;
                    this.progressBar1.Maximum = 4;
                    this.progressBar1.Value = 2;
                    this.progressBar1.Step = 1;




                    this.progressBar1.PerformStep();
                    var dataTable = ConvertToDataTable(openFileDialog1.FileName);


                    if (!dataTable.Columns.Contains("HashSHA256"))
                        dataTable.Columns.Add("HashSHA256");

                    if (!dataTable.Columns.Contains("HashSHA384"))
                        dataTable.Columns.Add("HashSHA384");

                    if (!dataTable.Columns.Contains("HashSHA512"))
                        dataTable.Columns.Add("HashSHA512");



                    this.progressBar1.PerformStep();
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {

                        var script = dataTable.Rows[i]["Script"].ToString();

                        if (!string.IsNullOrEmpty(script))
                        {


                            try
                            {
                                using (var lWebClient = new WebClient())
                                {

                                    lWebClient.Headers.Add("Accept", "*/*");
                                    lWebClient.Headers.Add("Accept-Encoding", "gzip, deflate, br");

                                    using (var fs = new MemoryStream(lWebClient.DownloadData(new Uri(script))))
                                    {
                                        dataTable.Rows[i]["HashSHA256"] = HashGeneratorSHA256(fs);
                                        dataTable.Rows[i]["HashSHA384"] = HashGeneratorSHA384(fs);
                                        dataTable.Rows[i]["HashSHA512"] = HashGeneratorSHA512(fs);
                                    }
                                }

                            }
                            catch (WebException exlWebClient)
                            {
                                dataTable.Rows[i]["HashSHA256"] = exlWebClient.Message;
                                dataTable.Rows[i]["HashSHA384"] = exlWebClient.Message;
                                dataTable.Rows[i]["HashSHA512"] = exlWebClient.Message;
                            }

                        }
                    }


                    this.dataGridView1.DataSource = dataTable;
                    this.progressBar1.PerformStep();


                }
                catch (Exception ex)
                {

                }
            }

        }


        public string HashGeneratorSHA256(MemoryStream fs)
        {


            using (SHA256 sha256Hash = SHA256.Create())
            {
                return "sha256-" + Convert.ToBase64String(sha256Hash.ComputeHash(fs));
            }


        }



        public string HashGeneratorSHA384(MemoryStream fs)
        {

            using (SHA384 sha384Hash = SHA384.Create())
            {
                return "sha384-" + Convert.ToBase64String(sha384Hash.ComputeHash(fs));
            }


        }


        public string HashGeneratorSHA512(MemoryStream fs)
        {

            using (SHA512 sha512Hash = SHA512.Create())
            {
                return "sha512-" + Convert.ToBase64String(sha512Hash.ComputeHash(fs));
            }

        }



        public System.Data.DataTable ConvertToDataTable(string path)
        {

            System.Data.DataTable dt = null;

            try

            {

                object rowIndex = 1;

                dt = new System.Data.DataTable();

                DataRow row;

                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();

                Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(path, 0, true, 5, "", "", true,

                Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.ActiveSheet;

                int temp = 1;

                while (((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, temp]).Value2 != null)

                {

                    dt.Columns.Add(Convert.ToString(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, temp]).Value2));

                    temp++;

                }

                rowIndex = Convert.ToInt32(rowIndex) + 1;

                int columnCount = temp;

                temp = 1;

                while (((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, temp]).Value2 != null)

                {

                    row = dt.NewRow();

                    for (int i = 1; i < columnCount; i++)

                    {

                        row[i - 1] = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, i]).Value2);

                    }

                    dt.Rows.Add(row);

                    rowIndex = Convert.ToInt32(rowIndex) + 1;

                    temp = 1;

                }

                app.Workbooks.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dt;

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();

            if (this.dataGridView1.Rows.Count > 0)
            {
                try
                {
                    XcelApp.Application.Workbooks.Add(Type.Missing);
                    for (int i = 1; i < this.dataGridView1.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[1, i] = this.dataGridView1.Columns[i - 1].HeaderText;
                    }
                    //
                    for (int i = 0; i < this.dataGridView1.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 2, j + 1] = this.dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    //
                    XcelApp.Columns.AutoFit();
                    //
                    XcelApp.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro : " + ex.Message);
                    XcelApp.Quit();
                }
            }
        }
    }
}
