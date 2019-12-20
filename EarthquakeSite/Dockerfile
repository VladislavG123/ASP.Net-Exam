FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["EarthquakeSite/EarthquakeSite.csproj", "EarthquakeSite/"]
RUN dotnet restore "EarthquakeSite/EarthquakeSite.csproj"
COPY . .
WORKDIR "/src/EarthquakeSite"
RUN dotnet build "EarthquakeSite.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EarthquakeSite.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EarthquakeSite.dll"]