﻿using System;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UE.InstallReferrerApi;

public class Example : MonoBehaviour
{
    private string txtInstallReferrer;
    private string txtInstallBeginTimestamp;
    private string txtReferrerClickTimestamp;
    private string txtGooglePlayInstantParameter;

    private string txtInstallReferrerFromCallback;
    private string txtInstallBeginTimestampFromCallback;
    private string txtReferrerClickTimestampFromCallback;
    private string txtGooglePlayInstantParameterFromCallback;

    void Awake()
    {
        AndroidJNIHelper.debug = true;

        txtInstallReferrer = "Install referrer: ";
        txtInstallBeginTimestamp = "Install begin timestamp: ";
        txtReferrerClickTimestamp = "Referrer click timestamp: ";
        txtGooglePlayInstantParameter = "Google Play instant parameter: ";
    }

    void OnGUI()
    {
        var styleLabel = GUI.skin.GetStyle("Label");
        styleLabel.alignment = TextAnchor.MiddleCenter;
        styleLabel.fontSize = 50;

        GUI.Label(new Rect(0, Screen.height / 2, Screen.width, 100), txtGooglePlayInstantParameterFromCallback, styleLabel);
        GUI.Label(new Rect(0, Screen.height / 2 - 100, Screen.width, 100), txtGooglePlayInstantParameter, styleLabel);
        GUI.Label(new Rect(0, Screen.height / 2 - 200, Screen.width, 100), txtReferrerClickTimestampFromCallback, styleLabel);
        GUI.Label(new Rect(0, Screen.height / 2 - 300, Screen.width, 100), txtReferrerClickTimestamp, styleLabel);
        GUI.Label(new Rect(0, Screen.height / 2 - 400, Screen.width, 100), txtInstallBeginTimestampFromCallback, styleLabel);
        GUI.Label(new Rect(0, Screen.height / 2 - 500, Screen.width, 100), txtInstallBeginTimestamp, styleLabel);
        GUI.Label(new Rect(0, Screen.height / 2 - 600, Screen.width, 100), txtInstallReferrerFromCallback, styleLabel);
        GUI.Label(new Rect(0, Screen.height / 2 - 700, Screen.width, 100), txtInstallReferrer, styleLabel);

        var styleButton = GUI.skin.GetStyle("Button");
        styleButton.alignment = TextAnchor.MiddleCenter;
        styleButton.fontSize = 50;

        if (GUI.Button(new Rect(100, Screen.height / 2 + 200, Screen.width - 200, 160), "Get install referrer details", styleButton))
        {
            InstallReferrer.GetInstallReferrerInfo((installReferrerDetails) =>
                {
                    Debug.Log("Install referrer details received!");

                    if (installReferrerDetails.InstallReferrer != null)
                    {
                        txtInstallReferrerFromCallback = installReferrerDetails.InstallReferrer;
                        Debug.Log("Install referrer: " + installReferrerDetails.InstallReferrer);
                    }
                    if (installReferrerDetails.InstallBeginTimestampSeconds != null)
                    {
                        txtInstallBeginTimestampFromCallback = installReferrerDetails.InstallBeginTimestampSeconds.ToString();
                        Debug.Log("Install begin timestamp: " + installReferrerDetails.InstallBeginTimestampSeconds);
                    }
                    if (installReferrerDetails.ReferrerClickTimestampSeconds != null)
                    {
                        txtReferrerClickTimestampFromCallback = installReferrerDetails.ReferrerClickTimestampSeconds.ToString();
                        Debug.Log("Referrer click timestamp: " + installReferrerDetails.ReferrerClickTimestampSeconds);
                    }
                    if (installReferrerDetails.GooglePlayInstantParam != null)
                    {
                        txtGooglePlayInstantParameterFromCallback = installReferrerDetails.GooglePlayInstantParam.ToString();
                        Debug.Log("Google Play instant parameter: " + installReferrerDetails.GooglePlayInstantParam);
                    }
                });
        }
    }
}
