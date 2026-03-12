CREATE TABLE dbo.CRM_CustomerContact_Delta
(
    company_number       VARCHAR(5)  NOT NULL,
    customer_account     VARCHAR(8)  NOT NULL,
    delivery_sequence    VARCHAR(3)  NOT NULL,
    contact_type         VARCHAR(4)  NOT NULL,
    contact_number       INT         NOT NULL,

    contact_name         VARCHAR(255) NULL,
    job_title            VARCHAR(255) NULL,
    correspondence_name  VARCHAR(255) NULL,
    phone_home           VARCHAR(50)  NULL,
    phone_preferred      VARCHAR(50)  NULL,
    phone_office         VARCHAR(50)  NULL,
    phone_mobile         VARCHAR(50)  NULL,
    email                VARCHAR(255) NULL,
    general_text1        VARCHAR(255) NULL,
    general_text2        VARCHAR(255) NULL,

    row_hash             VARCHAR(32)  NOT NULL,
    load_ts              DATETIME     NOT NULL,

    change_code          TINYINT      NOT NULL,

    CONSTRAINT PK_CRM_CustomerContact_Delta
    PRIMARY KEY CLUSTERED
    (
        company_number,
        customer_account,
        delivery_sequence,
        contact_type,
        contact_number,
        load_ts
    )
);
