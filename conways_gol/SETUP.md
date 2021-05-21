# Game of Life

Game of Life is my chosen quorum piece for phase 1 of the MYOB FMA Program.

## Installation

git clone this repo into your local environment.

```bash
git clone ____
```

## Usage

```cs
# To run the tests
dotnet test --filter Category==NotThreadSafe # Run not thread safe tests
dotnet test --filter Category!=NotThreadSafe # Run thread safe tests

dotnet run --project Game-Of-Life/Game-Of-Life.csproj console # Run with console input

dotnet run --project Game-Of-Life/Game-Of-Life.csproj file <file_name.txt> # Run from file
```

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License

I will learn about licenses someday
