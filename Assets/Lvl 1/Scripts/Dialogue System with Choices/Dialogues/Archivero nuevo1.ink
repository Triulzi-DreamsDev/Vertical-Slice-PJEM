VAR playerName = ""
VAR haveFile = ""

-> start

=== start ===
{haveFile == true:
    "Ya tienes el Archivo 'Proyecto de Ley Crucial'." #speaker:Librero

-> END
- else:
    "Archivo Recursos Humanos, ¿Es lo que estás buscando?" #speaker:Librero
    + [Sí]
        -> tomar_archivo
    + [No]
        -> END
}
=== tomar_archivo ===
    "Los Archivos de Recursos Humanos tienen muchos documentos, pero no está el que buscas."
-> END
