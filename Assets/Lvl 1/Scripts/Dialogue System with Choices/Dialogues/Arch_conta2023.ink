VAR playerName = ""
VAR haveFile = ""
-> start
=== start ===
{haveFile == "contaduria":
    "Ya tienes el archivo de contaduría 'Archivos de Contaduría 2023'." #speaker:Librero 
    -> END
- else:
    "Archivos de Contaduría 2023 #speaker:Librero 
    ¿deseas consultarlos?" 
    + [Sí]
        -> consultarContaduria
    + [No]
        -> END
}
=== consultarContaduria ===
"Los libros de contaduría parecen interesantes... pero, no son el archivo crucial que estás buscando."#speaker:Librero
-> END