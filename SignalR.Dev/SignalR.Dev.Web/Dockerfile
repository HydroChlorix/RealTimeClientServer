FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["SignalR.Dev.Web/SignalR.Dev.Web.csproj", "SignalR.Dev.Web/"]
RUN dotnet restore "SignalR.Dev.Web/SignalR.Dev.Web.csproj"
COPY . .
WORKDIR "/src/SignalR.Dev.Web"
RUN dotnet build "SignalR.Dev.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SignalR.Dev.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SignalR.Dev.Web.dll"]