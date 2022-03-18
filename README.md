# BlogEngine

BlogEngine is a DotNet Application for create or modify posts.

## Usage

Tools:

- Visual Studio 2022 (VStudio2022)
- SQL Server

Stack:

- C#
- Net 6.0
- CQRS
- Microservices

For Migrations to Database:
- In VStudio2022 go to: Tools --> Nuget Package Manager --> Package Manager Console
- Select the "Default project": Persistence.Database
- Write: add-migration [name_migration]
- Finally: update-database

# returns 'words'
foobar.pluralize('word')

# returns 'geese'
foobar.pluralize('goose')

# returns 'phenomenon'
foobar.singularize('phenomena')
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
