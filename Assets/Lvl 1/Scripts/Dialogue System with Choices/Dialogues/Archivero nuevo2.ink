VAR playerName = ""
VAR haveFile = ""

-> start

=== start ===
{haveFile== true:
    "Ya tienes el archivo "Proyecto de Ley Crucial." #speaker:Librero 

-> END
- else:
"Archivos de Contaduría 2023, ¿deseas consultarlos?" #speaker:Librero 
    + [Si]
        -> tomar_archivo
    + [No]
        -> END
}
=== tomar_archivo ===
    "Los libros de contaduría parecen interesantes... pero, no son el archivo crucial que estás buscando...
-> END

