SELECT
    T1.CONO1A AS company_number,
    RTRIM(TRIM(T1.TPAC1A)) AS customer_account,
    RTRIM(TRIM(T1.DSEQ1A)) AS delivery_sequence,
    RTRIM(TRIM(T1.CTCT1A)) AS contact_type,
    T1.CTNU1A AS contact_number,
    RTRIM(TRIM(T1.CNTN1A)) AS contact_name,
    RTRIM(TRIM(T1.CNJT1A)) AS job_title,
    RTRIM(TRIM(T1.CRNM1A)) AS correspondence_name,
    RTRIM(TRIM(T1.HMNB1A)) AS phone_home,
    RTRIM(TRIM(T1.PFNB1A)) AS phone_preferred,
    RTRIM(TRIM(T1.OFNB1A)) AS phone_office,
    RTRIM(TRIM(T1.MBNB1A)) AS phone_mobile,
    RTRIM(TRIM(T1.EMIL1A)) AS email,
    RTRIM(TRIM(T1.GTX11A)) AS general_text1,
    RTRIM(TRIM(T1.GTX21A)) AS general_text2,
    HEX(
        HASH(
            VARCHAR(
                COALESCE(RTRIM(TRIM(T1.CNTN1A)),'') ||
                COALESCE(RTRIM(TRIM(T1.CNJT1A)),'') ||
                COALESCE(RTRIM(TRIM(T1.CRNM1A)),'') ||
                COALESCE(RTRIM(TRIM(T1.HMNB1A)),'') ||
                COALESCE(RTRIM(TRIM(T1.PFNB1A)),'') ||
                COALESCE(RTRIM(TRIM(T1.OFNB1A)),'') ||
                COALESCE(RTRIM(TRIM(T1.MBNB1A)),'') ||
                COALESCE(RTRIM(TRIM(T1.EMIL1A)),'') ||
                COALESCE(RTRIM(TRIM(T1.GTX11A)),'') ||
                COALESCE(RTRIM(TRIM(T1.GTX21A)),'')
            )
        )
    ) AS ROW_HASH,

    CURRENT_TIMESTAMP AS LOAD_TS

FROM EDUT1F3.T1P1A T1
WHERE T1.CONO1A='GK'
AND T1.GLCO1A='GK'
AND T1.APPL1A='SL'
AND T1.DSEQ1A='000'