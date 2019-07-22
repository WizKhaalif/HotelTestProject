FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["HotelAdministrationSystem/HotelAdministrationSystem.csproj", "HotelAdministrationSystem/"]
COPY ["HotelAdministrationSystem.Domain/HotelAdministrationSystem.Domain.csproj", "HotelAdministrationSystem.Domain/"]
COPY ["HotelAdministrationSystem.Domain.Entities/HotelAdministrationSystem.Domain.Entities.csproj", "HotelAdministrationSystem.Domain.Entities/"]
COPY ["HotelAdministrationSystem.Contracts/HotelAdministrationSystem.Contracts.csproj", "HotelAdministrationSystem.Contracts/"]
COPY ["AuthorizationSystem/AuthorizationSystem.csproj", "AuthorizationSystem/"]
COPY ["AuthorizationSystem.Domain/AuthorizationSystem.Domain.csproj", "AuthorizationSystem.Domain/"]
COPY ["AuthorizationSystem.Domain.Entities/AuthorizationSystem.Domain.Entities.csproj", "AuthorizationSystem.Domain.Entities/"]
COPY ["AuthorizationSystem.Contracts/AuthorizationSystem.Contracts.csproj", "AuthorizationSystem.Contracts/"]
RUN dotnet restore "HotelAdministrationSystem/HotelAdministrationSystem.csproj"
COPY . .
WORKDIR "/src/HotelAdministrationSystem"
RUN dotnet build "HotelAdministrationSystem.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "HotelAdministrationSystem.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HotelAdministrationSystem.dll"]