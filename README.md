# WindowsUWP
## Team members

Xander Berkein, Alexander Van Damme and Ruben Vermeulen

## Setup for first use

1. Open unzipped project in Visual Studio
2. Build OpendeurdagApp
3. Build OpendeurdagService
4. In Solution Explorer: right click **on Solution 'Opendeurdag' (2 projects)**
5. Select Properties
6. In Common Properties > Startup Project: Select **Multiple startup projects**
7. Select **Start** for *OpendeurdagApp* and *OpendeurdagService*
8. Click OK and close properties
9. Run Project (by clicking **Start**)

## Login

To log in, use following credentials:
- Username: xander@hogent.be  *OR*  ruben@hogent.be
- Password: Password123!

## Database setup

Open Package Manager Console (Tools -> NuGet Package Manager -> Package Manager Console)

Execute following commands:

```
Update-Database
```

After the commands are executed you're all set up.
