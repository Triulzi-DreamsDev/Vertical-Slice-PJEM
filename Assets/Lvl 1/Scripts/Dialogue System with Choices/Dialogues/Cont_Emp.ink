VAR playerName = ""
VAR haveFile = ""
-> start
=== start ===
{haveFile == "contratos":
    "Ya tienes el Registro de Pagos a Empleados 'Contratos de empleados'." #speaker:Librero 
    -> END
- else:
    "Registro de Pagos a Empleados ¿es lo que estás buscando?" #speaker:Librero 
    + [Sí]
        -> consultarregistro
    + [No]
        -> END
}
=== consultarregistro ===
"Los Registro de Pagos a Empleados. tiene muchos documentos, pero no el que buscas..." #speaker:Librero
-> END