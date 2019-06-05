using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTtool
{
    // AWG监测仪项目类
    public static class AWGM
    {
        #region AWG电接口协议处理函数
        public static void AWGHandle(List<byte> Data)
        {
            //至少包含帧头（2字节）+长度（1字节）+校验位（1字节）
            if (Data.Count > 0) //接收数据处理
            {
                if(Data[0] == byte.Parse("*"))
                {

                }
                else
                {
                    Data.Clear();
                }
            }
        }

        #endregion
    }
}
