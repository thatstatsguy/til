FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY . /app
RUN dotnet restore

ENTRYPOINT [ "dotnet", "watch", "run", "--urls", "http://*:8080" ]
