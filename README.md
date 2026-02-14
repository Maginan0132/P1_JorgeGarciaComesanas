## Pequeña overview de cada script dentro del proyecto

### PlayerController

Para el control del personaje, el script usa los ejes ya definidos en Unity para crear un vector de dirección del personaje. Luego este vector se usa normalizado (su módulo es 1) y multiplicado por la velocidad para establecer la velocidad lineal de el rigidBody. También usamos este mismo vector de dirección para que nuestro personaje mira en la dirección en la que está andando.
Hacemos que el personaje pueda esprintar comprobando que el shift izquierdo está presionado y modificando su velocidad. Para hacer el salto hago dos comprobaciones que esté presionado el espacio y que el personaje esté tocando un objeto con el tag "Suelo".
Para las animaciones, cada vez que se performa una de las distintas acciones, se cambia el valor del booleano correspondiente a la acción del animador.

### MovimientoCamara

He creado un script a parte para el movimiento de la cámara, ya que al hacerla hija su comportamiento es similar al de una cámara en primera persona. Este script simplemente coge la posición del jugador y la mueve hacia atrás y arriba para una mejor posición de la cámara.

### CaidaPlataforma

Este script regula el comportamiento de las plataformas que se caen un poco después de que el jugador las toque. Cuando hay una colisión chequea 3 parámetros:
- Que es con un jugador.
- Que no se esté ejecutando activamente la animación.
- Que la colisión haya sido con la parte superior de la plataforma.
Cuando confirma estas 3 cosas ejecuta una Coroutine para poder hacer que espere a empezar y para que pueda ejecutar un bucle while sin que Unity espera a su ejecución completa para el renderizado.

### MovimientoPlataforma

Para crear plataformas en constante movimiento he usado la función Lerp, que crea un vector de dirección entre 2 puntos, con el módulo que tu le especifiques (lerpValue). También para que nuestro jugador siga el movimiento de la plataforma cuando esté en contacto, en cuanto entre en colisión se le convertirá en hijo de la plataforma.
