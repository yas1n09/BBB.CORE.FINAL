# BBB.CORE.FINAL Project

## About the Project

BBB.CORE.FINAL is a .NET Core 8-based library and API layer for BigBlueButton. This project is designed to simplify interaction with BigBlueButton and streamline integration processes.

## Project Structure

The project consists of the following main components:

- **BBB.CORE.FINAL.API**: API layer for communication with BigBlueButton.
- **BBB.CORE.FINAL.Library**: Library containing essential functions for BigBlueButton integration.
- **.gitattributes**: File defining Git attributes.
- **.gitignore**: File specifying files and directories to be ignored by Git.
- **BBB.CORE.FINAL.sln**: Visual Studio solution file.

## Installation

To run the project on your local environment, follow these steps:

1. **Clone the Repository**:

   ```bash
   git clone https://github.com/yas1n09/BBB.CORE.FINAL.git
   ```

2. **Open the Solution**:

   Open the `BBB.CORE.FINAL.sln` file using Visual Studio or a compatible IDE.

3. **Install Required Dependencies**:

   Manage the NuGet packages in the project and install any missing dependencies.

4. **Configure BigBlueButton Connection Settings**:

   Update the `appsettings.json` file with your BigBlueButton server details:

   ```json
   {
     "BigBlueButton": {
       "BaseUrl": "https://your-bbb-server.com/bigbluebutton/",
       "SecretKey": "your-secret-key"
     }
   }
   ```

5. **Run the Application**:

   Start the project via your chosen IDE or use the following command:

   ```bash
   dotnet run --project BBB.CORE.FINAL.API
   ```

## API Usage

The API provides endpoints for interacting with BigBlueButton:

- **Create a meeting** (`POST /api/meetings/create`)
- **Get meeting details** (`GET /api/meetings/{meetingId}`)
- **End a meeting** (`POST /api/meetings/end`)
- **Add a user to a meeting** (`POST /api/meetings/add-user`)

For more details, refer to the Swagger documentation:

```
https://localhost:5001/swagger/index.html
```

## Contributing

If you would like to contribute, please open an `issue` first to discuss the changes you want to make. For major changes, create an issue to explain what you intend to modify and why.

1. Fork the repository.
2. Create your branch (`feature/FeatureName`).
3. Make your changes and commit them.
4. Push to your branch.
5. Open a `pull request`.

## License

This project does not currently contain any license information. To add a license, please include an appropriate license file in the root directory of your project.

## Contact

For any questions or suggestions, please contact the project owner via GitHub.

