using System.Collections.Generic;
using Stagehand.Core;
using Stagehand.Exceptions;

namespace Stagehand.Tests.Core;

public class MultipartJsonModelTest
{
    [Fact]
    public void GetNotNullClass_WhenPresent_Works()
    {
        var dictionary = new Dictionary<string, MultipartJsonElement>();
        MultipartJsonModel.Set(dictionary, "key", "value");

        var value = MultipartJsonModel.GetNotNullClass<string>(dictionary, "key");

        Assert.Equal("value", value);
    }

    [Fact]
    public void GetNotNullClass_WhenAbsent_Throws()
    {
        var dictionary = new Dictionary<string, MultipartJsonElement>();

        var exception = Assert.Throws<StagehandInvalidDataException>(() =>
            MultipartJsonModel.GetNotNullClass<string>(dictionary, "key")
        );

        Assert.Equal("'key' cannot be absent", exception.Message);
    }

    [Fact]
    public void GetNotNullClass_WhenNull_Throws()
    {
        var dictionary = new Dictionary<string, MultipartJsonElement>();
        MultipartJsonModel.Set<string?>(dictionary, "key", null);

        var exception = Assert.Throws<StagehandInvalidDataException>(() =>
            MultipartJsonModel.GetNotNullClass<string>(dictionary, "key")
        );

        Assert.Equal("'key' cannot be null", exception.Message);
    }

    [Fact]
    public void GetNotNullClass_WhenMismatchedType_Throws()
    {
        var dictionary = new Dictionary<string, MultipartJsonElement>();
        MultipartJsonModel.Set(dictionary, "key", 42);

        var exception = Assert.Throws<StagehandInvalidDataException>(() =>
            MultipartJsonModel.GetNotNullClass<string>(dictionary, "key")
        );

        Assert.Equal("'key' must be of type System.String", exception.Message);
    }

    [Fact]
    public void GetNotNullStruct_WhenPresent_Works()
    {
        var dictionary = new Dictionary<string, MultipartJsonElement>();
        MultipartJsonModel.Set(dictionary, "key", 42);

        var value = MultipartJsonModel.GetNotNullStruct<int>(dictionary, "key");

        Assert.Equal(42, value);
    }

    [Fact]
    public void GetNotNullStruct_WhenAbsent_Throws()
    {
        var dictionary = new Dictionary<string, MultipartJsonElement>();

        var exception = Assert.Throws<StagehandInvalidDataException>(() =>
            MultipartJsonModel.GetNotNullStruct<int>(dictionary, "key")
        );

        Assert.Equal("'key' cannot be absent", exception.Message);
    }

    [Fact]
    public void GetNotNullStruct_WhenNull_Throws()
    {
        var dictionary = new Dictionary<string, MultipartJsonElement>();
        MultipartJsonModel.Set<int?>(dictionary, "key", null);

        var exception = Assert.Throws<StagehandInvalidDataException>(() =>
            MultipartJsonModel.GetNotNullStruct<int>(dictionary, "key")
        );

        Assert.Equal("'key' cannot be null", exception.Message);
    }

    [Fact]
    public void GetNotNullStruct_WhenMismatchedType_Throws()
    {
        var dictionary = new Dictionary<string, MultipartJsonElement>();
        MultipartJsonModel.Set(dictionary, "key", "value");

        var exception = Assert.Throws<StagehandInvalidDataException>(() =>
            MultipartJsonModel.GetNotNullStruct<int>(dictionary, "key")
        );

        Assert.Equal("'key' must be of type System.Int32", exception.Message);
    }

    [Fact]
    public void GetNullableClass_WhenPresent_Works()
    {
        var dictionary = new Dictionary<string, MultipartJsonElement>();
        MultipartJsonModel.Set(dictionary, "key", "value");

        var value = MultipartJsonModel.GetNullableClass<string>(dictionary, "key");

        Assert.Equal("value", value);
    }

    [Fact]
    public void GetNullableClass_WhenAbsent_ReturnsNull()
    {
        var dictionary = new Dictionary<string, MultipartJsonElement>();

        var value = MultipartJsonModel.GetNullableClass<string>(dictionary, "key");

        Assert.Null(value);
    }

    [Fact]
    public void GetNullableClass_WhenNull_ReturnsNull()
    {
        var dictionary = new Dictionary<string, MultipartJsonElement>();
        MultipartJsonModel.Set<string?>(dictionary, "key", null);

        var value = MultipartJsonModel.GetNullableClass<string>(dictionary, "key");

        Assert.Null(value);
    }

    [Fact]
    public void GetNullableClass_WhenMismatchedType_Throws()
    {
        var dictionary = new Dictionary<string, MultipartJsonElement>();
        MultipartJsonModel.Set(dictionary, "key", 42);

        var exception = Assert.Throws<StagehandInvalidDataException>(() =>
            MultipartJsonModel.GetNullableClass<string>(dictionary, "key")
        );

        Assert.Equal("'key' must be of type System.String", exception.Message);
    }

    [Fact]
    public void GetNullableStruct_WhenPresent_Works()
    {
        var dictionary = new Dictionary<string, MultipartJsonElement>();
        MultipartJsonModel.Set(dictionary, "key", 42);

        var value = MultipartJsonModel.GetNullableStruct<int>(dictionary, "key");

        Assert.Equal(42, value);
    }

    [Fact]
    public void GetNullableStruct_WhenAbsent_ReturnsNull()
    {
        var dictionary = new Dictionary<string, MultipartJsonElement>();

        var value = MultipartJsonModel.GetNullableStruct<int>(dictionary, "key");

        Assert.Null(value);
    }

    [Fact]
    public void GetNullableStruct_WhenNull_ReturnsNull()
    {
        var dictionary = new Dictionary<string, MultipartJsonElement>();
        MultipartJsonModel.Set<int?>(dictionary, "key", null);

        var value = MultipartJsonModel.GetNullableStruct<int>(dictionary, "key");

        Assert.Null(value);
    }

    [Fact]
    public void GetNullableStruct_WhenMismatchedType_Throws()
    {
        var dictionary = new Dictionary<string, MultipartJsonElement>();
        MultipartJsonModel.Set(dictionary, "key", "value");

        var exception = Assert.Throws<StagehandInvalidDataException>(() =>
            MultipartJsonModel.GetNullableStruct<int>(dictionary, "key")
        );

        Assert.Equal("'key' must be of type System.Int32", exception.Message);
    }
}
