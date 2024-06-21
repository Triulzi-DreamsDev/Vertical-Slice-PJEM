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
        -> tomar
    + [No]
        -> no_tomar
}
=== tomar ===
#bool:true
    Ya has tomado el Archivo "Proyecto de Ley Crucial".
-> END

=== no_tomar ===
#bool:false
No has tomado el Archivo "Proyecto de Ley Crucial".
-> END



