VAR playerName = ""
VAR haveFile = ""
-> start
=== start ===
{haveFile == "contratos":
    "Ya tienes el archivo de contratos 'Contratos de empleados'." #speaker:Librero 
    -> END
- else:
    "Contratos de empleados #speaker:Librero 
    ¿es lo que estás buscando?" 
    + [Sí]
        -> consultarContratos
    + [No]
        -> END
}
=== consultarContratos ===
"Estás viendo los contratos de empleados. Parece que no es lo que necesitas..." #speaker:Librero
-> END