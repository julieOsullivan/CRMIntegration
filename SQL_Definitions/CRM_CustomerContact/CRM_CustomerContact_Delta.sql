CREATE TABLE dbo.CRM_CustomerContact_Delta
(
company_number VARCHAR(5),
customer_account VARCHAR(20),
delivery_sequence VARCHAR(10),
contact_type VARCHAR(4),
contact_number INT,

contact_name VARCHAR(255),
job_title VARCHAR(255),
correspondence_name VARCHAR(255),

phone_home VARCHAR(50),
phone_preferred VARCHAR(50),
phone_office VARCHAR(50),
phone_mobile VARCHAR(50),

email VARCHAR(255),
general_text1 VARCHAR(255),
general_text2 VARCHAR(255),

row_hash CHAR(32),
load_ts DATETIME2(3),

change_code TINYINT NOT NULL
);