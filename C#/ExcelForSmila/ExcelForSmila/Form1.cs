using System;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelForSmila
{
    public partial class Form1 : Form
    {
        private Excel.Application excelApp;

        private Excel.Workbooks excelAppWorkBooks;
        private Excel.Workbook excelAppWorkBook;

        private Excel.Sheets excelSheets;
        private Excel.Worksheet excelWorkSheet;

        private Excel.Range excelcells;

        //output

        Excel.Worksheet OutWorkSheet;
        private Excel.Range OutRange;

        private void GetAllInformation(Excel.Range range, ref string allInformation)
        {
            OutRange.Value2 = range.Value2;
            allInformation += Convert.ToString(range.Value2) + " ";
        }

        private void ProccesingAllRange(long numberBegin, long numberEnd, char strBegin, char strEnd)
        {
            OutWorkSheet = (Excel.Worksheet)excelApp.Worksheets.Add();
            long indexNewRecord = 1;
            listBox1.Items.Clear();
            string tmp = textBox1.Text;
            string[] streets = tmp.Split(',');
            for (long i = numberBegin; i <= numberEnd; i++)
            {
                excelcells = excelWorkSheet.get_Range(textBoxCondition.Text + i, textBoxCondition.Text + i);
                string street = Convert.ToString(excelcells.Value2);
                for (int j = 0; j < streets.Length; j++)
                {
                    if (street == streets[j])
                    {
                        indexNewRecord++;
                        string allInformation = "";
                        for (char ch = strBegin; ch <= strEnd; ch++)
                        {
                            excelcells = excelWorkSheet.get_Range(ch.ToString() + i, ch.ToString() + i);
                            OutRange = OutWorkSheet.get_Range(ch.ToString() + indexNewRecord, ch.ToString() + indexNewRecord);
                            GetAllInformation(excelcells, ref allInformation);
                        }
                        listBox1.Items.Add(allInformation);
                    }
                }
            }
            
        }

        private string GetPathFile()
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            string path = file.FileName.ToString();
            return path;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введіть назви вулиць","Помилка",MessageBoxButtons.OK);
                return;
            }
            string pathOfFile = GetPathFile();
            excelApp = new Excel.Application();
            excelApp.Visible = true;

            excelAppWorkBooks = excelApp.Workbooks;
            excelAppWorkBook = excelApp.Workbooks.Open(pathOfFile,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);
            excelSheets = excelAppWorkBook.Worksheets;
            excelWorkSheet = (Excel.Worksheet)excelSheets.get_Item(1);  
            ProccesingAllRange(Convert.ToInt32(textBoxBeginRecord.Text),10,textBoxBeginCopy.Text[0],textBoxEndCopy.Text[0]); // long
            // save
            //excelAppWorkBooks = excelApp.Workbooks;
            //excelAppWorkBook = excelAppWorkBooks[1];
            excelApp.DisplayAlerts = false;
            excelAppWorkBook.Save();
            excelApp.Quit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxBeginRecord.Text = "1";
            textBoxCondition.Text = "B";
            textBoxBeginCopy.Text = "A";
            textBoxEndCopy.Text = "D";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Створив програму Ляшенко Ростислав.\n Пошта: kivi27072002@gmail.com",
                "Автор",
                MessageBoxButtons.OK
                );
        }
    }
}
