# 1. Fase base para ejecución en OpenShift
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# OpenShift requiere que la app no corra como root por seguridad
USER $APP_UID 
WORKDIR /app
EXPOSE 8080

# 2. Fase de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar el archivo del proyecto principal
COPY ["ApiGestionCursos.csproj", "./"]

# Restaurar dependencias
RUN dotnet restore "ApiGestionCursos.csproj"

# Copiar el resto del código fuente a la imagen
COPY . .

# Compilar
RUN dotnet build "ApiGestionCursos.csproj" -c $BUILD_CONFIGURATION -o /app/build

# 3. Fase de publicación
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ApiGestionCursos.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# 4. Fase final (Imagen ligera solo con los binarios)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiGestionCursos.dll"]