VAR playerName = ""
VAR haveFile = ""
-> start
=== start ===
{haveFile == true:
    "Ya tienes el Archivo 'Proyecto de Ley Crucial'." #speaker:Librero

-> END
- else:
    "Libro de Contabilidad ¿Deseas consultarlos?" #speaker:Librero 
    + [Sí]
        -> consultarContaduria
    + [No]
        -> no_tomar_archivo
}
=== consultarContaduria ===
"Los Archivos de Contabilidad parecen interesantes... pero, no son el archivo crucial que estás buscando."#speaker:Librero
 -> END
 
 === no_tomar_archivo ===
Dejaste el Archivo "Contabilidad", busca en otro librero. #speaker:Librero
-> END