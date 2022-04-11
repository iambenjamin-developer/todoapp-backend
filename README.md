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