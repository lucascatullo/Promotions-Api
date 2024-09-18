
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["src/Api/Api.csproj", "./src/Api/"] 
COPY ["src/Application/Application.csproj","./src/Application/"] 
COPY ["src/Entities/Entities.csproj","./src/Entities/"] 

RUN dotnet restore "./src/Api/Api.csproj"

COPY . .

RUN dotnet publish "./src/Api/Api.csproj" -c Release -r linux-x64 -o /app/publish
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "Api.dll"]