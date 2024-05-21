# Use the official ASP.NET Core runtime as the base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the main project files and restore dependencies
COPY ["ECommerce.Api/ECommerce.Api.csproj", "ECommerce.Api/"]
COPY ["ECommerce.Domain/ECommerce.Domain.csproj", "ECommerce.Domain/"]
COPY ["ECommerce.Core/ECommerce.Core.csproj", "ECommerce.Core/"]
COPY ["ECommerce.Infrastructure/ECommerce.Infrastructure.csproj", "ECommerce.Infrastructure/"]
RUN dotnet restore "ECommerce.Api/ECommerce.Api.csproj"

# Copy the rest of the source code and build the application
COPY . .
WORKDIR /src/ECommerce.Api
RUN dotnet build -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

# Final stage: copy the published files to the runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerce.Api.dll"]
