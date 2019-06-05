using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace HTtool
{
    // 绘制曲线类
    public static class DrawGraph
    {
        #region 绘制曲线函数
        /// <param name="listX">X值集合</param>
        /// <param name="listY">Y值集合</param>
        /// <param name="chart">Chart控件</param>
        /// <param name="chartTpye">曲线类型</param>
        public static void DrawSpline(List<double> listX, List<double> listY, Chart chart, byte chartTpye)
        {
            try
            {
                //X、Y值成员
                chart.Series[0].Points.DataBindXY(listX, listY);
                //chart.Series[0].Points.DataBindY(listY);//只绑定Y轴，X轴使用标记值

                //点颜色
                chart.Series[0].MarkerColor = Color.Green;
                //图表类型  设置为样条图曲线
                chart.Series[0].ChartType = SeriesChartType.Spline;
                //设置点标记的大小
                chart.Series[0].MarkerSize = 5;
                //设置曲线的颜色
                chart.Series[0].Color = (chartTpye == 1) ? Color.Orange : Color.OrangeRed;
                //设置曲线宽度
                chart.Series[0].BorderWidth = 2;
                //chart.Series[0].CustomProperties = "PointWidth=4";
                //设置是否显示坐标标注
                chart.Series[0].IsValueShownAsLabel = false;

                //删除图例标识
                chart.Legends.Clear();
                //设置游标
                chart.ChartAreas[0].CursorX.IsUserEnabled = true;
                chart.ChartAreas[0].CursorX.AutoScroll = true;
                chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                chart.ChartAreas[0].CursorY.IsUserEnabled = true;
                chart.ChartAreas[0].CursorY.AutoScroll = true;
                chart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
                //设置X轴是否可以缩放
                chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
                chart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
                //将滚动条放到图表外
                chart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = false;
                chart.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = false;
                // 设置滚动条的大小
                chart.ChartAreas[0].AxisX.ScrollBar.Size = 15;
                chart.ChartAreas[0].AxisY.ScrollBar.Size = 15;
                // 设置滚动条的按钮的风格，下面代码是将所有滚动条上的按钮都显示出来
                chart.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
                chart.ChartAreas[0].AxisX.ScrollBar.ButtonColor = Color.SkyBlue;
                chart.ChartAreas[0].AxisY.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
                chart.ChartAreas[0].AxisY.ScrollBar.ButtonColor = Color.SkyBlue;
                // 设置自动放大与缩小的最小量
                chart.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = double.NaN;
                chart.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 1;
                chart.ChartAreas[0].AxisY.ScaleView.SmallScrollSize = double.NaN;
                chart.ChartAreas[0].AxisY.ScaleView.SmallScrollMinSize = 1;
                //将X轴上格网取消
                chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                //X轴、Y轴标题
                chart.ChartAreas[0].AxisX.Title = "";
                chart.ChartAreas[0].AxisY.Title = "";
                //设置X轴范围、刻度间隔
                chart.ChartAreas[0].AxisX.Maximum = (chartTpye == 1) ? 15 : 15;
                chart.ChartAreas[0].AxisX.Minimum = (chartTpye == 1) ? 0 : 0;
                chart.ChartAreas[0].AxisX.Interval = (chartTpye == 1) ? 1 : 1;
                //设置Y轴范围  可以根据实际情况重新修改
                //double max = listY[0];
                //double min = listY[0];
                //foreach (var yValue in listY)
                //{
                //    if (max < yValue)
                //    {
                //        max = yValue;
                //    }
                //    if (min > yValue)
                //    {
                //        min = yValue;
                //    }
                //}
                //chart.ChartAreas[0].AxisY.Maximum = max;
                //chart.ChartAreas[0].AxisY.Minimum = min;
                //chart.ChartAreas[0].AxisY.Interval = (max- min)/10;
                //根据情况调整，温度曲线（10℃~70℃），功率曲线（0uW~1200uW）
                chart.ChartAreas[0].AxisY.Maximum = (chartTpye == 1) ? 40 : 1200;
                chart.ChartAreas[0].AxisY.Minimum = (chartTpye == 1) ? 10 : 0;
                chart.ChartAreas[0].AxisY.Interval = (chartTpye == 1) ? 1 : 100;

                //绑定数据源
                chart.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region 鼠标点击，通过显示游标，并缩放到响应位置
        /// <summary>
        /// 鼠标点击，通过显示游标，并缩放到响应位置函数
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="chart">Chart控件</param>
        public static void ShowCurByClick(int time, Chart chart)
        {
            //设置游标位置
            chart.ChartAreas[0].CursorX.Position = time;
            //设置视图缩放
            chart.ChartAreas[0].AxisX.ScaleView.Zoom(time - 1, time + 2);
            //改变曲线线宽
            chart.Series[0].BorderWidth = 3;
            //改变X轴刻度间隔
            chart.ChartAreas[0].AxisX.Interval = 1;
        }
        #endregion
    }
}
