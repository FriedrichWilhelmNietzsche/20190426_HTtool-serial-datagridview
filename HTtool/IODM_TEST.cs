using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace HTtool
{
    public static class IODM_TEST
    {
        //#region 将数据写入已存在Excel
        //public static void writeExcel(string result, string filepath)
        //{
        //    //1.创建Applicaton对象
        //    Microsoft.Office.Interop.Excel.Application xApp = new

        //    Microsoft.Office.Interop.Excel.Application();

        //    //2.得到workbook对象，打开已有的文件
        //    Microsoft.Office.Interop.Excel.Workbook xBook = xApp.Workbooks.Open(filepath,
        //                          Missing.Value, Missing.Value, Missing.Value, Missing.Value,
        //                          Missing.Value, Missing.Value, Missing.Value, Missing.Value,
        //                          Missing.Value, Missing.Value, Missing.Value, Missing.Value);

        //    //3.指定要操作的Sheet
        //    Microsoft.Office.Interop.Excel.Worksheet xSheet = (Microsoft.Office.Interop.Excel.Worksheet)xBook.Sheets[1];

        //    //在第一列的左边插入一列  1:第一列
        //    //xlShiftToRight:向右移动单元格   xlShiftDown:向下移动单元格
        //    //Range Columns = (Range)xSheet.Columns[1, System.Type.Missing];
        //    //Columns.Insert(XlInsertShiftDirection.xlShiftToRight, Type.Missing);

        //    //4.向相应对位置写入相应的数据
        //    xSheet.Cells[Column(列)][Row(行)] = result;

        //    //5.保存保存WorkBook
        //    xBook.Save();
        //    //6.从内存中关闭Excel对象

        //    xSheet = null;
        //    xBook.Close();
        //    xBook = null;
        //    //关闭EXCEL的提示框
        //    xApp.DisplayAlerts = false;
        //    //Excel从内存中退出
        //    xApp.Quit();
        //    xApp = null;
        //}
        //#endregion

        #region DateGridView导出到csv格式的Excel     
        /// <summary>     
        /// 常用方法，列之间加/，一行一行输出，此文件其实是csv文件，不过默认可以当成Excel打开。     
        /// </summary>     
        /// <remarks>     
        /// using System.IO;     
        /// </remarks>     
        /// <param name="dgv">表格数据控件</param>     
        public static void DataGridViewToExcel(DataGridView dgv)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Execl files (*.csv)|*.csv";
            dlg.FilterIndex = 0;
            dlg.RestoreDirectory = true;
            dlg.CreatePrompt = true;
            dlg.Title = "保存为Excel文件";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Stream myStream;
                myStream = dlg.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
                string columnTitle = "";
                try
                {
                    //写入列标题     
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {
                        if (i > 0)
                        {
                            columnTitle += "/";
                        }
                        columnTitle += dgv.Columns[i].HeaderText;
                    }
                    sw.WriteLine(columnTitle);

                    //写入列内容     
                    for (int j = 0; j < dgv.Rows.Count; j++)
                    {
                        string columnValue = "";
                        for (int k = 0; k < dgv.Columns.Count; k++)
                        {
                            if (k > 0)
                            {
                                columnValue += "/";
                            }
                            if (dgv.Rows[j].Cells[k].Value == null)
                                columnValue += "";
                            else
                                columnValue += dgv.Rows[j].Cells[k].Value.ToString().Trim();
                        }
                        sw.WriteLine(columnValue);
                    }
                    sw.Close();
                    myStream.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                finally
                {
                    sw.Close();
                    myStream.Close();
                }
            }
        }
        #endregion
    }
}
