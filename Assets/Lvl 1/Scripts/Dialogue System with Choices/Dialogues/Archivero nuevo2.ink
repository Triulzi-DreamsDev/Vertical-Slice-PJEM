VAR playerName = ""
VAR haveFile = ""

-> start

=== start ===
{haveFile== true:
    "Ya tienes el archivo "Proyecto de Ley Crucial." #speaker:Librero 

-> END
- else:
"Registros contables, ¿deseas consultarlos?" #speaker:Librero 
    + [Si]
        -> tomar_archivo
    + [No]
        -> END
}
=== tomar_archivo ===
    "Los Registros contables parecen interesantes... pero, no son el archivo crucial que estás buscando...
-> END