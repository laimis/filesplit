# filesplit

A sample service for parsing text input data. The major components are:

- Record Service - parses input, stores data parsed, returns data sorted by various properties
- Console app - can be used to load data from the console
- Web API - can be used to load and query data over REST API

Implementation uses .NET Core framework. The framework is needed to compile and run the applications. If you don't have .NET Core, you can alternatively use docker. DOCKERFILE is provided at the root directory that will allow you to create the docker image and run the container. Example steps:

1. Pull source
2. Navigate to the root directory in the source
3. Run docker build . -t filesplitimage
4. Run docker run -it -p 5000:5000 filesplitimage

At the end you will be in the /app directory which will contain all the filesplit files and you can run the steps below to build/run console and web apps, as well as execute the tests.


## Building and running console app

1. Pull source
2. Navigate to Filesplit.ConsoleApp
3. Run dotnet restore
4. Run dotnet run {one to many paths to file}

You will need to provide paths to files that contain the data to be loaded. Some sample data files are provided in data directory.

Example run:

  dotnet run ../data/test_file_pipes.txt ../data/test_file_commas.txt ../data/test_file_spaces.txt 

## Building and running web app

1. Pull source
2. Navigate to Filesplit.WebAPI
3. Run dotnet restore
4. Run dotnet run

You will see the localhost URL in the command prompt. You can load some sample data into the API by running a powershell script located in /scripts directory.

To query the records, navigate to /api/records/gender, /api/records/birthdate, /api/records/name endpoints.

## Running tests

1. Pull source
2. Navigate to Filesplit.Services.Tests
3. Run dotnet restore
4. Run dotnet test

You will see xunit style output of the tests. There are also tests for Web API, those can be located in Filesplit.WebAPI.Tests directory. Use the same, dotnet restore / dotnet test sequence to run them after you navigate to that directory.
