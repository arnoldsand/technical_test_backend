# --------------------------------------------------------
# ETAPA 1: BUILD (Compilación)
# --------------------------------------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1. Copia el archivo de la SOLUCIÓN (.sln) y el contenido de la carpeta del proyecto a la raíz.
# Esto asegura que el .sln y el .csproj estén en el mismo directorio.
COPY Techinical.Quala.Api/Techinical.Quala.Api.sln .
COPY Techinical.Quala.Api/. .

# 2. Restaura las dependencias usando el .CSPROJ, que ahora está en /src.
# Usamos el nombre del CSPROJ que ya sabemos que tiene la 'i' extra.
RUN dotnet restore "Techinical.Quala.Api.csproj"

# 3. Publica la aplicación (Usando el .csproj en la raíz)
RUN dotnet publish "Techinical.Quala.Api.csproj" -c Release -o /app/publish --no-restore

# --------------------------------------------------------
# ETAPA 2: FINAL (Runtime)
# --------------------------------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copia los archivos publicados.
COPY --from=build /app/publish .

EXPOSE 8080

# Comando de inicio
ENTRYPOINT ["dotnet", "Techinical.Quala.Api.dll"]