
## Getting Started

1) Create the database with Docker:

```bash
docker compose up
```
You can go to localhost:5050 to connect the database. Connection information is in the docker-compose.yml file

2) Update the database with Entity Framework Core Migrations:

```bash
dotnet ef database update
```

3) Run the server:

```bash
dotnet run
```
