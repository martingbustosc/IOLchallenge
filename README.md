
# InvertirOnline.com Coding Challenge

Bienvenido!

### El problema

Tenemos un método que genera un reporte en base a una colección de formas geométricas, procesando algunos datos para presentar información extra. La firma del método es:

```csharp
public static string Imprimir(List<FormaGeometrica> formas, int idioma)
```

Al mismo tiempo, encontramos muy díficil el poder agregar o bien una nueva forma geométrica, o imprimir el reporte en otro idioma. Nos gustaría poder dar soporte para que el usuario pueda agregar otros tipos de formas u obtener el reporte en otros idiomas, pero extender la funcionalidad del código es muy doloroso. ¿Nos podrías dar una mano a refactorear la clase FormaGeometrica? Dentro del código encontrarás un TODO con nuevos requerimientos a satisfacer una vez completada la refactorización.

### Solución

Decidí sumar como idomas: italiano, francés y portugues.
Figura geometrica nueva: trapecio rectángulo.

Se eligió para un testeo fácil, por una cuestión de cálculos redondos, las medidas de las bases: 4 y 8, y altura 3. El lado restante, se calcula a partir del triángulo rectángulo interno en el trapecio.


**¡¡Muchas gracias!!**
