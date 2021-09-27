FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/SME.Worker.Agendador.Api/SME.Worker.Agendador.Api.csproj", "src/SME.Worker.Agendador.Api/"]
COPY ["src/SME.Worker.Agendador.Background/SME.Worker.Agendador.Background.csproj", "src/SME.Worker.Agendador.Background/"]
COPY ["src/SME.Worker.Agendador.Infra/SME.Worker.Agendador.Infra.csproj", "src/SME.Worker.Agendador.Infra/"]
COPY ["src/SME.Worker.Agendador.Background.Core/SME.Worker.Agendador.Background.Core.csproj", "src/SME.Worker.Agendador.Background.Core/"]
COPY ["src/SME.Worker.Agendador.IoC/SME.Worker.Agendador.IoC.csproj", "src/SME.Worker.Agendador.IoC/"]
COPY ["src/SME.Worker.Agendador.Aplicacao/SME.Worker.Agendador.Aplicacao.csproj", "src/SME.Worker.Agendador.Aplicacao/"]
COPY ["src/SME.Worker.Agendador.Hangfire/SME.Worker.Agendador.Hangfire.csproj", "src/SME.Worker.Agendador.Hangfire/"]
RUN dotnet restore "src/SME.Worker.Agendador.Api/SME.Worker.Agendador.Api.csproj"
COPY . .
WORKDIR "/src/src/SME.Worker.Agendador.Api"
RUN dotnet build "SME.Worker.Agendador.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SME.Worker.Agendador.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SME.Worker.Agendador.Api.dll"]
