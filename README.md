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

In order to obtain install referrer details, call [GetInstallReferrerInfo](#api-pir-getinstallreferrerinfo) static method of [PlayInstallReferrer](#api-playinstallreferrer) class:

```csharp
using BlackBox.PlayInstallReferrerPlugin;

PlayInstallReferrer.GetInstallReferrerInfo((installReferrerDetails) =>
    {
        Debug.Log("Install referrer details received!");

        if (installReferrerDetails.InstallReferrer != null)
        {
            Debug.Log("Install referrer: " + installReferrerDetails.InstallReferrer);
        }
        if (installReferrerDetails.ReferrerClickTimestampSeconds != null)
        {
            Debug.Log("Referrer click timestamp: " + installReferrerDetails.ReferrerClickTimestampSeconds);
        }
        if (installReferrerDetails.InstallBeginTimestampSeconds != null)
        {
            Debug.Log("Install begin timestamp: " + installReferrerDetails.InstallBeginTimestampSeconds);
        }
        if (installReferrerDetails.GooglePlayInstant != null)
        {
            Debug.Log("Google Play instant: " + installReferrerDetails.GooglePlayInstant);
        }
    });
```

Instance of [PlayInstallReferrerDetails](#api-playinstallreferrerdetails) object will be delivered into callback method. From that instance, you can get following information:

- Install referrer string value ([InstallReferrer](#api-pird-installreferrer) property).
- Timestamp of when user clicked on URL which redirected him/her to Play Store to download your app ([ReferrerClickTimestampSeconds](#api-pird-referrerclicktimestampseconds) property).
- Timestamp of when app installation on device begun ([InstallBeginTimestampSeconds](#api-pird-installbegintimestampseconds) property).
- Information if your app's instant version (if you have one) was launched in past 7 days ([GooglePlayInstant](#api-pird-googleplayinstant) property).

## Under the hood

Important thing to notice is that in order to work properly, Play Install Referrer Library requires following permission to be added to your app's `AndroidManifest.xml`:

```xml
<uses-permission android:name="com.google.android.finsky.permission.BIND_GET_INSTALL_REFERRER_SERVICE"/>
```

Play Install Referrer Library is added to **play-install-referrer** plugin as an [AAR library](./Assets/Android/installreferrer-1.1.2.aar) and it will automatically make sure that manifest file ends up with above mentioned permission added to it upon building your app.

## API reference
   * [PlayInstallReferrer class](#api-playinstallreferrer)
      * [GetInstallReferrerInfo](#api-pir-getinstallreferrerinfo)
   * [PlayInstallReferrerDetails](#api-playinstallreferrerdetails)
      * [InstallReferrer](#api-pird-installreferrer)
      * [ReferrerClickTimestampSeconds](#api-pird-referrerclicktimestampseconds)
      * [InstallBeginTimestampSeconds](#api-pird-installbegintimestampseconds)
      * [GooglePlayInstant](#api-pird-googleplayinstant)
      
<a id="api-playinstallreferrer"></a>PlayInstallReferrer class
---

### <a id="api-pir-getinstallreferrerinfo"></a>GetInstallReferrerInfo

```csharp
public static void GetInstallReferrerInfo(Action<PlayInstallReferrerDetails> callback)
```

Static method for getting install referrer details.

| Parameters | Description |
| :------------- |:------------- |
| **callback** | **Action\<PlayInstallReferrerDetails\>**: Callback to which install referrer information will be delivered. |

<a id="api-playinstallreferrerdetails"></a>PlayInstallReferrerDetails class
---

### <a id="api-pird-installreferrer"></a>InstallReferrer

```csharp
public string InstallReferrer { get; }
```

Public property containing information about install referrer string value.

### <a id="api-pird-referrerclicktimestampseconds"></a>ReferrerClickTimestampSeconds

```csharp
public string ReferrerClickTimestampSeconds { get; }
```

Public property containing information about timestamp of when user clicked on URL which redirected him/her to Play Store.

### <a id="api-pird-installbegintimestampseconds"></a>InstallBeginTimestampSeconds

```csharp
public string InstallBeginTimestampSeconds { get; }
```

Public property containing information about timestamp of when app installation on device begun.

### <a id="api-pird-googleplayinstant"></a>GooglePlayInstant

```csharp
public string GooglePlayInstant { get; }
```

Public property containing information if app's instant version was launched in past 7 days.
