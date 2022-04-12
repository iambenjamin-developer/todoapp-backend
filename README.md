# Docker comandos

## Construir imagen
```
docker build -t todo-app-backend .
```

## Correr la imagen en el puerto 5024
```
docker run -d -p 5025:5025 todo-app-backend
```

## Verificar funcionamiento
```
http://localhost:5025/api/Values
```

# SQL Server

## Descargar imagen oficial SQL Server 2019
```
docker pull mcr.microsoft.com/mssql/server:2019-latest
```

## Correr imagen de SQL Server 2019 y configurar password

```
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=2Secure*Password2" -p 1450:1433 --name sqlserverdb -h mysqlserver -d mcr.microsoft.com/mssql/server:2019-latest
```