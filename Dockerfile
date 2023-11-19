FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ActivityReview.csproj", "./"]
RUN dotnet restore "ActivityReview.csproj"
COPY . .
RUN dotnet build "ActivityReview.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ActivityReview.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ActivityReview.dll"]
