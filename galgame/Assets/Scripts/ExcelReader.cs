using System.Collections.Generic;
using System.IO;
using ExcelDataReader;
using System.Text;

public class ExcelReader {   //读入excel ,装入exceldata

    public struct ExcelData {
        public string name; 
        public string content;
    }
    public static List<ExcelData> ReadExcel(string filePath) {
        List<ExcelData> exceldata = new List<ExcelData>();
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);//编码兼容
        using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        {
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                do {
                    while (reader.Read())
                    {
                        ExcelData data = new ExcelData();
                        data.name = reader.GetString(0);
                        data.content = reader.GetString(1);//2角色动作，3音乐，4场景切换......
                        exceldata.Add(data);
                    } 
                } while (reader.NextResult());
            }
        }
        return exceldata;
    }
}
