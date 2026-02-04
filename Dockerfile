FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Fit3d.API/Fit3d.API.csproj", "Fit3d.API/"]
COPY ["Fit3d.BLL/Fit3d.BLL.csproj", "Fit3d.BLL/"]
COPY ["FIt3d.DAL/FIt3d.DAL.csproj", "FIt3d.DAL/"]
RUN dotnet restore "Fit3d.API/Fit3d.API.csproj"
COPY . .
WORKDIR "/src/Fit3d.API"
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fit3d.API.dll"]