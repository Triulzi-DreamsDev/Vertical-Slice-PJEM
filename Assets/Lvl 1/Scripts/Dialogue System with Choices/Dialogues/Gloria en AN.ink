VAR playerName = ""
VAR haveFile = ""

-> start

=== start ===
Estoy buscando un informe perdido sobre el gasto público del año pasado. Es para una importante reunión que tengo mañana, ¿Me ayudas a encontrarlo? #speaker:Gloria de Contabilidad
    + [Si]
        -> si_te_ayudo
    + [No]
        -> No_continuar_con_mi_busqueda

=== si_te_ayudo ===
Claro que sí, yo también estoy buscando un archivo crucial #speaker:{playerName}
Genial, si trabajamos en equipo tendremos más oportunidades de encontrarlo ¿qué te parece? #speaker:Gloria de Contabilidad
    + [Trabajar en Equipo]
        -> Trabajar_en_Equipo
    + [Seguir por mi cuenta]
        -> Seguir_por_mi_cuenta
        
        === Trabajar_en_Equipo ===
        Me dijo Marion de Administración, que muchos archivos los han digitalizado, ven conozco un camino a la computadora de archivos, sígueme. #speaker:Gloria de Contabilidad
        -> END

        === Seguir_por_mi_cuenta ===
        Okey, suerte econtrando el archivo que buscas #speaker:Gloria de Contabilidad
        -> END

=== No_continuar_con_mi_busqueda ===
Okey, suerte econtrando el archivo que buscas #speaker:Gloria de Contabilidad
-> END