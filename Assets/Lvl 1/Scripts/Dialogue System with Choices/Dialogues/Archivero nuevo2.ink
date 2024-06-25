VAR playerName = ""
VAR haveFile = ""

-> start

=== start ===
{haveFile == true:
    "Ya tienes el Archivo 'Proyecto de Ley Crucial'." #speaker:Librero

-> END
- else:
    "Registros Contables, ¿Deseas consultarlo?" #speaker:Librero
    + [Sí]
        -> tomar_archivo
    + [No]
        -> no_tomar_archivo 
}
=== tomar_archivo ===
    "Los Registros Contables parecen interesantes... pero no son el archivo crucial que estás buscando..."
-> END
 === no_tomar_archivo ===
Dejaste el Archivo "Registros Contables", busca en otro librero. #speaker:Librero
-> END