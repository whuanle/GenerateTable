FROM microsoft/dotnet:2.2-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY GenerateTableConsole.csproj ./
RUN dotnet restore /GenerateTableConsole.csproj
COPY . .
WORKDIR /src/
RUN dotnet build GenerateTableConsole.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish GenerateTableConsole.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GenerateTableConsole.dll"]
