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
### Crear base de datos y tabla

```
--CREATE DATABASE [MyDockerToDoDb]

CREATE TABLE [dbo].[ToDoItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TaskName] [varchar](256) NOT NULL,
	[IsCompleted] [bit] NOT NULL,
	[DateCompleted] [datetime2](7) NULL,
 CONSTRAINT [PK_ToDoItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


```


## Correr imagen de SQL Server 2019 y configurar password

```
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Mypassword*7" -p 1450:1433 --name sqlserverdb -h mysqlserver -d mcr.microsoft.com/mssql/server:2019-latest
```


## Correr docker compose
Ir a la ruta donde esta el Dockerfile y el docker-compose
```
cd C:\Users\benja\source\repos\TODO-APP\todoapp-backend
```

Iniciar docker-compose
```
docker-compose up -d
```

Parar docker-compose
```
docker-compose stop
```

Iniciar docker-compose con 2 instancias de un servicio 
```
docker-compose up -d --scale todo-app-frontend=2
```

Iniciar docker-compose con varias instancias de varios servicios 
```
docker-compose up -d --scale todo-app-backend=2 --scale todo-app-frontend=4
```