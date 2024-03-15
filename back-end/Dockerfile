#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["back-end/back-end.csproj", "back-end/"]
COPY ["Business/Model/Model.csproj", "Business/Model/"]
COPY ["Data/Entity/Entity.csproj", "Data/Entity/"]
COPY ["Ioc/Ioc.Api/Ioc.Api.csproj", "Ioc/Ioc.Api/"]
COPY ["Business/Service.Interface/Service.Interface.csproj", "Business/Service.Interface/"]
COPY ["Business/Service/Service.csproj", "Business/Service/"]
COPY ["Data/Context.Interface/Context.Interface.csproj", "Data/Context.Interface/"]
COPY ["Data/Repository.Interface/Repository.Interface.csproj", "Data/Repository.Interface/"]
COPY ["Business/Mapper/Mapper.csproj", "Business/Mapper/"]
COPY ["Data/Repository/Repository.csproj", "Data/Repository/"]
COPY ["pot_shop_official-back-end/Data/Context/Context.csproj", "Data/Context/"]
#COPY ["Ioc/Ioc.Test/Ioc.Test.csproj", "Ioc/Ioc.Test/"]
RUN dotnet restore "./back-end/./back-end.csproj"
COPY . .
WORKDIR "/src/back-end"
RUN dotnet build "./back-end.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./back-end.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "back-end.dll"]
