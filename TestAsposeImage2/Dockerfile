#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["TestAsposeImage2/TestAsposeImage2.csproj", "TestAsposeImage2/"]
RUN dotnet restore "TestAsposeImage2/TestAsposeImage2.csproj"
COPY . .
WORKDIR "/src/TestAsposeImage2"
RUN dotnet build "TestAsposeImage2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestAsposeImage2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
RUN apt-get update
RUN apt-get install -y libfontconfig1
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestAsposeImage2.dll"]