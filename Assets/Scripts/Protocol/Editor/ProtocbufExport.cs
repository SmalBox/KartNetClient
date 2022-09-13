using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using SmalBox;
using log4net.Core;
using UnityEditor;
using UnityEngine;

namespace SmalBox
{
    public class ProtocbufExport : Singleton<ProtocbufExport>
    {
        /// <summary> 默认打表位置Master </summary>
        private static string protocFolder = "";
        
        /// <summary> 打表临时使用文件夹 </summary>
        private static string exportTempPath = "Assets/Resources/";
        
        private static List<CMDInfo> cmdInfoList = new List<CMDInfo>();
        
        [MenuItem("Tools/SmalBoxTools/ProtocExport")]
        public static void AutoExportProtocConfig()
        {
            ExportProtocConfig();
        }

        /// <summary> 协议打表 </summary>
        /// <param name="protocFolde"> 基于Protocol文件夹下的不同版本协议文件夹 </param>
        public static void ExportProtocConfig(string protocFoldeValue = "Master")
        {
            protocFolder = protocFoldeValue;
            
            RunBat();
            
            ParseProto();

            // ProtocbufCMD.cs 生成位置
            string protocUrl = Application.dataPath + "/Scripts/Protocol/ProtocbufCMD.cs";
            
            using (FileStream aFile = new FileStream(protocUrl, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(aFile, Encoding.UTF8))
                {

                    sw.WriteLine(TempExportDic.TITLE_TABLE);
                    sw.WriteLine(ReplaceUtl.Inst.Replace(TempExportDic.NAMESPACE_START, TempExportDic.NAMESPACE));
                    sw.WriteLine(ReplaceUtl.Inst.Replace(TempExportDic.TITLE_TABLE2, "ProtobufConfig"));
                    sw.WriteLine(ReplaceUtl.Inst.Replace(TempExportDic.CLASS_START_PARTIAL_SCRIPTABLEOBJECT,
                        "ProtocbufCMD"));

                    StringBuilder tb = new StringBuilder();
                    tb.AppendLine(TempExportDic.SERIALIZE);
                    tb.AppendLine(ReplaceUtl.Inst.Replace(TempExportDic.LIST, $"CMDInfo", "cmdList"));
                    sw.WriteLine(tb);

                    tb = new StringBuilder();
                    for (int i = 0; i < cmdInfoList.Count; i++)
                    {
                        tb.AppendLine(ReplaceUtl.Inst.Replace(TempExportDic.SUMMARY, TempExportDic.Convert2MultiSummary(cmdInfoList[i].cmdName)));
                        tb.AppendLine(ReplaceUtl.Inst.Replace(TempExportDic.STATIC_INT, cmdInfoList[i].cmdName,
                            cmdInfoList[i].cmdId));
                    }

                    sw.WriteLine(tb);
                    sw.WriteLine(TempExportDic.CLASS_END);
                    sw.WriteLine(TempExportDic.NAMESPACE_END);
                    sw.Close();
                }
            }

            AssetDatabase.Refresh();

            string className = $"{TempExportDic.NAMESPACE}.ProtocbufCMD";
            Type cmdType = GetType(className);
            if (cmdType == null)
            {
                LogUtl.Log($"Type {cmdType} 不存在! ", LogUtl.LogType.Red);
                return;
            }

            var cmdInstance = Activator.CreateInstance(cmdType);

            FieldInfo fieldInfo = null;
            fieldInfo = cmdType.GetField("cmdList", BindingFlags.Public | BindingFlags.Instance);
            fieldInfo.SetValue(cmdInstance, cmdInfoList);

            for (int i = 0; i < cmdInfoList.Count; i++)
            {
                fieldInfo = cmdType.GetField(cmdInfoList[i].cmdName);
                fieldInfo.SetValue(cmdInstance, cmdInfoList[i].cmdId);
            }

            SaveCmdInstance(cmdInstance as UnityEngine.Object, "ProtocbufCMD");
            AssetDatabase.Refresh();
        }

        private static void SaveCmdInstance(UnityEngine.Object instance, string name)
        {
            string path = $"{exportTempPath}{name}.asset";
            AssetDatabase.CreateAsset(instance, path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            LogUtl.LogEditor($"Create {name} Resource Complete!");
        }

        private static Type GetType(string typeName)
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type type = assembly.GetType(typeName);
                if (type != null)
                {
                    return type;
                }
            }

            return null;
        }

        public static void RunBat()
        {
            // 设置打表bat文件路径
            string protocExportBatPath = Path.Combine(Application.dataPath, "Protocol/protocExportBat.bat");
            string WorkingDirectory = Path.Combine(Application.dataPath, "Protocol");
            
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = protocExportBatPath;
            processStartInfo.Arguments = protocFolder;
            processStartInfo.CreateNoWindow = false;
            processStartInfo.UseShellExecute = true;
            processStartInfo.RedirectStandardError = false;
            processStartInfo.RedirectStandardInput = false;
            processStartInfo.RedirectStandardOutput = false;
            if (!string.IsNullOrEmpty(WorkingDirectory))
                processStartInfo.WorkingDirectory = WorkingDirectory;

            Process process = Process.Start(processStartInfo);
            process.Close();
        }

        public static void ParseProto()
        {
            cmdInfoList.Clear();

            string protoUrl = Application.dataPath + $"/Protocol/{protocFolder}/client.proto";

            bool isBegin = false;
            using (FileStream aFile = new FileStream(protoUrl, FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(aFile, Encoding.UTF8))
                {
                    while (true)
                    {
                        string context = sr.ReadLine();
                        if (context == null)
                        {
                            break;
                        }

                        // 开始解析CMD
                        if (context.IndexOf("enum Command") >= 0)
                        {
                            isBegin = true;
                            continue;
                        }

                        // 解析完毕
                        if (context.IndexOf("}") >= 0 && isBegin)
                        {
                            break;
                        }

                        if (!isBegin) continue;
                        if (string.IsNullOrEmpty(context.Trim())) continue;
                        if (context.IndexOf("CMD") < 0) continue;
                        context = context.Substring(0, context.IndexOf(";"));
                        string[] arr = context.Split('=');
                        string cmdName = arr[0].Trim();
                        int cmdId = int.Parse(arr[1].Trim());

                        if (cmdName.IndexOf("CMD") >= 0)
                        {
                            cmdName = cmdName.Substring(4, cmdName.Length - 4);
                            CMDInfo cmdInfo = new CMDInfo();
                            cmdInfo.cmdId = cmdId;
                            cmdInfo.cmdName = cmdName;
                            cmdInfoList.Add(cmdInfo);
                        }
                    }

                }
            }

            cmdInfoList.Sort((a, b) => a.cmdId > b.cmdId ? 1 : -1);
        }
    }
}