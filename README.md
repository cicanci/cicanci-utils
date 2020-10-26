# Cicanci Utils

Useful pieces of code for Unity projects.

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

### Message Service

The following script shows how to add create a `Service` class to register the `MessageService`, add a listener in the `Start` method, remove it in the `OnDestroy` method, and send a message with a greeting. The class `MyMessage` represents the object sent and received.

In the script below you will need to call the method `SendMessage` in order to fire the message. The message received is printed using the `LogService`.

```csharp
using Cicanci.Utils;
using UnityEngine;

public class MessageManagerSample : MonoBehaviour
{
    private Services _services = new Services();

    private void Start() 
    {
        _services.Register<MessageService>();
        _services.Register<LogService>()

        _services.Get<MessageService>().AddListener<MyMessage>(OnMessageReceived);
    }

    private void OnDestroy()
    {
        _services.Get<MessageService>().RemoveListener<MyMessage>(OnMessageReceived);

        _services.Unregister<MessageService>();
        _services.Unregister<LogService>();
    }

    private void OnMessageReceived(MyMessage message)
    {
        _services.Get<LogService>().Log(message.Greetings);
    }

    public void SendMessage()
    {
        MyMessage message = new MyMessage { Greetings = "Hello, World!" };
        _services.Get<MessageService>().SendMessage(message);
    }
}

public class MyMessage
{
    public string Greetings;
}
```


### Mono Proxy

This class can be used to listen to `Update` callbacks without extending `MonoBehaviour` in your class. The message received is printed using the `LogService`.


```csharp
using Cicanci.Utils;

private class PrintMessage
{
    private Services _services = new Services();

    private PrintMessage() 
    {
        _services.Register<LogService>()
    }

    ~PrintMessage()
    {
        _services.Unregister<LogService>();
    }

    public void AddUpdate()
    {
        MonoProxy.Instance.UpdateEvent += OnUpdate;
    }

    public void RemoveUpdate()
    {
        MonoProxy.Instance.UpdateEvent -= OnUpdate;
    }

    private void OnUpdate()
    {
        _services.Log<LogService>().Log("Update from MonoProxy was called!");
    }
}
```
