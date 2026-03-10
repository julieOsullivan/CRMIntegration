SELECT
    CONO2A AS company_number,
    RTRIM(SUBSTR(TREF2A,1,8)) AS customer_account,
    SUBSTR(TREF2A,9,3) AS delivery_sequence,
    INTEGER(SUBSTR(TREF2A,12,9)) AS contact_number,
    TLNO2A AS note_sequence,
    RTRIM(TRIM(TLIN2A)) AS rapport_note
FROM EDUT1F3.T1P2A
WHERE
    GLCO2A='GK'
AND CONO2A='GK'
AND APPL2A='SL'
AND TXTT2A='C'