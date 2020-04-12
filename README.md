# Play Install Referrer Library wrapper for Unity

<table align="center">
    <tr>
        <td align="left">Supported platforms:</td>
        <td align="left"><img src="https://images-fe.ssl-images-amazon.com/images/I/21EctgvtXUL.png" width="16"></td>
    </tr>
    <tr>
        <td align="left">Current version:</td>
        <td align="left"><b>1.0.0</b></td>
    </tr>
    <tr>
        <td align="left">Unity IDE support:</td>
        <td align="left"><b>2017.4.35f1 and later</b></td>
    </tr>
    <tr>
        <td align="left">Latest release:</td>
        <td align="left"><a href=https://github.com/uerceg/play-install-referrer-unity/releases/tag/v1.0.0"><b>Download</b></a></td>
    </tr>
    <tr>
        <td align="left">Troubles?</td>
        <td align="left"><a href="https://github.com/uerceg/play-install-referrer-unity/issues/new"><b>Report an issue</b></a></td>
    </tr>
</table>

**play-install-referrer** is a simple wrapper around Google's [Play Install Referrer Library](https://developer.android.com/google/play/installreferrer/library) which offers basic functionality of obtaining Android referrer information from Unity app.

More information about Play Install Referrer API can be found in [official Google documentation](https://developer.android.com/google/play/installreferrer/igetinstallreferrerservice).

Version of native Play Install Referrer Library which is being used inside of latest **play-install-referrer** plugin version is [1.1.2](https://mvnrepository.com/artifact/com.android.installreferrer/installreferrer/1.1.2).

## Usage

In order to obtain install referrer details, call [GetInstallReferrerInfo](#api-ir-getinstallreferrerinfo) static method of [InstallReferrer](#api-installreferrer) class:

```csharp
using UE.InstallReferrerApi;

InstallReferrer.GetInstallReferrerInfo((installReferrerDetails) =>
    {
        Debug.Log("Install referrer details received!");

        if (installReferrerDetails.InstallReferrer != null)
        {
            Debug.Log("Install referrer: " + installReferrerDetails.InstallReferrer);
        }
        if (installReferrerDetails.InstallBeginTimestampSeconds != null)
        {
            Debug.Log("Install begin timestamp: " + installReferrerDetails.InstallBeginTimestampSeconds);
        }
        if (installReferrerDetails.ReferrerClickTimestampSeconds != null)
        {
            Debug.Log("Referrer click timestamp: " + installReferrerDetails.ReferrerClickTimestampSeconds);
        }
        if (installReferrerDetails.GooglePlayInstantParam != null)
        {
            Debug.Log("Google Play instant parameter: " + installReferrerDetails.GooglePlayInstantParam);
        }
    });
```

Instance of [InstallReferrerDetails](#api-installreferrerdetails) object will be delivered into callback method. From that instance, you can get following information:

- Install referrer string value ([InstallReferrer](#api-ird-installreferrer) property).
- Timestamp of when app installation on device begun ([InstallBeginTimestampSeconds](#api-ird-installbegintimestampseconds) property).
- Timestamp of when user clicked on URL which redirected him/her to Play Store to download your app ([ReferrerClickTimestampSeconds](#api-ird-referrerclicktimestampseconds) property).
- Information if your app's instant version (if you have one) was launched in past 7 days ([GooglePlayInstantParam](#api-ird-googleplayinstantparam) property).

## Under the hood

Important thing to notice is that in order to work properly, Play Install Referrer Library requires following permission to be added to your app's `AndroidManifest.xml`:

```xml
<uses-permission android:name="com.google.android.finsky.permission.BIND_GET_INSTALL_REFERRER_SERVICE"/>
```

Play Install Referrer Library is added to **play-install-referrer** plugin as an [AAR library](./Assets/Android/installreferrer-1.1.2.aar) and it will automatically make sure that manifest file ends up with above mentioned permission added to it upon building your app.

## API reference
   * [InstallReferrer class](#api-installreferrer)
      * [GetInstallReferrerInfo](#api-ir-getinstallreferrerinfo)
   * [InstallReferrerDetails](#api-installreferrerdetails)
      * [InstallReferrer](#api-ird-installreferrer)
      * [InstallBeginTimestampSeconds](#api-ird-installbegintimestampseconds)
      * [ReferrerClickTimestampSeconds](#api-ird-referrerclicktimestampseconds)
      * [GooglePlayInstantParam](#api-ird-googleplayinstantparam)
      
<a id="api-installreferrer"></a>InstallReferrer class
---

### <a id="api-ir-getinstallreferrerinfo"></a>GetInstallReferrerInfo

```csharp
public static void GetInstallReferrerInfo(Action<InstallReferrerDetails> callback)
```

Get install referrer details.

| Parameters | Description |
| :------------- |:------------- |
| **callback** | **Action\<InstallReferrerDetails\>**: Callback to which install referrer information is being delivered. |

<a id="api-installreferrerdetails"></a>InstallReferrerDetails class
---

### <a id="api-ird-installreferrer"></a>InstallReferrer class

```csharp
public string InstallReferrer { get; }
```

Public property containing information about install referrer string value.

### <a id="api-ird-installbegintimestampseconds"></a>InstallBeginTimestampSeconds

```csharp
public string InstallBeginTimestampSeconds { get; }
```

Public property containing information about timestamp of when app installation on device begun.

### <a id="api-ird-referrerclicktimestampseconds"></a>ReferrerClickTimestampSeconds

```csharp
public string ReferrerClickTimestampSeconds { get; }
```

Public property containing information about timestamp of when user clicked on URL which redirected him/her to Play Store.

### <a id="api-ird-googleplayinstantparam"></a>GooglePlayInstantParam

```csharp
public string GooglePlayInstantParam { get; }
```

Public property containing information if app's instant version was launched in past 7 days.
