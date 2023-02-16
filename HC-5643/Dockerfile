#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HC-5643/HC-5643.csproj", "HC-5643/"]
RUN dotnet restore "HC-5643/HC-5643.csproj"
COPY . .
WORKDIR "/src/HC-5643"
RUN dotnet build "HC-5643.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HC-5643.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HC-5643.dll"]