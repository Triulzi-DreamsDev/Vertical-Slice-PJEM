VAR playerName = ""
VAR haveFile = ""
-> start
=== start ===
{haveFile == "contaduria":
    "Ya tienes Libro de Contabilidad 'Archivos de contabilidad'." #speaker:Librero 
    -> END
- else:
    "Libro de Contabilidad ¿Deseas consultarlos?" #speaker:Librero 
    + [Sí]
        -> consultarContaduria
    + [No]
        -> END
}
=== consultarContaduria ===
"Los Archivos de Contabilidad parecen interesantes... pero, no son el archivo crucial que estás buscando."#speaker:Librero
-> END