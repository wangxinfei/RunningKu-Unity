using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyIntroducion : RunningConfigData
{
    public PropertyIntroducion() : base(RunningConfigType.PropertyIntroducion)
    {

    }

    public Dictionary<string, PropertyIntroducionItem> dict = new Dictionary<string, PropertyIntroducionItem>();

    public void CreateConfigItemData(string[] str)
    {
        PropertyIntroducionItem propertyIntroduceItem = new PropertyIntroducionItem();
        propertyIntroduceItem.InitData(str);
        SetConfigItemData(propertyIntroduceItem);
    }

    public void SetConfigItemData(PropertyIntroducionItem data)
    {
        if (!dict.ContainsKey(data.PropertyName))
        {
            dict.Add(data.PropertyName, data);
        }
    }

    public PropertyIntroducionItem GetConfigItemData(string name)
    {
        if (dict.ContainsKey(name))
        {
            return dict[name];
        }
        return null;
    }

}

public class PropertyIntroducionItem
{
    public string PropertyName;
    public string Effect;
    public string DurationTime;

    public void InitData(string[] args)
    {
        PropertyName = args[0];
        Effect = args[1];
        DurationTime = args[2];
    }
}