VAR playerName = ""
VAR haveFile = ""

-> start

=== start ===
{haveFile== true:
    "Ya tienes el archivo "Proyecto de Ley Crucial." #speaker:Librero 

-> END
- else:
"Contratos de empleados ¿es lo que estás buscando?" #speaker:Librero 
    + [Si]
        -> tomar_archivo
    + [No]
        -> END
}
=== tomar_archivo ===
    "Los archivos de Contratos de empleados tinen muchos documentos, pero no esta el que buscas"
-> END


