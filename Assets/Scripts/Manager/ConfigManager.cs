using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public enum RunningConfigType
{
    PlayerOperation,
    PropertyIntroduce,
    PropertyIntroducion
}

public class ConfigManager {

    private static ConfigManager instance;
    public static ConfigManager Instance()
    {
        if (instance == null)
            instance = new ConfigManager();
        return instance;
    }
    private ConfigManager() { }

    Dictionary<RunningConfigType, RunningConfigData> dict = new Dictionary<RunningConfigType, RunningConfigData>();

    public string GetConfigContent(RunningConfigType runningConfigType)
    {
        //string[] names = Enum.GetNames(typeof(RunningConfigType));
        //for (int i = 0; i < names.Length; i++)
        //{
        //    TextAsset text = Resources.Load<TextAsset>("Config/" + names[i]);
        //    return text.text;
        //}
        string name = Enum.GetName(typeof(RunningConfigType), runningConfigType);
        TextAsset textAsset = Resources.Load<TextAsset>("Config/" + name);
        return textAsset.text.ToString();
    }

    public void LoadTxt()
    {
        //string[] names = Enum.GetNames(typeof(RunningConfigType));
        //for(int i = 0; i < names.Length; i++)
        //{
        //    TextAsset textAsset = Resources.Load<TextAsset>("Config/" + names[i]);
        //    SplitTxt(textAsset, names[i]);
        //}
        TextAsset textAsset = Resources.Load<TextAsset>("Config/" + Enum.GetName(typeof(RunningConfigType), RunningConfigType.PropertyIntroducion));
        SplitTxt(textAsset, Enum.GetName(typeof(RunningConfigType), RunningConfigType.PropertyIntroducion));
    }

    private void SplitTxt(TextAsset txtAsset, string typeName)
    {
        string temp = txtAsset.text.Replace("\r", string.Empty);
        string[] tempArr = temp.Split('\n');
        Type type = Type.GetType(typeName);
        object obj = Activator.CreateInstance(type);
        MethodInfo method = type.GetMethod("CreateConfigItemData");
        for (int i = 0; i < tempArr.Length; i++)
        {
            string tempRow = tempArr[i];
            if (string.IsNullOrEmpty(tempRow))
                continue;
            string[] cells = tempRow.Split(' ');
            object[] param = new object[] { cells };
            method.Invoke(obj, param);
        }
        SetConfigData((RunningConfigData)obj);
    }

    public void SetConfigData(RunningConfigData data)
    {
        if (!dict.ContainsKey(data.ConfigType))
        {
            dict.Add(data.ConfigType, data);
        }
    }

    public RunningConfigData GetConfigData(RunningConfigType runningConfigType)
    {
        if (dict.ContainsKey(runningConfigType))
        {
            return dict[runningConfigType];
        }
        return null;
    }
}
