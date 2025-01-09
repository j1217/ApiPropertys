# Web API para Gestión de Propiedades

## Introducción
El proyecto **Web API para Gestión de Propiedades** fue desarrollado en **Visual Studio 2022** utilizando el framework **.NET 8.0**. Está diseñado para gestionar propiedades inmobiliarias en Estados Unidos, permitiendo realizar operaciones como crear propiedades, agregar imágenes, actualizar información, cambiar precios y realizar consultas con filtros avanzados. La arquitectura sigue un enfoque hexagonal para garantizar modularidad, escalabilidad y separación de responsabilidades. La base de datos utilizada es **SQL Server**.

## Objetivos del Proyecto
El objetivo principal del proyecto es crear una API robusta y eficiente que permita a los usuarios interactuar con datos relacionados con propiedades y propietarios, asegurando un flujo de trabajo claro, flexible y mantenible.

## Tecnologías Utilizadas
- **Visual Studio 2022:** Entorno de desarrollo integrado (IDE) empleado para la creación del proyecto.
- **.NET 8.0:** Framework utilizado para el desarrollo de la aplicación.
- **SQL Server:** Motor de base de datos relacional para almacenamiento y gestión de datos.
- **Entity Framework Core:** ORM (Object-Relational Mapping) para la interacción con la base de datos.
- **XUnit:** Framework de pruebas unitarias para garantizar la calidad del código.
- **LINQ:** Utilizado para realizar consultas a la base de datos de forma eficiente.
- **Arquitectura Hexagonal:** Diseñada para separar las responsabilidades en capas, fomentando la escalabilidad y el mantenimiento.
- **Inyección de Dependencias:** Implementada para mejorar la modularidad y seguir los principios **SOLID**.
- **Documentación XML en .NET:** Para generar comentarios y documentación directa desde el código fuente.

## Principios SOLID y Clean Code
Se sigue un enfoque basado en principios **SOLID**, garantizando un diseño de software robusto y escalable, junto con las prácticas de **Clean Code**, que aseguran un código legible y fácil de mantener.

## Estructura del Proyecto
El proyecto está dividido en capas para fomentar la separación de responsabilidades y modularidad. Las principales capas son:

- **Domain:** Contiene las entidades de negocio y las interfaces que definen los contratos entre capas.
- **Application:** Contiene la lógica de negocio y los servicios de aplicación.
- **Infrastructure:** Implementa el acceso a datos mediante **Entity Framework Core** y otros detalles técnicos.
- **WebApiPropertys:** Proyecto principal que expone los endpoints de la API REST.
- **WebApiPropertys.Tests:** Proyecto de pruebas unitarias que asegura el correcto funcionamiento del sistema.

## Funcionalidades Principales

### Propietarios:
- Crear y actualizar información de propietarios.
- Obtener propietarios por nombre o con sus propiedades asociadas.

### Propiedades:
- Crear, actualizar y cambiar precios de propiedades.
- Consultar propiedades con filtros por ubicación y rango de precios.

### Imágenes:
- Agregar imágenes a propiedades.
- Actualizar el estado de una imagen (habilitada o deshabilitada).

### Historial de Propiedades (PropertyTrace):
- Registrar y consultar cambios en el historial de una propiedad.

## Implementación de la Base de Datos
La interacción con la base de datos utiliza **Entity Framework Core** para el manejo de modelos y el contexto de datos. Se utiliza un enfoque basado en código, lo que permite actualizaciones y migraciones eficientes a través de la herramienta de migración de **EF Core**.

## Pruebas Unitarias
Las pruebas unitarias se desarrollaron utilizando **XUnit** para validar los siguientes escenarios:

- Creación, actualización y eliminación de entidades.
- Consultas con filtros avanzados.
- Validación de reglas de negocio específicas, como cambios de precio o actualizaciones de estado.

## Documentación y Comentarios
El código está documentado utilizando la funcionalidad de documentación **XML** de **.NET**. Los comentarios explican las secciones clave del código, incluyendo la lógica de negocio, los métodos principales y las pruebas unitarias.

## Conclusiones
El proyecto proporciona una solución moderna y escalable para la gestión de propiedades inmobiliarias. La implementación en **.NET 8.0**, junto con prácticas avanzadas de arquitectura y desarrollo, asegura un sistema robusto, fácil de mantener y preparado para futuras extensiones.
