using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDraw
{
    class ReadExcel
    {
        static string strConn;
        public static DataTable GetSheetNames(string path)
        {
             strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + path + ";" + "Extended Properties='Excel 12.0;HDR=YES;ReadOnly=False;'";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            
            DataTable sheetsName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" }); //得到所有sheet的名字
            OleDbCommand cmd = new OleDbCommand(string.Format("select * from [{0}]",sheetsName.Rows[0]["TABLE_NAME"].ToString()), conn);
            OleDbDataAdapter oda = new OleDbDataAdapter();
            oda.SelectCommand = cmd;
            DataSet ds = new DataSet();
            oda.Fill(ds);
            conn.Close();
            return ds.Tables[0];
            
        }

        public DataTable ReturnTable(string sheetName)
        {
            string sql = string.Format("SELECT * FROM [{0}]", sheetName); //查询字符串
            OleDbDataAdapter ada = new OleDbDataAdapter(sql, strConn);
            DataSet set = new DataSet();
            ada.Fill(set);
            return set.Tables[0];
        }
    }
}
