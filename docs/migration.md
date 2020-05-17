## Migrate play-install-referrer plugin from v1.0.0 to v2.0.0

Version 1.0.0 unfortunately brought one not really well thought through thing - all the directories containing plugin's source files were added directly into project's root **Assets** folder. Which probably no one is a fan of. Apologies for that. Version 2.0.0 fixes that and in order to migrate from v1.0.0 to v2.0.0, please make sure to completely remove the plugin prior to adding plugin version 2.0.0 to your app.

In order to completely remove plugin version 1.0.0 from your project, make sure you delete following files (and any directory which might be left empty after files deletion):

- **Assets/Android/PlayInstallReferrerAndroid.cs**
- **Assets/Android/PlayInstallReferrerAndroid.cs.meta**
- **Assets/Android/installreferrer-1.1.2.aar**
- **Assets/Android/installreferrer-1.1.2.aar.meta**
- **Assets/Example/Example.cs**
- **Assets/Example/Example.cs.meta**
- **Assets/Example/Example.prefab**
- **Assets/Example/Example.prefab.meta**
- **Assets/Example/Example.unity**
- **Assets/Example/Example.unity.meta**
- **Assets/Unity/PlayInstallReferrer.cs**
- **Assets/Unity/PlayInstallReferrer.cs.meta**
- **Assets/Unity/PlayInstallReferrerDetails.cs**
- **Assets/Unity/PlayInstallReferrerDetails.cs.meta**
- **Assets/Unity/PlayInstallReferrerError.cs**
- **Assets/Unity/PlayInstallReferrerError.cs.meta**

After these deletions, feel free to import **play-install-referrer-v2.0.0.unitypackage** to your app. Once added, all plugin directories and files will be placed under **Assets/PlayInstallReferrer** directory.