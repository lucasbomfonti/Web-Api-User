FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ApiUsuarios1/ApiUsuarios1.csproj ApiUsuarios1/
RUN dotnet restore ApiUsuarios1/ApiUsuarios1.csproj
COPY . .
WORKDIR /src/ApiUsuarios1
RUN dotnet build ApiUsuarios1.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ApiUsuarios1.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ApiUsuarios1.dll"]
