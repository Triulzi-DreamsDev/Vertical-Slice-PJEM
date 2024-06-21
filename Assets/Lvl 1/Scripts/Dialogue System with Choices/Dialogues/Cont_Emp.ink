VAR playerName = ""
VAR haveFile = ""
-> start

=== start ===
{haveFile == "contratos":
    "Ya tienes el Registro de Pagos a Empleados 'Contratos de Empleados'." #speaker:Librero 
    -> END
- else:
    "Registro de Pagos a Empleados, ¿Es lo que estás buscando?" #speaker:Librero 
    + [Sí]
        -> consultarregistro
    + [No]
        -> END
}
=== consultarregistro ===
"Los Registros de Pagos a Empleados tienen muchos documentos, pero no el que buscas..." #speaker:Librero
-> END
