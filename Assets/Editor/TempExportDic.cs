namespace SmalBox
{
    public class TempExportDic
    {
        public const string NAMESPACE = "KomoriTime";

        public const string NAMESPACE_START =
            "namespace {0}\n" +
            "{\n";
        
        public const string NAMESPACE_END = "}\n";
        
        public const string TITLE_TABLE =
            "using UnityEngine;\n" +
            "using System.Collections.Generic;\n" +
            "\n";
        
        public const string TITLE_TABLE2 =
            "\t/// <summary>\n" +
            "\t/// Create by Auto\n" +
            "\t/// {0}\n" +
            "\t/// </summary>";
        
        public const string TITLE_DICVO = "using System;\n";
        public const string TITLE_JSON = "using Newtonsoft.Json;\n";

        public const string TITLE_DICVO2 =
            "\t[Serializable]\n" +
            "\t/// <summary>\n" +
            "\t/// Create by Auto\n" +
            "\t/// {0}\n" +
            "\t/// </summary>";

        public const string CLASS_START_PARTIAL_SCRIPTABLEOBJECT = "\tpublic partial class {0} : ScriptableObject {\n";
        
        public const string CLASS_START_PARTIAL_SCRIPTABLEOBJECT_IDICTABLE = "\tpublic partial class {0} : ScriptableObject, IDicTable {\n";
        
        public const string CLASS_GETDICVOBYID = 
@"        public IDicVo GetDicVoById(int id)
        {
            return dicVoList.Find((dicVo) => dicVo.id == id);
        }";
        
        public const string CLASS_START_PARTIAL = "\tpublic partial class {0} {\n";
        
        public const string CLASS_START_PARTIAL_IDICVO = "\tpublic partial class {0} : IDicVo {\n";
        
        public const string CLASS_START = "\tpublic partial class {0} {\n";
        
        public const string CLASS_END = "\t}\n";
        
        public const string SERIALIZE = "\t\t[SerializeField]";
        public const string SUMMARY = "\t\t/// <summary> {0} </summary>";
        public const string TYPE_CONVERTER_ATTRIBUTE = "\t\t[JsonConverter(typeof(TypeConverterStringToAny))]";
        public const string INT = "\t\tpublic int{0} {1};\n";
        public const string FLOAT = "\t\tpublic float{0} {1};\n";
        public const string BOOL = "\t\tpublic bool{0} {1};\n";
        public const string STRING = "\t\tpublic string{0} {1};\n";
        public const string LIST = "\t\tpublic List<{0}> {1};\n";
        public const string PUBLIC = "\t\tpublic {0} {1};\n";
        public const string STATIC_INT = "\t\tpublic static int {0} = {1};\n";
        public const string ARRAY_SUFFIX = "[]";
        public const string TABLE_ARRAY_SUFFIX = ".array";

        public const string GRID_CSV_HEADER =
@"""服务器导出"",""int"",""string"",""int.array"",""int""
""客户端导出"",""int"",""string"",""int.array"",""int""
""属性"",""id"",""gridId"",""config"",""columnNumber""
""描述"",""ID"",""GridId"",""格子矩阵数据一维数组"",""矩阵列数""
";
        public const string GRID_CSV_CONTENT_ROW = "\"\",\"{0}\",\"{1}\",\"{2}\",\"{3}\"\n";


        /// <summary>获取属性模板</summary>
        public static string GetPropTmp(string typeStr)
        {
            //string type = "";
            //if (typeStr.Contains(".array")) // 数组
            //    type = ARRAY_SUFFIX;
            if (typeStr == "int" || typeStr == "String")
                //return type.Insert(0, INT);
                return INT;
            if (typeStr == "string" || typeStr == "String")
                //return type.Insert(0, STRING);
                return STRING;
            if (typeStr == "float" || typeStr == "Float")
                //return type.Insert(0, FLOAT);
                return FLOAT;
            if (typeStr == "bool" || typeStr == "Bool")
                //return type.Insert(0, BOOL);
                return BOOL;

            //return type.Insert(0, STRING);
            return STRING;
        }
        /// <summary>
        /// 转换带有多行注释的内容为，符合多行注释的string格式
        /// </summary>
        /// <returns></returns>
        public static string Convert2MultiSummary(string propDesc)
        {
            LogUtl.LogEditor(propDesc, LogUtl.LogType.Blue);
            string[] propDescArray = propDesc.Split('\n');
            if (propDescArray.Length > 1)
            {
                // 有多行注释
                string tempPropDesc = "\n";
                for (int i = 0; i < propDescArray.Length; i++)
                {
                    tempPropDesc += "\t\t/// " + propDescArray[i] + "\n";
                }
                tempPropDesc += "\t\t///";
                return tempPropDesc;
            }
            else
                return propDesc;
        }
        
    }
}