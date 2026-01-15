using System.Collections.Generic;
using System.Text.Json;
using Stagehand.Core;
using Stagehand.Exceptions;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class BrowserTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Browser
        {
            CdpURL = "ws://localhost:9222",
            LaunchOptions = new()
            {
                AcceptDownloads = true,
                Args = ["string"],
                CdpURL = "cdpUrl",
                ChromiumSandbox = true,
                ConnectTimeoutMs = 0,
                DeviceScaleFactor = 0,
                Devtools = true,
                DownloadsPath = "downloadsPath",
                ExecutablePath = "executablePath",
                HasTouch = true,
                Headless = true,
                IgnoreDefaultArgs = true,
                IgnoreHTTPSErrors = true,
                Locale = "locale",
                PreserveUserDataDir = true,
                Proxy = new()
                {
                    Server = "server",
                    Bypass = "bypass",
                    Password = "password",
                    Username = "username",
                },
                UserDataDir = "userDataDir",
                Viewport = new() { Height = 0, Width = 0 },
            },
            Type = Type.Local,
        };

        string expectedCdpURL = "ws://localhost:9222";
        LaunchOptions expectedLaunchOptions = new()
        {
            AcceptDownloads = true,
            Args = ["string"],
            CdpURL = "cdpUrl",
            ChromiumSandbox = true,
            ConnectTimeoutMs = 0,
            DeviceScaleFactor = 0,
            Devtools = true,
            DownloadsPath = "downloadsPath",
            ExecutablePath = "executablePath",
            HasTouch = true,
            Headless = true,
            IgnoreDefaultArgs = true,
            IgnoreHTTPSErrors = true,
            Locale = "locale",
            PreserveUserDataDir = true,
            Proxy = new()
            {
                Server = "server",
                Bypass = "bypass",
                Password = "password",
                Username = "username",
            },
            UserDataDir = "userDataDir",
            Viewport = new() { Height = 0, Width = 0 },
        };
        ApiEnum<string, Type> expectedType = Type.Local;

        Assert.Equal(expectedCdpURL, model.CdpURL);
        Assert.Equal(expectedLaunchOptions, model.LaunchOptions);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Browser
        {
            CdpURL = "ws://localhost:9222",
            LaunchOptions = new()
            {
                AcceptDownloads = true,
                Args = ["string"],
                CdpURL = "cdpUrl",
                ChromiumSandbox = true,
                ConnectTimeoutMs = 0,
                DeviceScaleFactor = 0,
                Devtools = true,
                DownloadsPath = "downloadsPath",
                ExecutablePath = "executablePath",
                HasTouch = true,
                Headless = true,
                IgnoreDefaultArgs = true,
                IgnoreHTTPSErrors = true,
                Locale = "locale",
                PreserveUserDataDir = true,
                Proxy = new()
                {
                    Server = "server",
                    Bypass = "bypass",
                    Password = "password",
                    Username = "username",
                },
                UserDataDir = "userDataDir",
                Viewport = new() { Height = 0, Width = 0 },
            },
            Type = Type.Local,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Browser>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Browser
        {
            CdpURL = "ws://localhost:9222",
            LaunchOptions = new()
            {
                AcceptDownloads = true,
                Args = ["string"],
                CdpURL = "cdpUrl",
                ChromiumSandbox = true,
                ConnectTimeoutMs = 0,
                DeviceScaleFactor = 0,
                Devtools = true,
                DownloadsPath = "downloadsPath",
                ExecutablePath = "executablePath",
                HasTouch = true,
                Headless = true,
                IgnoreDefaultArgs = true,
                IgnoreHTTPSErrors = true,
                Locale = "locale",
                PreserveUserDataDir = true,
                Proxy = new()
                {
                    Server = "server",
                    Bypass = "bypass",
                    Password = "password",
                    Username = "username",
                },
                UserDataDir = "userDataDir",
                Viewport = new() { Height = 0, Width = 0 },
            },
            Type = Type.Local,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Browser>(element);
        Assert.NotNull(deserialized);

        string expectedCdpURL = "ws://localhost:9222";
        LaunchOptions expectedLaunchOptions = new()
        {
            AcceptDownloads = true,
            Args = ["string"],
            CdpURL = "cdpUrl",
            ChromiumSandbox = true,
            ConnectTimeoutMs = 0,
            DeviceScaleFactor = 0,
            Devtools = true,
            DownloadsPath = "downloadsPath",
            ExecutablePath = "executablePath",
            HasTouch = true,
            Headless = true,
            IgnoreDefaultArgs = true,
            IgnoreHTTPSErrors = true,
            Locale = "locale",
            PreserveUserDataDir = true,
            Proxy = new()
            {
                Server = "server",
                Bypass = "bypass",
                Password = "password",
                Username = "username",
            },
            UserDataDir = "userDataDir",
            Viewport = new() { Height = 0, Width = 0 },
        };
        ApiEnum<string, Type> expectedType = Type.Local;

        Assert.Equal(expectedCdpURL, deserialized.CdpURL);
        Assert.Equal(expectedLaunchOptions, deserialized.LaunchOptions);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Browser
        {
            CdpURL = "ws://localhost:9222",
            LaunchOptions = new()
            {
                AcceptDownloads = true,
                Args = ["string"],
                CdpURL = "cdpUrl",
                ChromiumSandbox = true,
                ConnectTimeoutMs = 0,
                DeviceScaleFactor = 0,
                Devtools = true,
                DownloadsPath = "downloadsPath",
                ExecutablePath = "executablePath",
                HasTouch = true,
                Headless = true,
                IgnoreDefaultArgs = true,
                IgnoreHTTPSErrors = true,
                Locale = "locale",
                PreserveUserDataDir = true,
                Proxy = new()
                {
                    Server = "server",
                    Bypass = "bypass",
                    Password = "password",
                    Username = "username",
                },
                UserDataDir = "userDataDir",
                Viewport = new() { Height = 0, Width = 0 },
            },
            Type = Type.Local,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Browser { };

        Assert.Null(model.CdpURL);
        Assert.False(model.RawData.ContainsKey("cdpUrl"));
        Assert.Null(model.LaunchOptions);
        Assert.False(model.RawData.ContainsKey("launchOptions"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Browser { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Browser
        {
            // Null should be interpreted as omitted for these properties
            CdpURL = null,
            LaunchOptions = null,
            Type = null,
        };

        Assert.Null(model.CdpURL);
        Assert.False(model.RawData.ContainsKey("cdpUrl"));
        Assert.Null(model.LaunchOptions);
        Assert.False(model.RawData.ContainsKey("launchOptions"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Browser
        {
            // Null should be interpreted as omitted for these properties
            CdpURL = null,
            LaunchOptions = null,
            Type = null,
        };

        model.Validate();
    }
}

public class LaunchOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LaunchOptions
        {
            AcceptDownloads = true,
            Args = ["string"],
            CdpURL = "cdpUrl",
            ChromiumSandbox = true,
            ConnectTimeoutMs = 0,
            DeviceScaleFactor = 0,
            Devtools = true,
            DownloadsPath = "downloadsPath",
            ExecutablePath = "executablePath",
            HasTouch = true,
            Headless = true,
            IgnoreDefaultArgs = true,
            IgnoreHTTPSErrors = true,
            Locale = "locale",
            PreserveUserDataDir = true,
            Proxy = new()
            {
                Server = "server",
                Bypass = "bypass",
                Password = "password",
                Username = "username",
            },
            UserDataDir = "userDataDir",
            Viewport = new() { Height = 0, Width = 0 },
        };

        bool expectedAcceptDownloads = true;
        List<string> expectedArgs = ["string"];
        string expectedCdpURL = "cdpUrl";
        bool expectedChromiumSandbox = true;
        double expectedConnectTimeoutMs = 0;
        double expectedDeviceScaleFactor = 0;
        bool expectedDevtools = true;
        string expectedDownloadsPath = "downloadsPath";
        string expectedExecutablePath = "executablePath";
        bool expectedHasTouch = true;
        bool expectedHeadless = true;
        IgnoreDefaultArgs expectedIgnoreDefaultArgs = true;
        bool expectedIgnoreHTTPSErrors = true;
        string expectedLocale = "locale";
        bool expectedPreserveUserDataDir = true;
        Proxy expectedProxy = new()
        {
            Server = "server",
            Bypass = "bypass",
            Password = "password",
            Username = "username",
        };
        string expectedUserDataDir = "userDataDir";
        Viewport expectedViewport = new() { Height = 0, Width = 0 };

        Assert.Equal(expectedAcceptDownloads, model.AcceptDownloads);
        Assert.NotNull(model.Args);
        Assert.Equal(expectedArgs.Count, model.Args.Count);
        for (int i = 0; i < expectedArgs.Count; i++)
        {
            Assert.Equal(expectedArgs[i], model.Args[i]);
        }
        Assert.Equal(expectedCdpURL, model.CdpURL);
        Assert.Equal(expectedChromiumSandbox, model.ChromiumSandbox);
        Assert.Equal(expectedConnectTimeoutMs, model.ConnectTimeoutMs);
        Assert.Equal(expectedDeviceScaleFactor, model.DeviceScaleFactor);
        Assert.Equal(expectedDevtools, model.Devtools);
        Assert.Equal(expectedDownloadsPath, model.DownloadsPath);
        Assert.Equal(expectedExecutablePath, model.ExecutablePath);
        Assert.Equal(expectedHasTouch, model.HasTouch);
        Assert.Equal(expectedHeadless, model.Headless);
        Assert.Equal(expectedIgnoreDefaultArgs, model.IgnoreDefaultArgs);
        Assert.Equal(expectedIgnoreHTTPSErrors, model.IgnoreHTTPSErrors);
        Assert.Equal(expectedLocale, model.Locale);
        Assert.Equal(expectedPreserveUserDataDir, model.PreserveUserDataDir);
        Assert.Equal(expectedProxy, model.Proxy);
        Assert.Equal(expectedUserDataDir, model.UserDataDir);
        Assert.Equal(expectedViewport, model.Viewport);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LaunchOptions
        {
            AcceptDownloads = true,
            Args = ["string"],
            CdpURL = "cdpUrl",
            ChromiumSandbox = true,
            ConnectTimeoutMs = 0,
            DeviceScaleFactor = 0,
            Devtools = true,
            DownloadsPath = "downloadsPath",
            ExecutablePath = "executablePath",
            HasTouch = true,
            Headless = true,
            IgnoreDefaultArgs = true,
            IgnoreHTTPSErrors = true,
            Locale = "locale",
            PreserveUserDataDir = true,
            Proxy = new()
            {
                Server = "server",
                Bypass = "bypass",
                Password = "password",
                Username = "username",
            },
            UserDataDir = "userDataDir",
            Viewport = new() { Height = 0, Width = 0 },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<LaunchOptions>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LaunchOptions
        {
            AcceptDownloads = true,
            Args = ["string"],
            CdpURL = "cdpUrl",
            ChromiumSandbox = true,
            ConnectTimeoutMs = 0,
            DeviceScaleFactor = 0,
            Devtools = true,
            DownloadsPath = "downloadsPath",
            ExecutablePath = "executablePath",
            HasTouch = true,
            Headless = true,
            IgnoreDefaultArgs = true,
            IgnoreHTTPSErrors = true,
            Locale = "locale",
            PreserveUserDataDir = true,
            Proxy = new()
            {
                Server = "server",
                Bypass = "bypass",
                Password = "password",
                Username = "username",
            },
            UserDataDir = "userDataDir",
            Viewport = new() { Height = 0, Width = 0 },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<LaunchOptions>(element);
        Assert.NotNull(deserialized);

        bool expectedAcceptDownloads = true;
        List<string> expectedArgs = ["string"];
        string expectedCdpURL = "cdpUrl";
        bool expectedChromiumSandbox = true;
        double expectedConnectTimeoutMs = 0;
        double expectedDeviceScaleFactor = 0;
        bool expectedDevtools = true;
        string expectedDownloadsPath = "downloadsPath";
        string expectedExecutablePath = "executablePath";
        bool expectedHasTouch = true;
        bool expectedHeadless = true;
        IgnoreDefaultArgs expectedIgnoreDefaultArgs = true;
        bool expectedIgnoreHTTPSErrors = true;
        string expectedLocale = "locale";
        bool expectedPreserveUserDataDir = true;
        Proxy expectedProxy = new()
        {
            Server = "server",
            Bypass = "bypass",
            Password = "password",
            Username = "username",
        };
        string expectedUserDataDir = "userDataDir";
        Viewport expectedViewport = new() { Height = 0, Width = 0 };

        Assert.Equal(expectedAcceptDownloads, deserialized.AcceptDownloads);
        Assert.NotNull(deserialized.Args);
        Assert.Equal(expectedArgs.Count, deserialized.Args.Count);
        for (int i = 0; i < expectedArgs.Count; i++)
        {
            Assert.Equal(expectedArgs[i], deserialized.Args[i]);
        }
        Assert.Equal(expectedCdpURL, deserialized.CdpURL);
        Assert.Equal(expectedChromiumSandbox, deserialized.ChromiumSandbox);
        Assert.Equal(expectedConnectTimeoutMs, deserialized.ConnectTimeoutMs);
        Assert.Equal(expectedDeviceScaleFactor, deserialized.DeviceScaleFactor);
        Assert.Equal(expectedDevtools, deserialized.Devtools);
        Assert.Equal(expectedDownloadsPath, deserialized.DownloadsPath);
        Assert.Equal(expectedExecutablePath, deserialized.ExecutablePath);
        Assert.Equal(expectedHasTouch, deserialized.HasTouch);
        Assert.Equal(expectedHeadless, deserialized.Headless);
        Assert.Equal(expectedIgnoreDefaultArgs, deserialized.IgnoreDefaultArgs);
        Assert.Equal(expectedIgnoreHTTPSErrors, deserialized.IgnoreHTTPSErrors);
        Assert.Equal(expectedLocale, deserialized.Locale);
        Assert.Equal(expectedPreserveUserDataDir, deserialized.PreserveUserDataDir);
        Assert.Equal(expectedProxy, deserialized.Proxy);
        Assert.Equal(expectedUserDataDir, deserialized.UserDataDir);
        Assert.Equal(expectedViewport, deserialized.Viewport);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LaunchOptions
        {
            AcceptDownloads = true,
            Args = ["string"],
            CdpURL = "cdpUrl",
            ChromiumSandbox = true,
            ConnectTimeoutMs = 0,
            DeviceScaleFactor = 0,
            Devtools = true,
            DownloadsPath = "downloadsPath",
            ExecutablePath = "executablePath",
            HasTouch = true,
            Headless = true,
            IgnoreDefaultArgs = true,
            IgnoreHTTPSErrors = true,
            Locale = "locale",
            PreserveUserDataDir = true,
            Proxy = new()
            {
                Server = "server",
                Bypass = "bypass",
                Password = "password",
                Username = "username",
            },
            UserDataDir = "userDataDir",
            Viewport = new() { Height = 0, Width = 0 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LaunchOptions { };

        Assert.Null(model.AcceptDownloads);
        Assert.False(model.RawData.ContainsKey("acceptDownloads"));
        Assert.Null(model.Args);
        Assert.False(model.RawData.ContainsKey("args"));
        Assert.Null(model.CdpURL);
        Assert.False(model.RawData.ContainsKey("cdpUrl"));
        Assert.Null(model.ChromiumSandbox);
        Assert.False(model.RawData.ContainsKey("chromiumSandbox"));
        Assert.Null(model.ConnectTimeoutMs);
        Assert.False(model.RawData.ContainsKey("connectTimeoutMs"));
        Assert.Null(model.DeviceScaleFactor);
        Assert.False(model.RawData.ContainsKey("deviceScaleFactor"));
        Assert.Null(model.Devtools);
        Assert.False(model.RawData.ContainsKey("devtools"));
        Assert.Null(model.DownloadsPath);
        Assert.False(model.RawData.ContainsKey("downloadsPath"));
        Assert.Null(model.ExecutablePath);
        Assert.False(model.RawData.ContainsKey("executablePath"));
        Assert.Null(model.HasTouch);
        Assert.False(model.RawData.ContainsKey("hasTouch"));
        Assert.Null(model.Headless);
        Assert.False(model.RawData.ContainsKey("headless"));
        Assert.Null(model.IgnoreDefaultArgs);
        Assert.False(model.RawData.ContainsKey("ignoreDefaultArgs"));
        Assert.Null(model.IgnoreHTTPSErrors);
        Assert.False(model.RawData.ContainsKey("ignoreHTTPSErrors"));
        Assert.Null(model.Locale);
        Assert.False(model.RawData.ContainsKey("locale"));
        Assert.Null(model.PreserveUserDataDir);
        Assert.False(model.RawData.ContainsKey("preserveUserDataDir"));
        Assert.Null(model.Proxy);
        Assert.False(model.RawData.ContainsKey("proxy"));
        Assert.Null(model.UserDataDir);
        Assert.False(model.RawData.ContainsKey("userDataDir"));
        Assert.Null(model.Viewport);
        Assert.False(model.RawData.ContainsKey("viewport"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new LaunchOptions { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new LaunchOptions
        {
            // Null should be interpreted as omitted for these properties
            AcceptDownloads = null,
            Args = null,
            CdpURL = null,
            ChromiumSandbox = null,
            ConnectTimeoutMs = null,
            DeviceScaleFactor = null,
            Devtools = null,
            DownloadsPath = null,
            ExecutablePath = null,
            HasTouch = null,
            Headless = null,
            IgnoreDefaultArgs = null,
            IgnoreHTTPSErrors = null,
            Locale = null,
            PreserveUserDataDir = null,
            Proxy = null,
            UserDataDir = null,
            Viewport = null,
        };

        Assert.Null(model.AcceptDownloads);
        Assert.False(model.RawData.ContainsKey("acceptDownloads"));
        Assert.Null(model.Args);
        Assert.False(model.RawData.ContainsKey("args"));
        Assert.Null(model.CdpURL);
        Assert.False(model.RawData.ContainsKey("cdpUrl"));
        Assert.Null(model.ChromiumSandbox);
        Assert.False(model.RawData.ContainsKey("chromiumSandbox"));
        Assert.Null(model.ConnectTimeoutMs);
        Assert.False(model.RawData.ContainsKey("connectTimeoutMs"));
        Assert.Null(model.DeviceScaleFactor);
        Assert.False(model.RawData.ContainsKey("deviceScaleFactor"));
        Assert.Null(model.Devtools);
        Assert.False(model.RawData.ContainsKey("devtools"));
        Assert.Null(model.DownloadsPath);
        Assert.False(model.RawData.ContainsKey("downloadsPath"));
        Assert.Null(model.ExecutablePath);
        Assert.False(model.RawData.ContainsKey("executablePath"));
        Assert.Null(model.HasTouch);
        Assert.False(model.RawData.ContainsKey("hasTouch"));
        Assert.Null(model.Headless);
        Assert.False(model.RawData.ContainsKey("headless"));
        Assert.Null(model.IgnoreDefaultArgs);
        Assert.False(model.RawData.ContainsKey("ignoreDefaultArgs"));
        Assert.Null(model.IgnoreHTTPSErrors);
        Assert.False(model.RawData.ContainsKey("ignoreHTTPSErrors"));
        Assert.Null(model.Locale);
        Assert.False(model.RawData.ContainsKey("locale"));
        Assert.Null(model.PreserveUserDataDir);
        Assert.False(model.RawData.ContainsKey("preserveUserDataDir"));
        Assert.Null(model.Proxy);
        Assert.False(model.RawData.ContainsKey("proxy"));
        Assert.Null(model.UserDataDir);
        Assert.False(model.RawData.ContainsKey("userDataDir"));
        Assert.Null(model.Viewport);
        Assert.False(model.RawData.ContainsKey("viewport"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LaunchOptions
        {
            // Null should be interpreted as omitted for these properties
            AcceptDownloads = null,
            Args = null,
            CdpURL = null,
            ChromiumSandbox = null,
            ConnectTimeoutMs = null,
            DeviceScaleFactor = null,
            Devtools = null,
            DownloadsPath = null,
            ExecutablePath = null,
            HasTouch = null,
            Headless = null,
            IgnoreDefaultArgs = null,
            IgnoreHTTPSErrors = null,
            Locale = null,
            PreserveUserDataDir = null,
            Proxy = null,
            UserDataDir = null,
            Viewport = null,
        };

        model.Validate();
    }
}

public class IgnoreDefaultArgsTest : TestBase
{
    [Fact]
    public void BoolValidationWorks()
    {
        IgnoreDefaultArgs value = new(true);
        value.Validate();
    }

    [Fact]
    public void StringsValidationWorks()
    {
        IgnoreDefaultArgs value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        IgnoreDefaultArgs value = new(true);
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<IgnoreDefaultArgs>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        IgnoreDefaultArgs value = new(["string"]);
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<IgnoreDefaultArgs>(element);

        Assert.Equal(value, deserialized);
    }
}

public class ProxyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Proxy
        {
            Server = "server",
            Bypass = "bypass",
            Password = "password",
            Username = "username",
        };

        string expectedServer = "server";
        string expectedBypass = "bypass";
        string expectedPassword = "password";
        string expectedUsername = "username";

        Assert.Equal(expectedServer, model.Server);
        Assert.Equal(expectedBypass, model.Bypass);
        Assert.Equal(expectedPassword, model.Password);
        Assert.Equal(expectedUsername, model.Username);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Proxy
        {
            Server = "server",
            Bypass = "bypass",
            Password = "password",
            Username = "username",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Proxy>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Proxy
        {
            Server = "server",
            Bypass = "bypass",
            Password = "password",
            Username = "username",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Proxy>(element);
        Assert.NotNull(deserialized);

        string expectedServer = "server";
        string expectedBypass = "bypass";
        string expectedPassword = "password";
        string expectedUsername = "username";

        Assert.Equal(expectedServer, deserialized.Server);
        Assert.Equal(expectedBypass, deserialized.Bypass);
        Assert.Equal(expectedPassword, deserialized.Password);
        Assert.Equal(expectedUsername, deserialized.Username);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Proxy
        {
            Server = "server",
            Bypass = "bypass",
            Password = "password",
            Username = "username",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Proxy { Server = "server" };

        Assert.Null(model.Bypass);
        Assert.False(model.RawData.ContainsKey("bypass"));
        Assert.Null(model.Password);
        Assert.False(model.RawData.ContainsKey("password"));
        Assert.Null(model.Username);
        Assert.False(model.RawData.ContainsKey("username"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Proxy { Server = "server" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Proxy
        {
            Server = "server",

            // Null should be interpreted as omitted for these properties
            Bypass = null,
            Password = null,
            Username = null,
        };

        Assert.Null(model.Bypass);
        Assert.False(model.RawData.ContainsKey("bypass"));
        Assert.Null(model.Password);
        Assert.False(model.RawData.ContainsKey("password"));
        Assert.Null(model.Username);
        Assert.False(model.RawData.ContainsKey("username"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Proxy
        {
            Server = "server",

            // Null should be interpreted as omitted for these properties
            Bypass = null,
            Password = null,
            Username = null,
        };

        model.Validate();
    }
}

public class ViewportTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Viewport { Height = 0, Width = 0 };

        double expectedHeight = 0;
        double expectedWidth = 0;

        Assert.Equal(expectedHeight, model.Height);
        Assert.Equal(expectedWidth, model.Width);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Viewport { Height = 0, Width = 0 };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Viewport>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Viewport { Height = 0, Width = 0 };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Viewport>(element);
        Assert.NotNull(deserialized);

        double expectedHeight = 0;
        double expectedWidth = 0;

        Assert.Equal(expectedHeight, deserialized.Height);
        Assert.Equal(expectedWidth, deserialized.Width);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Viewport { Height = 0, Width = 0 };

        model.Validate();
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.Local)]
    [InlineData(Type.Browserbase)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.Local)]
    [InlineData(Type.Browserbase)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BrowserbaseSessionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrowserbaseSessionCreateParams
        {
            BrowserSettings = new()
            {
                AdvancedStealth = true,
                BlockAds = true,
                Context = new() { ID = "id", Persist = true },
                ExtensionID = "extensionId",
                Fingerprint = new()
                {
                    Browsers = [FingerprintBrowser.Chrome],
                    Devices = [Device.Desktop],
                    HTTPVersion = HTTPVersion.V1,
                    Locales = ["string"],
                    OperatingSystems = [OperatingSystem.Android],
                    Screen = new()
                    {
                        MaxHeight = 0,
                        MaxWidth = 0,
                        MinHeight = 0,
                        MinWidth = 0,
                    },
                },
                LogSession = true,
                RecordSession = true,
                SolveCaptchas = true,
                Viewport = new() { Height = 0, Width = 0 },
            },
            ExtensionID = "extensionId",
            KeepAlive = true,
            ProjectID = "projectId",
            Proxies = true,
            Region = Region.UsWest2,
            Timeout = 0,
            UserMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        BrowserSettings expectedBrowserSettings = new()
        {
            AdvancedStealth = true,
            BlockAds = true,
            Context = new() { ID = "id", Persist = true },
            ExtensionID = "extensionId",
            Fingerprint = new()
            {
                Browsers = [FingerprintBrowser.Chrome],
                Devices = [Device.Desktop],
                HTTPVersion = HTTPVersion.V1,
                Locales = ["string"],
                OperatingSystems = [OperatingSystem.Android],
                Screen = new()
                {
                    MaxHeight = 0,
                    MaxWidth = 0,
                    MinHeight = 0,
                    MinWidth = 0,
                },
            },
            LogSession = true,
            RecordSession = true,
            SolveCaptchas = true,
            Viewport = new() { Height = 0, Width = 0 },
        };
        string expectedExtensionID = "extensionId";
        bool expectedKeepAlive = true;
        string expectedProjectID = "projectId";
        Proxies expectedProxies = true;
        ApiEnum<string, Region> expectedRegion = Region.UsWest2;
        double expectedTimeout = 0;
        Dictionary<string, JsonElement> expectedUserMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedBrowserSettings, model.BrowserSettings);
        Assert.Equal(expectedExtensionID, model.ExtensionID);
        Assert.Equal(expectedKeepAlive, model.KeepAlive);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedProxies, model.Proxies);
        Assert.Equal(expectedRegion, model.Region);
        Assert.Equal(expectedTimeout, model.Timeout);
        Assert.NotNull(model.UserMetadata);
        Assert.Equal(expectedUserMetadata.Count, model.UserMetadata.Count);
        foreach (var item in expectedUserMetadata)
        {
            Assert.True(model.UserMetadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.UserMetadata[item.Key]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrowserbaseSessionCreateParams
        {
            BrowserSettings = new()
            {
                AdvancedStealth = true,
                BlockAds = true,
                Context = new() { ID = "id", Persist = true },
                ExtensionID = "extensionId",
                Fingerprint = new()
                {
                    Browsers = [FingerprintBrowser.Chrome],
                    Devices = [Device.Desktop],
                    HTTPVersion = HTTPVersion.V1,
                    Locales = ["string"],
                    OperatingSystems = [OperatingSystem.Android],
                    Screen = new()
                    {
                        MaxHeight = 0,
                        MaxWidth = 0,
                        MinHeight = 0,
                        MinWidth = 0,
                    },
                },
                LogSession = true,
                RecordSession = true,
                SolveCaptchas = true,
                Viewport = new() { Height = 0, Width = 0 },
            },
            ExtensionID = "extensionId",
            KeepAlive = true,
            ProjectID = "projectId",
            Proxies = true,
            Region = Region.UsWest2,
            Timeout = 0,
            UserMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BrowserbaseSessionCreateParams>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrowserbaseSessionCreateParams
        {
            BrowserSettings = new()
            {
                AdvancedStealth = true,
                BlockAds = true,
                Context = new() { ID = "id", Persist = true },
                ExtensionID = "extensionId",
                Fingerprint = new()
                {
                    Browsers = [FingerprintBrowser.Chrome],
                    Devices = [Device.Desktop],
                    HTTPVersion = HTTPVersion.V1,
                    Locales = ["string"],
                    OperatingSystems = [OperatingSystem.Android],
                    Screen = new()
                    {
                        MaxHeight = 0,
                        MaxWidth = 0,
                        MinHeight = 0,
                        MinWidth = 0,
                    },
                },
                LogSession = true,
                RecordSession = true,
                SolveCaptchas = true,
                Viewport = new() { Height = 0, Width = 0 },
            },
            ExtensionID = "extensionId",
            KeepAlive = true,
            ProjectID = "projectId",
            Proxies = true,
            Region = Region.UsWest2,
            Timeout = 0,
            UserMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BrowserbaseSessionCreateParams>(element);
        Assert.NotNull(deserialized);

        BrowserSettings expectedBrowserSettings = new()
        {
            AdvancedStealth = true,
            BlockAds = true,
            Context = new() { ID = "id", Persist = true },
            ExtensionID = "extensionId",
            Fingerprint = new()
            {
                Browsers = [FingerprintBrowser.Chrome],
                Devices = [Device.Desktop],
                HTTPVersion = HTTPVersion.V1,
                Locales = ["string"],
                OperatingSystems = [OperatingSystem.Android],
                Screen = new()
                {
                    MaxHeight = 0,
                    MaxWidth = 0,
                    MinHeight = 0,
                    MinWidth = 0,
                },
            },
            LogSession = true,
            RecordSession = true,
            SolveCaptchas = true,
            Viewport = new() { Height = 0, Width = 0 },
        };
        string expectedExtensionID = "extensionId";
        bool expectedKeepAlive = true;
        string expectedProjectID = "projectId";
        Proxies expectedProxies = true;
        ApiEnum<string, Region> expectedRegion = Region.UsWest2;
        double expectedTimeout = 0;
        Dictionary<string, JsonElement> expectedUserMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedBrowserSettings, deserialized.BrowserSettings);
        Assert.Equal(expectedExtensionID, deserialized.ExtensionID);
        Assert.Equal(expectedKeepAlive, deserialized.KeepAlive);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedProxies, deserialized.Proxies);
        Assert.Equal(expectedRegion, deserialized.Region);
        Assert.Equal(expectedTimeout, deserialized.Timeout);
        Assert.NotNull(deserialized.UserMetadata);
        Assert.Equal(expectedUserMetadata.Count, deserialized.UserMetadata.Count);
        foreach (var item in expectedUserMetadata)
        {
            Assert.True(deserialized.UserMetadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.UserMetadata[item.Key]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrowserbaseSessionCreateParams
        {
            BrowserSettings = new()
            {
                AdvancedStealth = true,
                BlockAds = true,
                Context = new() { ID = "id", Persist = true },
                ExtensionID = "extensionId",
                Fingerprint = new()
                {
                    Browsers = [FingerprintBrowser.Chrome],
                    Devices = [Device.Desktop],
                    HTTPVersion = HTTPVersion.V1,
                    Locales = ["string"],
                    OperatingSystems = [OperatingSystem.Android],
                    Screen = new()
                    {
                        MaxHeight = 0,
                        MaxWidth = 0,
                        MinHeight = 0,
                        MinWidth = 0,
                    },
                },
                LogSession = true,
                RecordSession = true,
                SolveCaptchas = true,
                Viewport = new() { Height = 0, Width = 0 },
            },
            ExtensionID = "extensionId",
            KeepAlive = true,
            ProjectID = "projectId",
            Proxies = true,
            Region = Region.UsWest2,
            Timeout = 0,
            UserMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrowserbaseSessionCreateParams { };

        Assert.Null(model.BrowserSettings);
        Assert.False(model.RawData.ContainsKey("browserSettings"));
        Assert.Null(model.ExtensionID);
        Assert.False(model.RawData.ContainsKey("extensionId"));
        Assert.Null(model.KeepAlive);
        Assert.False(model.RawData.ContainsKey("keepAlive"));
        Assert.Null(model.ProjectID);
        Assert.False(model.RawData.ContainsKey("projectId"));
        Assert.Null(model.Proxies);
        Assert.False(model.RawData.ContainsKey("proxies"));
        Assert.Null(model.Region);
        Assert.False(model.RawData.ContainsKey("region"));
        Assert.Null(model.Timeout);
        Assert.False(model.RawData.ContainsKey("timeout"));
        Assert.Null(model.UserMetadata);
        Assert.False(model.RawData.ContainsKey("userMetadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrowserbaseSessionCreateParams { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BrowserbaseSessionCreateParams
        {
            // Null should be interpreted as omitted for these properties
            BrowserSettings = null,
            ExtensionID = null,
            KeepAlive = null,
            ProjectID = null,
            Proxies = null,
            Region = null,
            Timeout = null,
            UserMetadata = null,
        };

        Assert.Null(model.BrowserSettings);
        Assert.False(model.RawData.ContainsKey("browserSettings"));
        Assert.Null(model.ExtensionID);
        Assert.False(model.RawData.ContainsKey("extensionId"));
        Assert.Null(model.KeepAlive);
        Assert.False(model.RawData.ContainsKey("keepAlive"));
        Assert.Null(model.ProjectID);
        Assert.False(model.RawData.ContainsKey("projectId"));
        Assert.Null(model.Proxies);
        Assert.False(model.RawData.ContainsKey("proxies"));
        Assert.Null(model.Region);
        Assert.False(model.RawData.ContainsKey("region"));
        Assert.Null(model.Timeout);
        Assert.False(model.RawData.ContainsKey("timeout"));
        Assert.Null(model.UserMetadata);
        Assert.False(model.RawData.ContainsKey("userMetadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrowserbaseSessionCreateParams
        {
            // Null should be interpreted as omitted for these properties
            BrowserSettings = null,
            ExtensionID = null,
            KeepAlive = null,
            ProjectID = null,
            Proxies = null,
            Region = null,
            Timeout = null,
            UserMetadata = null,
        };

        model.Validate();
    }
}

public class BrowserSettingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrowserSettings
        {
            AdvancedStealth = true,
            BlockAds = true,
            Context = new() { ID = "id", Persist = true },
            ExtensionID = "extensionId",
            Fingerprint = new()
            {
                Browsers = [FingerprintBrowser.Chrome],
                Devices = [Device.Desktop],
                HTTPVersion = HTTPVersion.V1,
                Locales = ["string"],
                OperatingSystems = [OperatingSystem.Android],
                Screen = new()
                {
                    MaxHeight = 0,
                    MaxWidth = 0,
                    MinHeight = 0,
                    MinWidth = 0,
                },
            },
            LogSession = true,
            RecordSession = true,
            SolveCaptchas = true,
            Viewport = new() { Height = 0, Width = 0 },
        };

        bool expectedAdvancedStealth = true;
        bool expectedBlockAds = true;
        Context expectedContext = new() { ID = "id", Persist = true };
        string expectedExtensionID = "extensionId";
        Fingerprint expectedFingerprint = new()
        {
            Browsers = [FingerprintBrowser.Chrome],
            Devices = [Device.Desktop],
            HTTPVersion = HTTPVersion.V1,
            Locales = ["string"],
            OperatingSystems = [OperatingSystem.Android],
            Screen = new()
            {
                MaxHeight = 0,
                MaxWidth = 0,
                MinHeight = 0,
                MinWidth = 0,
            },
        };
        bool expectedLogSession = true;
        bool expectedRecordSession = true;
        bool expectedSolveCaptchas = true;
        BrowserSettingsViewport expectedViewport = new() { Height = 0, Width = 0 };

        Assert.Equal(expectedAdvancedStealth, model.AdvancedStealth);
        Assert.Equal(expectedBlockAds, model.BlockAds);
        Assert.Equal(expectedContext, model.Context);
        Assert.Equal(expectedExtensionID, model.ExtensionID);
        Assert.Equal(expectedFingerprint, model.Fingerprint);
        Assert.Equal(expectedLogSession, model.LogSession);
        Assert.Equal(expectedRecordSession, model.RecordSession);
        Assert.Equal(expectedSolveCaptchas, model.SolveCaptchas);
        Assert.Equal(expectedViewport, model.Viewport);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrowserSettings
        {
            AdvancedStealth = true,
            BlockAds = true,
            Context = new() { ID = "id", Persist = true },
            ExtensionID = "extensionId",
            Fingerprint = new()
            {
                Browsers = [FingerprintBrowser.Chrome],
                Devices = [Device.Desktop],
                HTTPVersion = HTTPVersion.V1,
                Locales = ["string"],
                OperatingSystems = [OperatingSystem.Android],
                Screen = new()
                {
                    MaxHeight = 0,
                    MaxWidth = 0,
                    MinHeight = 0,
                    MinWidth = 0,
                },
            },
            LogSession = true,
            RecordSession = true,
            SolveCaptchas = true,
            Viewport = new() { Height = 0, Width = 0 },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BrowserSettings>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrowserSettings
        {
            AdvancedStealth = true,
            BlockAds = true,
            Context = new() { ID = "id", Persist = true },
            ExtensionID = "extensionId",
            Fingerprint = new()
            {
                Browsers = [FingerprintBrowser.Chrome],
                Devices = [Device.Desktop],
                HTTPVersion = HTTPVersion.V1,
                Locales = ["string"],
                OperatingSystems = [OperatingSystem.Android],
                Screen = new()
                {
                    MaxHeight = 0,
                    MaxWidth = 0,
                    MinHeight = 0,
                    MinWidth = 0,
                },
            },
            LogSession = true,
            RecordSession = true,
            SolveCaptchas = true,
            Viewport = new() { Height = 0, Width = 0 },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BrowserSettings>(element);
        Assert.NotNull(deserialized);

        bool expectedAdvancedStealth = true;
        bool expectedBlockAds = true;
        Context expectedContext = new() { ID = "id", Persist = true };
        string expectedExtensionID = "extensionId";
        Fingerprint expectedFingerprint = new()
        {
            Browsers = [FingerprintBrowser.Chrome],
            Devices = [Device.Desktop],
            HTTPVersion = HTTPVersion.V1,
            Locales = ["string"],
            OperatingSystems = [OperatingSystem.Android],
            Screen = new()
            {
                MaxHeight = 0,
                MaxWidth = 0,
                MinHeight = 0,
                MinWidth = 0,
            },
        };
        bool expectedLogSession = true;
        bool expectedRecordSession = true;
        bool expectedSolveCaptchas = true;
        BrowserSettingsViewport expectedViewport = new() { Height = 0, Width = 0 };

        Assert.Equal(expectedAdvancedStealth, deserialized.AdvancedStealth);
        Assert.Equal(expectedBlockAds, deserialized.BlockAds);
        Assert.Equal(expectedContext, deserialized.Context);
        Assert.Equal(expectedExtensionID, deserialized.ExtensionID);
        Assert.Equal(expectedFingerprint, deserialized.Fingerprint);
        Assert.Equal(expectedLogSession, deserialized.LogSession);
        Assert.Equal(expectedRecordSession, deserialized.RecordSession);
        Assert.Equal(expectedSolveCaptchas, deserialized.SolveCaptchas);
        Assert.Equal(expectedViewport, deserialized.Viewport);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrowserSettings
        {
            AdvancedStealth = true,
            BlockAds = true,
            Context = new() { ID = "id", Persist = true },
            ExtensionID = "extensionId",
            Fingerprint = new()
            {
                Browsers = [FingerprintBrowser.Chrome],
                Devices = [Device.Desktop],
                HTTPVersion = HTTPVersion.V1,
                Locales = ["string"],
                OperatingSystems = [OperatingSystem.Android],
                Screen = new()
                {
                    MaxHeight = 0,
                    MaxWidth = 0,
                    MinHeight = 0,
                    MinWidth = 0,
                },
            },
            LogSession = true,
            RecordSession = true,
            SolveCaptchas = true,
            Viewport = new() { Height = 0, Width = 0 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrowserSettings { };

        Assert.Null(model.AdvancedStealth);
        Assert.False(model.RawData.ContainsKey("advancedStealth"));
        Assert.Null(model.BlockAds);
        Assert.False(model.RawData.ContainsKey("blockAds"));
        Assert.Null(model.Context);
        Assert.False(model.RawData.ContainsKey("context"));
        Assert.Null(model.ExtensionID);
        Assert.False(model.RawData.ContainsKey("extensionId"));
        Assert.Null(model.Fingerprint);
        Assert.False(model.RawData.ContainsKey("fingerprint"));
        Assert.Null(model.LogSession);
        Assert.False(model.RawData.ContainsKey("logSession"));
        Assert.Null(model.RecordSession);
        Assert.False(model.RawData.ContainsKey("recordSession"));
        Assert.Null(model.SolveCaptchas);
        Assert.False(model.RawData.ContainsKey("solveCaptchas"));
        Assert.Null(model.Viewport);
        Assert.False(model.RawData.ContainsKey("viewport"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrowserSettings { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BrowserSettings
        {
            // Null should be interpreted as omitted for these properties
            AdvancedStealth = null,
            BlockAds = null,
            Context = null,
            ExtensionID = null,
            Fingerprint = null,
            LogSession = null,
            RecordSession = null,
            SolveCaptchas = null,
            Viewport = null,
        };

        Assert.Null(model.AdvancedStealth);
        Assert.False(model.RawData.ContainsKey("advancedStealth"));
        Assert.Null(model.BlockAds);
        Assert.False(model.RawData.ContainsKey("blockAds"));
        Assert.Null(model.Context);
        Assert.False(model.RawData.ContainsKey("context"));
        Assert.Null(model.ExtensionID);
        Assert.False(model.RawData.ContainsKey("extensionId"));
        Assert.Null(model.Fingerprint);
        Assert.False(model.RawData.ContainsKey("fingerprint"));
        Assert.Null(model.LogSession);
        Assert.False(model.RawData.ContainsKey("logSession"));
        Assert.Null(model.RecordSession);
        Assert.False(model.RawData.ContainsKey("recordSession"));
        Assert.Null(model.SolveCaptchas);
        Assert.False(model.RawData.ContainsKey("solveCaptchas"));
        Assert.Null(model.Viewport);
        Assert.False(model.RawData.ContainsKey("viewport"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrowserSettings
        {
            // Null should be interpreted as omitted for these properties
            AdvancedStealth = null,
            BlockAds = null,
            Context = null,
            ExtensionID = null,
            Fingerprint = null,
            LogSession = null,
            RecordSession = null,
            SolveCaptchas = null,
            Viewport = null,
        };

        model.Validate();
    }
}

public class ContextTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Context { ID = "id", Persist = true };

        string expectedID = "id";
        bool expectedPersist = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedPersist, model.Persist);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Context { ID = "id", Persist = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Context>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Context { ID = "id", Persist = true };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Context>(element);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        bool expectedPersist = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedPersist, deserialized.Persist);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Context { ID = "id", Persist = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Context { ID = "id" };

        Assert.Null(model.Persist);
        Assert.False(model.RawData.ContainsKey("persist"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Context { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Context
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Persist = null,
        };

        Assert.Null(model.Persist);
        Assert.False(model.RawData.ContainsKey("persist"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Context
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Persist = null,
        };

        model.Validate();
    }
}

public class FingerprintTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Fingerprint
        {
            Browsers = [FingerprintBrowser.Chrome],
            Devices = [Device.Desktop],
            HTTPVersion = HTTPVersion.V1,
            Locales = ["string"],
            OperatingSystems = [OperatingSystem.Android],
            Screen = new()
            {
                MaxHeight = 0,
                MaxWidth = 0,
                MinHeight = 0,
                MinWidth = 0,
            },
        };

        List<ApiEnum<string, FingerprintBrowser>> expectedBrowsers = [FingerprintBrowser.Chrome];
        List<ApiEnum<string, Device>> expectedDevices = [Device.Desktop];
        ApiEnum<string, HTTPVersion> expectedHTTPVersion = HTTPVersion.V1;
        List<string> expectedLocales = ["string"];
        List<ApiEnum<string, OperatingSystem>> expectedOperatingSystems = [OperatingSystem.Android];
        Screen expectedScreen = new()
        {
            MaxHeight = 0,
            MaxWidth = 0,
            MinHeight = 0,
            MinWidth = 0,
        };

        Assert.NotNull(model.Browsers);
        Assert.Equal(expectedBrowsers.Count, model.Browsers.Count);
        for (int i = 0; i < expectedBrowsers.Count; i++)
        {
            Assert.Equal(expectedBrowsers[i], model.Browsers[i]);
        }
        Assert.NotNull(model.Devices);
        Assert.Equal(expectedDevices.Count, model.Devices.Count);
        for (int i = 0; i < expectedDevices.Count; i++)
        {
            Assert.Equal(expectedDevices[i], model.Devices[i]);
        }
        Assert.Equal(expectedHTTPVersion, model.HTTPVersion);
        Assert.NotNull(model.Locales);
        Assert.Equal(expectedLocales.Count, model.Locales.Count);
        for (int i = 0; i < expectedLocales.Count; i++)
        {
            Assert.Equal(expectedLocales[i], model.Locales[i]);
        }
        Assert.NotNull(model.OperatingSystems);
        Assert.Equal(expectedOperatingSystems.Count, model.OperatingSystems.Count);
        for (int i = 0; i < expectedOperatingSystems.Count; i++)
        {
            Assert.Equal(expectedOperatingSystems[i], model.OperatingSystems[i]);
        }
        Assert.Equal(expectedScreen, model.Screen);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Fingerprint
        {
            Browsers = [FingerprintBrowser.Chrome],
            Devices = [Device.Desktop],
            HTTPVersion = HTTPVersion.V1,
            Locales = ["string"],
            OperatingSystems = [OperatingSystem.Android],
            Screen = new()
            {
                MaxHeight = 0,
                MaxWidth = 0,
                MinHeight = 0,
                MinWidth = 0,
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Fingerprint>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Fingerprint
        {
            Browsers = [FingerprintBrowser.Chrome],
            Devices = [Device.Desktop],
            HTTPVersion = HTTPVersion.V1,
            Locales = ["string"],
            OperatingSystems = [OperatingSystem.Android],
            Screen = new()
            {
                MaxHeight = 0,
                MaxWidth = 0,
                MinHeight = 0,
                MinWidth = 0,
            },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Fingerprint>(element);
        Assert.NotNull(deserialized);

        List<ApiEnum<string, FingerprintBrowser>> expectedBrowsers = [FingerprintBrowser.Chrome];
        List<ApiEnum<string, Device>> expectedDevices = [Device.Desktop];
        ApiEnum<string, HTTPVersion> expectedHTTPVersion = HTTPVersion.V1;
        List<string> expectedLocales = ["string"];
        List<ApiEnum<string, OperatingSystem>> expectedOperatingSystems = [OperatingSystem.Android];
        Screen expectedScreen = new()
        {
            MaxHeight = 0,
            MaxWidth = 0,
            MinHeight = 0,
            MinWidth = 0,
        };

        Assert.NotNull(deserialized.Browsers);
        Assert.Equal(expectedBrowsers.Count, deserialized.Browsers.Count);
        for (int i = 0; i < expectedBrowsers.Count; i++)
        {
            Assert.Equal(expectedBrowsers[i], deserialized.Browsers[i]);
        }
        Assert.NotNull(deserialized.Devices);
        Assert.Equal(expectedDevices.Count, deserialized.Devices.Count);
        for (int i = 0; i < expectedDevices.Count; i++)
        {
            Assert.Equal(expectedDevices[i], deserialized.Devices[i]);
        }
        Assert.Equal(expectedHTTPVersion, deserialized.HTTPVersion);
        Assert.NotNull(deserialized.Locales);
        Assert.Equal(expectedLocales.Count, deserialized.Locales.Count);
        for (int i = 0; i < expectedLocales.Count; i++)
        {
            Assert.Equal(expectedLocales[i], deserialized.Locales[i]);
        }
        Assert.NotNull(deserialized.OperatingSystems);
        Assert.Equal(expectedOperatingSystems.Count, deserialized.OperatingSystems.Count);
        for (int i = 0; i < expectedOperatingSystems.Count; i++)
        {
            Assert.Equal(expectedOperatingSystems[i], deserialized.OperatingSystems[i]);
        }
        Assert.Equal(expectedScreen, deserialized.Screen);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Fingerprint
        {
            Browsers = [FingerprintBrowser.Chrome],
            Devices = [Device.Desktop],
            HTTPVersion = HTTPVersion.V1,
            Locales = ["string"],
            OperatingSystems = [OperatingSystem.Android],
            Screen = new()
            {
                MaxHeight = 0,
                MaxWidth = 0,
                MinHeight = 0,
                MinWidth = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Fingerprint { };

        Assert.Null(model.Browsers);
        Assert.False(model.RawData.ContainsKey("browsers"));
        Assert.Null(model.Devices);
        Assert.False(model.RawData.ContainsKey("devices"));
        Assert.Null(model.HTTPVersion);
        Assert.False(model.RawData.ContainsKey("httpVersion"));
        Assert.Null(model.Locales);
        Assert.False(model.RawData.ContainsKey("locales"));
        Assert.Null(model.OperatingSystems);
        Assert.False(model.RawData.ContainsKey("operatingSystems"));
        Assert.Null(model.Screen);
        Assert.False(model.RawData.ContainsKey("screen"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Fingerprint { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Fingerprint
        {
            // Null should be interpreted as omitted for these properties
            Browsers = null,
            Devices = null,
            HTTPVersion = null,
            Locales = null,
            OperatingSystems = null,
            Screen = null,
        };

        Assert.Null(model.Browsers);
        Assert.False(model.RawData.ContainsKey("browsers"));
        Assert.Null(model.Devices);
        Assert.False(model.RawData.ContainsKey("devices"));
        Assert.Null(model.HTTPVersion);
        Assert.False(model.RawData.ContainsKey("httpVersion"));
        Assert.Null(model.Locales);
        Assert.False(model.RawData.ContainsKey("locales"));
        Assert.Null(model.OperatingSystems);
        Assert.False(model.RawData.ContainsKey("operatingSystems"));
        Assert.Null(model.Screen);
        Assert.False(model.RawData.ContainsKey("screen"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Fingerprint
        {
            // Null should be interpreted as omitted for these properties
            Browsers = null,
            Devices = null,
            HTTPVersion = null,
            Locales = null,
            OperatingSystems = null,
            Screen = null,
        };

        model.Validate();
    }
}

public class FingerprintBrowserTest : TestBase
{
    [Theory]
    [InlineData(FingerprintBrowser.Chrome)]
    [InlineData(FingerprintBrowser.Edge)]
    [InlineData(FingerprintBrowser.Firefox)]
    [InlineData(FingerprintBrowser.Safari)]
    public void Validation_Works(FingerprintBrowser rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FingerprintBrowser> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FingerprintBrowser>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FingerprintBrowser.Chrome)]
    [InlineData(FingerprintBrowser.Edge)]
    [InlineData(FingerprintBrowser.Firefox)]
    [InlineData(FingerprintBrowser.Safari)]
    public void SerializationRoundtrip_Works(FingerprintBrowser rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FingerprintBrowser> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FingerprintBrowser>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FingerprintBrowser>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FingerprintBrowser>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DeviceTest : TestBase
{
    [Theory]
    [InlineData(Device.Desktop)]
    [InlineData(Device.Mobile)]
    public void Validation_Works(Device rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Device> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Device>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Device.Desktop)]
    [InlineData(Device.Mobile)]
    public void SerializationRoundtrip_Works(Device rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Device> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Device>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Device>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Device>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class HTTPVersionTest : TestBase
{
    [Theory]
    [InlineData(HTTPVersion.V1)]
    [InlineData(HTTPVersion.V2)]
    public void Validation_Works(HTTPVersion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, HTTPVersion> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, HTTPVersion>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(HTTPVersion.V1)]
    [InlineData(HTTPVersion.V2)]
    public void SerializationRoundtrip_Works(HTTPVersion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, HTTPVersion> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, HTTPVersion>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, HTTPVersion>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, HTTPVersion>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OperatingSystemTest : TestBase
{
    [Theory]
    [InlineData(OperatingSystem.Android)]
    [InlineData(OperatingSystem.Ios)]
    [InlineData(OperatingSystem.Linux)]
    [InlineData(OperatingSystem.Macos)]
    [InlineData(OperatingSystem.Windows)]
    public void Validation_Works(OperatingSystem rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OperatingSystem> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OperatingSystem>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OperatingSystem.Android)]
    [InlineData(OperatingSystem.Ios)]
    [InlineData(OperatingSystem.Linux)]
    [InlineData(OperatingSystem.Macos)]
    [InlineData(OperatingSystem.Windows)]
    public void SerializationRoundtrip_Works(OperatingSystem rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OperatingSystem> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OperatingSystem>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OperatingSystem>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OperatingSystem>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ScreenTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Screen
        {
            MaxHeight = 0,
            MaxWidth = 0,
            MinHeight = 0,
            MinWidth = 0,
        };

        double expectedMaxHeight = 0;
        double expectedMaxWidth = 0;
        double expectedMinHeight = 0;
        double expectedMinWidth = 0;

        Assert.Equal(expectedMaxHeight, model.MaxHeight);
        Assert.Equal(expectedMaxWidth, model.MaxWidth);
        Assert.Equal(expectedMinHeight, model.MinHeight);
        Assert.Equal(expectedMinWidth, model.MinWidth);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Screen
        {
            MaxHeight = 0,
            MaxWidth = 0,
            MinHeight = 0,
            MinWidth = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Screen>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Screen
        {
            MaxHeight = 0,
            MaxWidth = 0,
            MinHeight = 0,
            MinWidth = 0,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Screen>(element);
        Assert.NotNull(deserialized);

        double expectedMaxHeight = 0;
        double expectedMaxWidth = 0;
        double expectedMinHeight = 0;
        double expectedMinWidth = 0;

        Assert.Equal(expectedMaxHeight, deserialized.MaxHeight);
        Assert.Equal(expectedMaxWidth, deserialized.MaxWidth);
        Assert.Equal(expectedMinHeight, deserialized.MinHeight);
        Assert.Equal(expectedMinWidth, deserialized.MinWidth);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Screen
        {
            MaxHeight = 0,
            MaxWidth = 0,
            MinHeight = 0,
            MinWidth = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Screen { };

        Assert.Null(model.MaxHeight);
        Assert.False(model.RawData.ContainsKey("maxHeight"));
        Assert.Null(model.MaxWidth);
        Assert.False(model.RawData.ContainsKey("maxWidth"));
        Assert.Null(model.MinHeight);
        Assert.False(model.RawData.ContainsKey("minHeight"));
        Assert.Null(model.MinWidth);
        Assert.False(model.RawData.ContainsKey("minWidth"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Screen { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Screen
        {
            // Null should be interpreted as omitted for these properties
            MaxHeight = null,
            MaxWidth = null,
            MinHeight = null,
            MinWidth = null,
        };

        Assert.Null(model.MaxHeight);
        Assert.False(model.RawData.ContainsKey("maxHeight"));
        Assert.Null(model.MaxWidth);
        Assert.False(model.RawData.ContainsKey("maxWidth"));
        Assert.Null(model.MinHeight);
        Assert.False(model.RawData.ContainsKey("minHeight"));
        Assert.Null(model.MinWidth);
        Assert.False(model.RawData.ContainsKey("minWidth"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Screen
        {
            // Null should be interpreted as omitted for these properties
            MaxHeight = null,
            MaxWidth = null,
            MinHeight = null,
            MinWidth = null,
        };

        model.Validate();
    }
}

public class BrowserSettingsViewportTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrowserSettingsViewport { Height = 0, Width = 0 };

        double expectedHeight = 0;
        double expectedWidth = 0;

        Assert.Equal(expectedHeight, model.Height);
        Assert.Equal(expectedWidth, model.Width);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrowserSettingsViewport { Height = 0, Width = 0 };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BrowserSettingsViewport>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrowserSettingsViewport { Height = 0, Width = 0 };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BrowserSettingsViewport>(element);
        Assert.NotNull(deserialized);

        double expectedHeight = 0;
        double expectedWidth = 0;

        Assert.Equal(expectedHeight, deserialized.Height);
        Assert.Equal(expectedWidth, deserialized.Width);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrowserSettingsViewport { Height = 0, Width = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrowserSettingsViewport { };

        Assert.Null(model.Height);
        Assert.False(model.RawData.ContainsKey("height"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrowserSettingsViewport { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BrowserSettingsViewport
        {
            // Null should be interpreted as omitted for these properties
            Height = null,
            Width = null,
        };

        Assert.Null(model.Height);
        Assert.False(model.RawData.ContainsKey("height"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrowserSettingsViewport
        {
            // Null should be interpreted as omitted for these properties
            Height = null,
            Width = null,
        };

        model.Validate();
    }
}

public class ProxiesTest : TestBase
{
    [Fact]
    public void BoolValidationWorks()
    {
        Proxies value = new(true);
        value.Validate();
    }

    [Fact]
    public void ProxyConfigListValidationWorks()
    {
        Proxies value = new(
            [
                new ProxyConfig(
                    new Browserbase()
                    {
                        DomainPattern = "domainPattern",
                        Geolocation = new()
                        {
                            Country = "country",
                            City = "city",
                            State = "state",
                        },
                    }
                ),
            ]
        );
        value.Validate();
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        Proxies value = new(true);
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Proxies>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ProxyConfigListSerializationRoundtripWorks()
    {
        Proxies value = new(
            [
                new ProxyConfig(
                    new Browserbase()
                    {
                        DomainPattern = "domainPattern",
                        Geolocation = new()
                        {
                            Country = "country",
                            City = "city",
                            State = "state",
                        },
                    }
                ),
            ]
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Proxies>(element);

        Assert.Equal(value, deserialized);
    }
}

public class ProxyConfigTest : TestBase
{
    [Fact]
    public void BrowserbaseValidationWorks()
    {
        ProxyConfig value = new(
            new Browserbase()
            {
                DomainPattern = "domainPattern",
                Geolocation = new()
                {
                    Country = "country",
                    City = "city",
                    State = "state",
                },
            }
        );
        value.Validate();
    }

    [Fact]
    public void ExternalValidationWorks()
    {
        ProxyConfig value = new(
            new External()
            {
                Server = "server",
                DomainPattern = "domainPattern",
                Password = "password",
                Username = "username",
            }
        );
        value.Validate();
    }

    [Fact]
    public void BrowserbaseSerializationRoundtripWorks()
    {
        ProxyConfig value = new(
            new Browserbase()
            {
                DomainPattern = "domainPattern",
                Geolocation = new()
                {
                    Country = "country",
                    City = "city",
                    State = "state",
                },
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ProxyConfig>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExternalSerializationRoundtripWorks()
    {
        ProxyConfig value = new(
            new External()
            {
                Server = "server",
                DomainPattern = "domainPattern",
                Password = "password",
                Username = "username",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ProxyConfig>(element);

        Assert.Equal(value, deserialized);
    }
}

public class BrowserbaseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Browserbase
        {
            DomainPattern = "domainPattern",
            Geolocation = new()
            {
                Country = "country",
                City = "city",
                State = "state",
            },
        };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"browserbase\"");
        string expectedDomainPattern = "domainPattern";
        Geolocation expectedGeolocation = new()
        {
            Country = "country",
            City = "city",
            State = "state",
        };

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedDomainPattern, model.DomainPattern);
        Assert.Equal(expectedGeolocation, model.Geolocation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Browserbase
        {
            DomainPattern = "domainPattern",
            Geolocation = new()
            {
                Country = "country",
                City = "city",
                State = "state",
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Browserbase>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Browserbase
        {
            DomainPattern = "domainPattern",
            Geolocation = new()
            {
                Country = "country",
                City = "city",
                State = "state",
            },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Browserbase>(element);
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"browserbase\"");
        string expectedDomainPattern = "domainPattern";
        Geolocation expectedGeolocation = new()
        {
            Country = "country",
            City = "city",
            State = "state",
        };

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedDomainPattern, deserialized.DomainPattern);
        Assert.Equal(expectedGeolocation, deserialized.Geolocation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Browserbase
        {
            DomainPattern = "domainPattern",
            Geolocation = new()
            {
                Country = "country",
                City = "city",
                State = "state",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Browserbase { };

        Assert.Null(model.DomainPattern);
        Assert.False(model.RawData.ContainsKey("domainPattern"));
        Assert.Null(model.Geolocation);
        Assert.False(model.RawData.ContainsKey("geolocation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Browserbase { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Browserbase
        {
            // Null should be interpreted as omitted for these properties
            DomainPattern = null,
            Geolocation = null,
        };

        Assert.Null(model.DomainPattern);
        Assert.False(model.RawData.ContainsKey("domainPattern"));
        Assert.Null(model.Geolocation);
        Assert.False(model.RawData.ContainsKey("geolocation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Browserbase
        {
            // Null should be interpreted as omitted for these properties
            DomainPattern = null,
            Geolocation = null,
        };

        model.Validate();
    }
}

public class GeolocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Geolocation
        {
            Country = "country",
            City = "city",
            State = "state",
        };

        string expectedCountry = "country";
        string expectedCity = "city";
        string expectedState = "state";

        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Geolocation
        {
            Country = "country",
            City = "city",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Geolocation>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Geolocation
        {
            Country = "country",
            City = "city",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Geolocation>(element);
        Assert.NotNull(deserialized);

        string expectedCountry = "country";
        string expectedCity = "city";
        string expectedState = "state";

        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Geolocation
        {
            Country = "country",
            City = "city",
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Geolocation { Country = "country" };

        Assert.Null(model.City);
        Assert.False(model.RawData.ContainsKey("city"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Geolocation { Country = "country" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Geolocation
        {
            Country = "country",

            // Null should be interpreted as omitted for these properties
            City = null,
            State = null,
        };

        Assert.Null(model.City);
        Assert.False(model.RawData.ContainsKey("city"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Geolocation
        {
            Country = "country",

            // Null should be interpreted as omitted for these properties
            City = null,
            State = null,
        };

        model.Validate();
    }
}

public class ExternalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new External
        {
            Server = "server",
            DomainPattern = "domainPattern",
            Password = "password",
            Username = "username",
        };

        string expectedServer = "server";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"external\"");
        string expectedDomainPattern = "domainPattern";
        string expectedPassword = "password";
        string expectedUsername = "username";

        Assert.Equal(expectedServer, model.Server);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedDomainPattern, model.DomainPattern);
        Assert.Equal(expectedPassword, model.Password);
        Assert.Equal(expectedUsername, model.Username);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new External
        {
            Server = "server",
            DomainPattern = "domainPattern",
            Password = "password",
            Username = "username",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<External>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new External
        {
            Server = "server",
            DomainPattern = "domainPattern",
            Password = "password",
            Username = "username",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<External>(element);
        Assert.NotNull(deserialized);

        string expectedServer = "server";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"external\"");
        string expectedDomainPattern = "domainPattern";
        string expectedPassword = "password";
        string expectedUsername = "username";

        Assert.Equal(expectedServer, deserialized.Server);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedDomainPattern, deserialized.DomainPattern);
        Assert.Equal(expectedPassword, deserialized.Password);
        Assert.Equal(expectedUsername, deserialized.Username);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new External
        {
            Server = "server",
            DomainPattern = "domainPattern",
            Password = "password",
            Username = "username",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new External { Server = "server" };

        Assert.Null(model.DomainPattern);
        Assert.False(model.RawData.ContainsKey("domainPattern"));
        Assert.Null(model.Password);
        Assert.False(model.RawData.ContainsKey("password"));
        Assert.Null(model.Username);
        Assert.False(model.RawData.ContainsKey("username"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new External { Server = "server" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new External
        {
            Server = "server",

            // Null should be interpreted as omitted for these properties
            DomainPattern = null,
            Password = null,
            Username = null,
        };

        Assert.Null(model.DomainPattern);
        Assert.False(model.RawData.ContainsKey("domainPattern"));
        Assert.Null(model.Password);
        Assert.False(model.RawData.ContainsKey("password"));
        Assert.Null(model.Username);
        Assert.False(model.RawData.ContainsKey("username"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new External
        {
            Server = "server",

            // Null should be interpreted as omitted for these properties
            DomainPattern = null,
            Password = null,
            Username = null,
        };

        model.Validate();
    }
}

public class RegionTest : TestBase
{
    [Theory]
    [InlineData(Region.UsWest2)]
    [InlineData(Region.UsEast1)]
    [InlineData(Region.EuCentral1)]
    [InlineData(Region.ApSoutheast1)]
    public void Validation_Works(Region rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Region> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Region>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Region.UsWest2)]
    [InlineData(Region.UsEast1)]
    [InlineData(Region.EuCentral1)]
    [InlineData(Region.ApSoutheast1)]
    public void SerializationRoundtrip_Works(Region rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Region> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Region>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Region>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Region>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SessionStartParamsXLanguageTest : TestBase
{
    [Theory]
    [InlineData(SessionStartParamsXLanguage.Typescript)]
    [InlineData(SessionStartParamsXLanguage.Python)]
    [InlineData(SessionStartParamsXLanguage.Playground)]
    public void Validation_Works(SessionStartParamsXLanguage rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionStartParamsXLanguage> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SessionStartParamsXLanguage>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SessionStartParamsXLanguage.Typescript)]
    [InlineData(SessionStartParamsXLanguage.Python)]
    [InlineData(SessionStartParamsXLanguage.Playground)]
    public void SerializationRoundtrip_Works(SessionStartParamsXLanguage rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionStartParamsXLanguage> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SessionStartParamsXLanguage>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SessionStartParamsXLanguage>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SessionStartParamsXLanguage>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SessionStartParamsXStreamResponseTest : TestBase
{
    [Theory]
    [InlineData(SessionStartParamsXStreamResponse.True)]
    [InlineData(SessionStartParamsXStreamResponse.False)]
    public void Validation_Works(SessionStartParamsXStreamResponse rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionStartParamsXStreamResponse> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SessionStartParamsXStreamResponse>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SessionStartParamsXStreamResponse.True)]
    [InlineData(SessionStartParamsXStreamResponse.False)]
    public void SerializationRoundtrip_Works(SessionStartParamsXStreamResponse rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionStartParamsXStreamResponse> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionStartParamsXStreamResponse>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SessionStartParamsXStreamResponse>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionStartParamsXStreamResponse>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
