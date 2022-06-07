#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Samples.Sagas.ReadFile.Service/Samples.Sagas.ReadFile.Service.csproj", "Samples.Sagas.ReadFile.Service/"]
RUN dotnet restore "Samples.Sagas.ReadFile.Service/Samples.Sagas.ReadFile.Service.csproj"
COPY . .
WORKDIR "/src/Samples.Sagas.ReadFile.Service"
RUN dotnet build "Samples.Sagas.ReadFile.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Samples.Sagas.ReadFile.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Samples.Sagas.ReadFile.Service.dll"]