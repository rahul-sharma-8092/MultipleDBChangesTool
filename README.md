# MultipleDBChangesTool

## Overview

This project is a .NET Framework 4.8 application designed to manage and display script files stored in a database. It includes functionalities to retrieve script file details using a stored procedure and display them in a web application.

## Features

- Retrieve script file details from a database using a stored procedure.
- Display script file details in a web application.
- Error logging and handling.

## Prerequisites

- .NET Framework 4.8
- SQL Server
- Visual Studio

## Installation

1. Clone the repository:
   git clone https://github.com/rahul-sharma-8092/MultipleDBChangesTool.git

2. Open the solution in Visual Studio.
3. Restore NuGet packages.
4. Update the connection string in the `Web.config` file to point to your SQL Server database.

## Configuration

- Ensure the stored procedure `GetAllScriptFile` exists in your SQL Server database and returns the expected columns: `ID`, `Name`, `PhySicalPath`, `ServerPath`, `Query`, and `CreatedAT`.

## Usage

1. Build the solution in Visual Studio.
2. Run the application.
3. Navigate to the appropriate page to view the list of script files.

## Troubleshooting

### Debugging Steps

1. Set breakpoints in the `GetAllScriptFile` method in the `DAL.ScriptsSQL` class.
2. Run the application in debug mode.
3. Inspect the values returned by the `SqlDataReader` to ensure all expected columns are present.

## Contributing

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Make your changes.
4. Commit your changes (`git commit -am 'Add new feature'`).
5. Push to the branch (`git push origin feature-branch`).
6. Create a new Pull Request.

## License

This project is licensed under the MIT License. See the `LICENSE` file for more details.

## Contact

For any questions or issues, please contact [rahulrohanroshan@gmail.com].
