 VAR playerName = ""
-> start

=== start ===
Aquí se encuentra el archivo "Proyecto de Ley Crucial", ¿deseas tomar? #speaker:Librero 
    + [Si]
        -> tomar_archivo
    + [No]
        -> no_tomar_archivo

=== tomar_archivo ===
#bool:true
Ya Has tomado el archivo "Proyecto de Ley Crucial".
-> END

=== no_tomar_archivo ===
#bool:false
No has tomado el archivo "Proyecto de Ley Crucial".
-> END
 
 