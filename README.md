# filesplit

A sample service for parsing text input data. The major components are:

- Record Service - parses input, stores data parsed, returns data sorted by various properties
- Console app - can be used to load data from the console
- Web API - can be used to load and query data over REST API

Implementation uses .NET Core framework. The framework is needed to compile and run the applications.

## Building and running console app

1. Pull source
2. Navigate to Filesplit.ConsoleApp
3. Run dotnet restore
4. Run dotnet run {one to many paths to file}

You will need to provide paths to files that contain the data to be loaded. Some sample data files are provided in data directory.

## Building and running web app

1. Pull source
2. Navigate to Filesplit.WebAPI
3. Run dotnet restore
4. Run dotnet run

You will see the localhost URL in the command prompt. You can load some sample data into the API by running a powershell script located in /scripts directory.

To query the records, navigate to /api/records/gender, /api/records/birthdate, /api/records/name endpoints.
