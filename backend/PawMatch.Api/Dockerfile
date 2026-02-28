FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["PawMatch.Api.csproj", "./"]
RUN dotnet restore "PawMatch.Api.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "PawMatch.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PawMatch.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "PawMatch.Api.dll"]
