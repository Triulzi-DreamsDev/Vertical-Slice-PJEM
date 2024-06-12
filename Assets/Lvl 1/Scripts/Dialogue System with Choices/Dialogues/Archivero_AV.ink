VAR playerName = ""
-> start

=== start ===
Oh, el archivo "Proyecto de Ley Crucial"...#speaker:Librero 
¿Debería tomarlo?

    + [Sí]
        -> tomar
    + [No]
        -> dejar

=== tomar ===
#bool:true
Bien, ahora tengo el archivo "Proyecto de Ley Crucial".
-> END

=== dejar ===
#bool:false
Hmm, mejor lo dejo, "Proyecto de Ley Crucial" no es para mí.
-> END

 