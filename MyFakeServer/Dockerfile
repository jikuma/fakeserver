#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MyFakeServer/MyFakeServer.csproj", "MyFakeServer/"]
RUN dotnet restore "MyFakeServer/MyFakeServer.csproj"
COPY . .
WORKDIR "/src/MyFakeServer"
RUN dotnet build "MyFakeServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyFakeServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyFakeServer.dll"]