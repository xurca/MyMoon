#FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
#FROM mcr.microsoft.com/dotnet/sdk:3.1 AS base


FROM mcr.microsoft.com/dotnet/sdk:3.1-alpine AS build
WORKDIR /docapp
COPY ["Api/Api.csproj", "Api/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "Api/Api.csproj"
COPY . .
WORKDIR "/docapp/Api"
RUN dotnet build "Api.csproj" --no-self-contained -c Release -o /build 

FROM build AS publish
RUN dotnet publish "Api.csproj" --no-self-contained -c Release -o /publish

#FROM build AS final
#WORKDIR /docapp
#COPY --from=build /build .
#ENTRYPOINT ["dotnet", "MyMoon.Api.dll"]


FROM mcr.microsoft.com/dotnet/sdk:3.1-alpine AS final
WORKDIR /docapp
COPY --from=publish /publish .
ENTRYPOINT ["dotnet", "MyMoon.Api.dll"]


#docker build --target final -t mymoonapi .
#docker run -d -p 8080:80 --name mymoon mymoonapi

# docker build -t mymoonapi .
# docker run -p 8080:80 --name cont_mymoonapi mymoonapi

#docker build -t mymoonapi .
#docker run mymoonapi --name mymoonapi
