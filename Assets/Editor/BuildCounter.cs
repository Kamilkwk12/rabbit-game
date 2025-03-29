using System;
using System.Globalization;
using Unity.Cinemachine;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class BuildCounter : IPreprocessBuildWithReport
{
    public int callbackOrder => 0;
    
    
    public void OnPreprocessBuild(BuildReport report)
    {
        PlayerSettings.bundleVersion = IncrementBuildNumber(PlayerSettings.bundleVersion);
    }

    private string IncrementBuildNumber(string buildNumber)
    {
        int.TryParse(buildNumber, out int outputBuildNumber);

        return (outputBuildNumber+1).ToString();
    }
}
