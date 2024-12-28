# Multiple DB Changes Tool

**Multiple DB Changes Tool** is a web-based application designed to execute SQL scripts across multiple SQL Server databases simultaneously. This tool is particularly useful for managing changes across several databases in a streamlined and efficient manner.

## Features

1. **Upload SQL Scripts:**
   - Upload `.sql` files containing the scripts you want to execute.
2. **View Uploaded Scripts:**

   - A grid view displays all uploaded SQL script files with their details.
   - Each row includes the following options:
     - **Preview**: View the content of the uploaded script.
     - **Execute**: Navigate to the execution page.
     - **Delete**: Remove the uploaded script file.

3. **Database Selection and Execution:**

   - On the execution page, users can:
     - Provide SQL Server credentials.
     - Test the connection to verify credentials.
     - View a list of available databases with checkboxes for selection.
     - Execute the script across the selected databases.

4. **Parallel Execution:**

   - Uses `Parallel.ForEach` for fast and efficient execution across multiple databases.

5. **Error Handling and Logging:**
   - Ensures robust error handling with appropriate logging mechanisms.

## Technology Stack

- **Framework**: ASP.NET Web Forms (.NET Framework 4.8)
- **Language**: C#
- **Database**: SQL Server
- **Frontend**: HTML, CSS, JavaScript
- **Backend**: ADO.NET for database operations

## Prerequisites

- **Development Environment**: Visual Studio 2019 or higher
- **SQL Server**: Ensure SQL Server is installed and running
- **.NET Framework 4.8**

## Installation

1. **Clone the Repository**

   ```bash
   git clone https://github.com/rahul-sharma-8092/MultipleDBChangesTool.git

   ```

2. **Open the Solution**

   - Launch the solution file in Visual Studio.

3. **Restore NuGet Packages**

   - Restore the required NuGet packages for the project.

4. **Configure Database Connection**
   - Update the `Web.config` file with your SQL Server credentials.
5. **Build and Run**
   - Build the project and run it using Visual Studio.

## Usage

### Uploading SQL Scripts

1. Navigate to the **Upload Script** (`AddScript.aspx`) page.
2. Upload a `.sql` file using the provided upload button.

### Viewing Scripts

1. Once uploaded, you can view the SQL scripts in the grid.
2. The grid provides the following options for each script:
   - **Preview**: View the contents of the script.
   - **Execute**: Run the script.
   - **Delete**: Remove the script from the list.

### Executing Scripts

1. Click the **Execute** button next to the script you want to run.
2. On the new page:
   - Enter your **SQL Server credentials**.
   - Click **Test Connection** to verify the credentials and fetch the list of available databases.
   - Select the databases where you want to execute the script.
   - Click **Execute Script** to run the script across the selected databases.

## Contributing

Contributions are welcome! If you'd like to enhance the tool or fix any issues, feel free to fork the repository and submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](./LICENSE) file for details.

## Acknowledgements

Thanks to the .NET and SQL Server community for their valuable resources.

## Contact Us

We'd love to hear from you! Feel free to connect with us through any of the following channels:

[![](https://img.shields.io/badge/Gmail-contact%20me -- rahulrohanroshan@gmail.com-red?style=flat =gmail)](mailto:rahulrohanroshan@gmail.com) [![](https://img.shields.io/badge/LinkedIn-connect%20with%20me -- @rahul--sharma--giet-blue?style=flat =linkedin)](https://linkedin.com/in/rahul-sharma-giet/) [![](https://img.shields.io/badge/Instagram-follow%20me -- @rahul**_sh_**-blue?style=flat =instagram)](https://instagram.com/rahul___sh___/)

_Stay connected with us for updates and news!_
