using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDraw
{
    public  class AwardsInfo
    {
        //奖项名称
        private   string awardsName;

        //获奖人数
        private  int awardsNum;

        //抽奖顺序
        private int index;

        //单次抽奖人数
        private int singleNum;

        private static DataTable infoData;

        public  string AwardsName
        {
            get
            {
                return awardsName;
            }

            set
            {
                awardsName = value;
            }
        }

        public  int AwardsNum
        {
            get
            {
                return awardsNum;
            }

            set
            {
                awardsNum = value;
            }
        }

        public int Index
        {
            get
            {
                return index;
            }

            set
            {
                index = value;
            }
        }

        public static DataTable InfoData
        {
            get
            {
                return infoData;
            }

            set
            {
                infoData = value;
            }
        }

        public int SingleNum
        {
            get
            {
                return singleNum;
            }

            set
            {
                singleNum = value;
            }
        }
    }
}
