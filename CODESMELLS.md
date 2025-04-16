# CODE SMELLS 
Código que no cumple con las buenas prácticas del libro Código Limpio. 
## NO CUMPLE CON DRY - Código duplicado en ambos archivos. 
`sube_actualizar_solicitud.asp` 
`sube_actualizar_solicitud2.asp` 
- Código repetido:  `if session("logueado")<>"SI" then` en archivos `materiasExamen.asp, examenes.asp, fechasExamen.asp` 
- Manejo de credenciales **hardcodeado** ``` usr_req = "dsi\BoletoWS" pass_req = "*B0l3tO2022!" ``` 
- Estructura de tablas HTML: el tag `... ` similares se repite en varias parte del código. 
## NO CUMPLE CON KISS - En **aspJSON.asp** contiene la **funciónes demasiado complejas**: 
`Private Function CleanUpJSONstring(aj_originalstring)` `Public Sub loadJSON(inputsource)` 
- En **boletoEstudiantil.asp**: `if flag_tiempo_solicitud = 0 then` 
## Variables con nombres poco descriptivos 
``` Set oJSON = New aspJSON Set oJSON2 = New aspJSON usr_req = "dsi\BoletoWS"` ``` 
## Comentarios redundantes 
``` '  Usuario y contraseña proporcionados por la facultad hacia el sistema de boleto estudiantil usr_req = "dsi\BoletoWS"` pass_req = "*B0l3tO2022!" ``` 
## Organización del código 
- **Falta de estructura modular**: el código no está organizado en módulos reutilizables ni tiene una estructura jerárquica clara. 
- **Dependencias implícitas**: falta de declaración explícita de las dependencias entre archivos. 
## Complejidad Ciclomática 
La **complejidad ciclomática** mide la cantidad de rutas de ejecución independientes en un código, lo que indica su complejidad estructural. 
- https://keepcoding.io/blog/complejidad-ciclomatica-en-programacion/ 
- https://learn.microsoft.com/es-es/visualstudio/code-quality/code-metrics-cyclomatic-complexity?view=vs-2022 
- https://juncotic.com/complejidad-ciclomatica/ 
|Nivel de Complejidad| Interpretación |Archivos Estimados | |--|--|--| 
| 1-4 |Código bien estructurado. Capacidad de testeo alta Costo y esfuerzo bajo |30-40% | 
| 5-10 |Código complejo |35-45% | 
| 11-20 |Código muy complejo |15-20% | 
| 21+ |No testeable |5-10% |