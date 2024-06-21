VAR playerName = ""
VAR haveFile = ""

-> start

=== start ===
{haveFile== true:
    Ya has tomado el Archivo "Proyecto de Ley Crucial". #speaker:Librero 

-> END
- else:
Aquí se encuentra el Archivo "Proyecto de Ley Crucial",   ¿Deseas tomar? #speaker:Librero 
    + [Si]
        -> tomar_archivo
    + [No]
        -> no_tomar_archivo
}
=== tomar_archivo ===
#bool:true
    Ya has tomado el Archivo "Proyecto de Ley Crucial".
-> END

=== no_tomar_archivo ===
#bool:false
No has tomado el Archivo "Proyecto de Ley Crucial".
-> END



