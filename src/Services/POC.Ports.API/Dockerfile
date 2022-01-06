#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 8001
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Services/POC.Ports.OrderAPI/POC.Ports.OrderAPI.csproj", "src/Services/POC.Ports.OrderAPI/"]
RUN dotnet restore "src/Services/POC.Ports.OrderAPI/POC.Ports.OrderAPI.csproj"
COPY . .
WORKDIR "/src/src/Services/POC.Ports.OrderAPI"
RUN dotnet build "POC.Ports.OrderAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "POC.Ports.OrderAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "POC.Ports.OrderAPI.dll"]