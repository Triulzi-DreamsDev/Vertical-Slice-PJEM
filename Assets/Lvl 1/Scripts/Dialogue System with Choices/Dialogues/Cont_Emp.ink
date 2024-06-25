VAR playerName = ""
VAR haveFile = ""
-> start

=== start ===
{haveFile == true:
    "Ya tienes el Archivo 'Proyecto de Ley Crucial'." #speaker:Librero

-> END
- else:
    "Registro de Pagos a Empleados, ¿Es lo que estás buscando?" #speaker:Librero 
    + [Sí]
        -> consultarregistro
    + [No]
        -> no_tomar_archivo
}
=== consultarregistro ===
"Los Registros de Pagos a Empleados tienen muchos documentos, pero no el que buscas..." #speaker:Librero
-> END
 === no_tomar_archivo ===
Dejaste el Archivo "Pago a Empleado", busca en otro librero. #speaker:Librero
-> END
