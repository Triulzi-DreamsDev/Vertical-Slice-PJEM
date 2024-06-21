VAR playerName = ""
VAR haveFile = ""
-> start
=== start ===
{haveFile == "contaduria":
    "Ya tienes libro de contabilidad 'Archivos de contabilidad'." #speaker:Librero 
    -> END
- else:
    " libro de contabilidad ¿deseas consultarlos?" #speaker:Librero 
    + [Sí]
        -> consultarContaduria
    + [No]
        -> END
}
=== consultarContaduria ===
"Los Archivos de contabilidad parecen interesantes... pero, no son el archivo crucial que estás buscando."#speaker:Librero
-> END