using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningConfigData {

    public RunningConfigType ConfigType;
    public RunningConfigData() { }

    public RunningConfigData(RunningConfigType _runningConfigType)
    {
        ConfigType = _runningConfigType;
    }
}
