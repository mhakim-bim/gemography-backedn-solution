FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["GemoGraphy-Backend-Challenge/GemoGraphy-Backend-Challenge.csproj", "GemoGraphy-Backend-Challenge/"]
RUN dotnet restore "GemoGraphy-Backend-Challenge/GemoGraphy-Backend-Challenge.csproj"
COPY . .
WORKDIR "/src/GemoGraphy-Backend-Challenge"
RUN dotnet build "GemoGraphy-Backend-Challenge.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GemoGraphy-Backend-Challenge.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GemoGraphy-Backend-Challenge.dll"]
