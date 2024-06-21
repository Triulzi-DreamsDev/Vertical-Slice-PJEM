VAR playerName = ""
VAR haveFile = ""
-> start

=== start ===
{haveFile == true:
    Ya tienes el archivo "Proyecto de Ley Crucial". #speaker:Librero 
-> END
- else:

Aquí está disponible el archivo "Proyecto de Ley Crucial". #speaker:Librero 
¿Deseas acceder a él?

    + [Sí]
        -> tomar
    + [No]
        -> dejar

}
=== tomar ===
#bool:true
Bien, ahora tengo el archivo "Proyecto de Ley Crucial".
-> END

=== dejar ===
#bool:false
Hmm, mejor lo dejo, "Proyecto de Ley Crucial" no es para mí.
-> END

 