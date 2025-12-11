# 📘 BookManager API

Este documento contiene instrucciones para construir la imagen Docker y ejecutar el contenedor de BookManager.Api, incluyendo credenciales predeterminadas y la URL de Swagger.

## 📌 Información del Proyecto

- **Nombre**: BookManager.Api
- **Versión**: .NET 8
- **Base de datos**: SQLite
- **Migraciones**: Se aplican automáticamente al iniciar la aplicación
- **Dockerfile**: Ubicado en `BookManager.Api/Dockerfile`

## 🔑 Credenciales Predeterminadas

| Nombre de usuario | Contraseña   |
|------------------|--------------|
| admin            | Admin123$    |

Estas credenciales se utilizan para la autenticación JWT al consumir endpoints protegidos.

## 🌐 URL de Swagger

Una vez que el contenedor esté en ejecución, accede a Swagger en:

```
http://localhost:8080/swagger
```

## 🐳 Requisitos Previos

Para ejecutar este proyecto necesitas:

- Docker Desktop (Windows 11 / macOS)
- o Docker Engine (Linux)

Verifica tu instalación:

```bash
docker --version
```

## 🏗️ 1. Construir Imagen Docker

Desde la raíz del repositorio, ejecuta:

```bash
docker build -f BookManager.Api/Dockerfile -t bookmanager-api .
```

Explicación:
- `-f BookManager.Api/Dockerfile`: Usa el Dockerfile ubicado dentro del proyecto API
- `-t bookmanager-api`: Nombre de la imagen generada
- `.`: Indica que la construcción se realiza desde la raíz del proyecto

## ▶️ 2. Ejecutar Contenedor

Para iniciar la API en Docker:

```bash
docker run -d -p 8080:8080 --name bookmanager-api-container bookmanager-api
```

Explicación:
- `-d`: Ejecuta en segundo plano
- `-p 8080:8080`: Expone el puerto 8080 del contenedor al puerto local
- `--name bookmanager-api-container`: Nombre del contenedor
- `bookmanager-api`: Nombre de la imagen que generaste

## 🖥️ 3. Inicio del Contenedor por Sistema Operativo

### 🪟 Windows 11 (Docker Desktop)

1. Abre PowerShell o CMD
2. Navega a la carpeta raíz del proyecto
3. Construye la imagen:
   ```bash
   docker build -f BookManager.Api/Dockerfile -t bookmanager-api .
   ```
4. Ejecuta el contenedor:
   ```bash
   docker run -d -p 8080:8080 --name bookmanager-api-container bookmanager-api
   ```
5. Abre en tu navegador:
   ```
   http://localhost:8080/swagger
   ```

### 🐧 Linux (Docker Engine / Docker Desktop)

1. Abre la terminal
2. Navega al directorio raíz del proyecto
3. Construye la imagen:
   ```bash
   sudo docker build -f BookManager.Api/Dockerfile -t bookmanager-api .
   ```
4. Ejecuta el contenedor:
   ```bash
   sudo docker run -d -p 8080:8080 --name bookmanager-api-container bookmanager-api
   ```
5. Accede a Swagger:
   ```
   http://localhost:8080/swagger
   ```

### 🍏 macOS (Docker Desktop)

1. Abre Terminal
2. Navega a la raíz del proyecto
3. Construye la imagen:
   ```bash
   docker build -f BookManager.Api/Dockerfile -t bookmanager-api .
   ```
4. Ejecuta el contenedor:
   ```bash
   docker run -d -p 8080:8080 --name bookmanager-api-container bookmanager-api
   ```
5. Abre Swagger:
   ```
   http://localhost:8080/swagger
   ```

## 🧪 4. Verificar Contenedor en Ejecución

```bash
docker ps
```

Deberías ver algo como:
```
bookmanager-api-container   0.0.0.0:8080->8080/tcp
```

## 🛑 5. Detener / Reiniciar / Eliminar

Detener contenedor:
```bash
docker stop bookmanager-api-container
```

Reiniciar contenedor:
```bash
docker restart bookmanager-api-container
```

Eliminar contenedor:
```bash
docker rm bookmanager-api-container
```

Eliminar imagen:
```bash
docker rmi bookmanager-api
```

## 🎯 6. Notas Finales

✔ No es necesario crear la base de datos manualmente  
✔ Las migraciones se aplican automáticamente al iniciar la API  
✔ SQLite se genera en la ruta configurada en `appsettings.json`