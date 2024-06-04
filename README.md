# Parqueadero API - Instrucciones de instalación y ejecución 

Este proyecto es una API REST desarrollada con el fin de gestionar procesos CRUD de libros.

## Tecnologías utilizadas
- .NET 8
- Entity Framework
## Instalación

Sigue estos pasos para instalar y ejecutar el proyecto en tu entorno local:

```bash
git clone https://github.com/STBenji/BookSaleApi.git
cd Prueba_Tecnica_NewIntech
Abrir Visual Studio y seleccionar la solución del proyecto
```

## Configuración

Antes de ejecutar el proyecto, asegúrate de configurar y crear la información de tu base de datos:

```js
"ConnectionStrings": {
  "MySqlConnection": "server=#;port=#;database=#;uid=#;password=#"
}
```
Asegúrate de cambiar los valores de las variables según tu configuración y tener el mismo nombre de la conexión en tu Program.cs.

## Ejecución
Una vez configurada la conexión a la base de datos, puedes iniciar el servidor

## Notas adicionales
- Asegúrate de tener una base de datos MySQL configurada y funcionando correctamente antes de ejecutar el proyecto.

## ¡Disfruta explorando tu API de libros! 🚀
