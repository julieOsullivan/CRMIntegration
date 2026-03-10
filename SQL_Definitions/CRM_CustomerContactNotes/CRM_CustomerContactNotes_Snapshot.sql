CREATE TABLE CRM_CustomerContactNote_Current (

company_group VARCHAR(5),
company_number VARCHAR(5),
application VARCHAR(5),
contact_reference VARCHAR(50),
note_line_number INT,
note_text VARCHAR(1024),
row_hash CHAR(64),
load_ts DATETIME2 NULL
);