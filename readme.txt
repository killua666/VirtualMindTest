La API Rest esta realizada en .Net Core 3.1
Se conecta con una base de datos SQL el cual se puede configurar en el archivo appsettings.json. 
En este momento se encuentra configurada una base de datos en AZURE la cual esta publica para esta ocasión, si desean pueden utilizarla.

La UI se encuentra realizada con la última versión de angular y se utilizó el set de componentes de Material.UI
Se genero un archivo proxy.conf.json en el cual se encuentra configurado la url de la API en este caso está configurada https://localhost:44368

Por último el test contiene 2 preguntas:

2a) ¿Qué opina de pasar el id de usuario como input del endpoint? 
Creo hay distintas formas de realizar esta operación. En el caso de usuario no lo veo tan mal si la API contara con algún método de autenticación 
como bearer token, para asegurarnos que la fuente es confiable. Otra cosa que se podría realizar es encriptar los datos y que se desencripten 
en la API.
2b) ¿Cómo mejoraría la transacción para asegurarnos de que el usuario que pidió la compra es quien dice ser?
agregaría un inicio de sesión previo, para que el usuario posea una contraseña y al momento de realizar compra validar que los datos sean correctos.
Hasta se podría utilizar Basic Auth enviando Usuario y contraseña y validar el usuario antes de realizar la petición.
