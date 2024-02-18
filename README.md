# VERTICAL SLIDE API
This project has been prepared using the Vertical Slide Architecture. It includes an API that manages Brand and Instrument entities.
Its main purpose is to provide an interface for adding, updating, and deleting brand and instrument information.

## `Tech Stack`
- .NET Core 7
- PostgreSQL
- MediatR
- Carter
- Entity Framework
- Fluent Validation

## `Endpoints`
1. **GET /brands:** Retrieves all brands.
2. **GET /instruments:** Retrieves all instruments.
3. **POST /brands:** Adds brand information.
4. **POST /instruments:** Adds instrument information.
5. **POST /brand/{id}:** Updates a specific brand.
6. **POST /instrument/{id}:** Updates a specific instrument.
7. **POST /brand/{id}:** Deletes a specific brand.
8. **POST /instrument/{id}** Deletes a specific instrument.

## `Installation`
1. Clone the project.
   - https://github.com/nejla-kucuk/Vertical-Slide-Api.git
2. Configure your connection settings in the `appsettings.json` file.
3. Run the "start" command from your IDE to launch the project.

## `Contact`
If you have any questions or suggestions, please contact us at nkucuk097@gmail.com.
