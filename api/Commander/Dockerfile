# base image
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# copy .csproj in current workdir
COPY *.csproj ./
RUN dotnet restore

# copy everithing else
COPY . ./
RUN dotnet publish -c Release -o out

# genereate runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Commander.dll"]
