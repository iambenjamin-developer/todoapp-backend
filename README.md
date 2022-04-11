# Docker comandos

## Construir imagen
```
docker build -t backend .
```

## Correr la imagen en el puerto 5024
```
docker run -d -p 5025:5025 backend
```

## Verificar funcionamiento
```
http://localhost:5025/api/Values
```