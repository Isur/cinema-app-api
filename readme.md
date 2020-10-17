# Requirements
- .NET 3.1
- postgresql 13
- docker & docker-compose
- ssl certificate

# .NET App
Go to the folder
```
./src/
```
To load dependencies
```
dotnet restore
```
To run tests:
```
dotnet test
```
To run app:
```
dotnet run --project cinema-app-api
```
# Database/nginx/pgadmin
Prepare ssl certficate and put `localhost.crt` and `localhost.key` here:
```
./nginx/ssl/
```
In root folder run
```
docker-compose up --build
```
To scale app use
```
docker-compose up --scale cinema-app-api=4 --build
```
