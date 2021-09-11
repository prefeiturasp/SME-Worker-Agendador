#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SME.SGP.Worker.Agendador.Service/SME.SGP.Worker.Agendador.Service.csproj", "SME.SGP.Worker.Agendador.Service/"]
RUN dotnet restore "SME.SGP.Worker.Agendador.Service/SME.SGP.Worker.Agendador.Service.csproj"
COPY . .
WORKDIR "/src/SME.SGP.Worker.Agendador.Service"
RUN dotnet build "SME.SGP.Worker.Agendador.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SME.SGP.Worker.Agendador.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SME.SGP.Worker.Agendador.Service.dll"]