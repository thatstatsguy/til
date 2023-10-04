FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BlazorPublisher/BlazorPublisher.csproj", "BlazorPublisher/"]
RUN dotnet restore "BlazorPublisher/BlazorPublisher.csproj"
COPY . .
WORKDIR "/src/BlazorPublisher"
RUN dotnet build "BlazorPublisher.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorPublisher.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorPublisher.dll"]
