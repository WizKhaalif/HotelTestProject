FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["AuthorizationSystem/AuthorizationSystem.csproj", "AuthorizationSystem/"]
COPY ["AuthorizationSystem.Domain/AuthorizationSystem.Domain.csproj", "AuthorizationSystem.Domain/"]
COPY ["AuthorizationSystem.Domain.Entities/AuthorizationSystem.Domain.Entities.csproj", "AuthorizationSystem.Domain.Entities/"]
COPY ["AuthorizationSystem.Contracts/AuthorizationSystem.Contracts.csproj", "AuthorizationSystem.Contracts/"]
RUN dotnet restore "AuthorizationSystem/AuthorizationSystem.csproj"
COPY . .
WORKDIR "/src/AuthorizationSystem"
RUN dotnet build "AuthorizationSystem.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AuthorizationSystem.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Production
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AuthorizationSystem.dll"]