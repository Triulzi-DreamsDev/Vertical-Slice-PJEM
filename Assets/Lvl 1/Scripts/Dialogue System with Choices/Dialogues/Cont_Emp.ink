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
"Contratos de empleados. Hay muchos documentos, pero no el que necesito..." #speaker:Librero
-> END