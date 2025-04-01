# Dotnet Sandbox

## About

![about](images/image.png)

## Running

```sh
dotnet build
# install template
dotnet new install .
dotnet run
# or specific test number if you already know index:
dotnet run 7
```

## Adding new tests

Add new `ISandboxTest`  implementations to `./Tests/` directory.

For ease of use, the template provided can be used:

```sh
dotnet new testclass -n NewTest
```

or for async tests:

```sh
dotnet new testclass -n NewTest --async
```
