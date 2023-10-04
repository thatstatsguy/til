FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BlazorSubscriber/BlazorSubscriber.csproj", "BlazorSubscriber/"]
COPY ["Contracts/Contracts.csproj", "Contracts/"]
RUN dotnet restore "BlazorSubscriber/BlazorSubscriber.csproj"
COPY . .
WORKDIR "/src/BlazorSubscriber"
RUN dotnet build "BlazorSubscriber.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorSubscriber.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorSubscriber.dll"]
