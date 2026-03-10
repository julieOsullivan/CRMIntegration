CREATE TABLE CustomerContact_Delta
(
company_number        VARCHAR(5),
customer_account      VARCHAR(8),
delivery_sequence     VARCHAR(3),
contact_type          VARCHAR(4),
contact_number        INT,
contact_name          VARCHAR(255),
job_title             VARCHAR(255),
correspondence_name   VARCHAR(255),
phone_home            VARCHAR(50),
phone_preferred       VARCHAR(50),
phone_office          VARCHAR(50),
phone_mobile          VARCHAR(50),
email                 VARCHAR(255),
general_text1         VARCHAR(255),
general_text2         VARCHAR(255),

row_hash              VARCHAR(64) NOT NULL,
load_ts               DATETIME NOT NULL DEFAULT GETDATE(),
change_code           TINYINT NOT NULL
);