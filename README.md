# Cicanci Utils

Useful pieces of code for Unity projects. Check out the [sample project here](https://github.com/cicanci/cicanci-utils-samples).

## Installation

Open the Package Managed in the Unity Editor (Window/Package Manager). Then, click in the plus button to add a new package by selecting the `Add package from git URL...` option.

![1-add-package](https://user-images.githubusercontent.com/1128438/74468205-337c1280-4e79-11ea-816d-869133139ad1.png)

Type in this repository URL, you can use SSH `git@github.com:cicanci/cicanci-utils.git` or HTTPS `https://github.com/cicanci/cicanci-utils.git`.

![2-add-from-github](https://user-images.githubusercontent.com/1128438/74468213-3545d600-4e79-11ea-853e-371640221c2e.png)

Finally, the package will be imported and the Package Manager window will show you the version and other details. If you want to uninstall the package, just click in the `Remove` button in this screen after selecting the package in the left menu.

![3-imported-package](https://user-images.githubusercontent.com/1128438/74468215-35de6c80-4e79-11ea-8428-91b95c8d77d3.png)

## Usage

Here you will find the list of functionalities in this package, new features will be added periodically. Remeber to always include the folowing line at the beginning of your script so the package funcionalities will be available for you:

```csharp
using Cicanci.Utils;
```

### Message Manager

The following script shows how to add a listener in the `Start` method, remove it in the `OnDestroy` method, and send a message with a greeting. The class `MyMessage` represents the object sent and received.

In the script below you will need to call the method `SendMessage` in order to fire the message.

```csharp
using Cicanci.Utils;
using UnityEngine;

public class MessageBehaviour : MonoBehaviour
{
    private void Start()
    {
        MessageManager.Instance.AddListener<MyMessage>(OnMessageReceived);
    }

    private void OnDestroy()
    {
        MessageManager.Instance.RemoveListener<MyMessage>(OnMessageReceived);
    }

    private void OnMessageReceived(MyMessage message)
    {
        Debug.Log(message.Greetings);
    }

    public void SendMessage()
    {
        MyMessage message = new MyMessage { Greetings = "Hello, World!" };
        MessageManager.Instance.SendMessage(message);
    }
}

public class MyMessage
{
    public string Greetings;
}
```
