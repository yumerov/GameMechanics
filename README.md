# GameMechanics

Collection of game mechanics demos.

## Technical requirement

Dotnet 9

## Sub-projects

- [Common](src/Common/README.md)
- [Loot tables](src/LootTables/README.md)
- [Loot tables - app](src/LootTables.App/README.md)

## How to add new features

1. Create feature project `dotnet new classlib -n <Feature> -o src/<Feature>`
2. Link the project `dotnet sln add src/<Feature>/<Feature>.csproj --solution-folder <Feature>`
3. Link the project to Common `dotnet add src/<Feature>/<Feature>.csproj reference src/Common/Common.csproj`
4. Create the test project `dotnet new xunit -n <Feature>.Tests -o tests/<Feature>.Tests`
5. Link the test project `dotnet sln add tests/<Feature>.Tests/<Feature>.Tests.csproj --solution-folder <Feature>.Tests`

## Quality

Setup GitHub action in `.github/workflows` similar to Common.

To `main.yml` add
```yml
common:
    if: endsWith(needs.detect-commit.outputs.msg, '--common') || endsWith(needs.detect-commit.outputs.msg, '--build')
    uses: ./.github/workflows/common.yml
```

[Todo](TODO.md)