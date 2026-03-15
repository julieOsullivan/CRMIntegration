create table dbo.crm_customercontactnotes_delta (
    company_number      varchar(5)  not null,
    customer_account    varchar(20) not null,
    delivery_sequence   varchar(10) not null,
    contact_type        varchar(4)  null,
    contact_number      int         not null,
    note_line           int         not null,
    note_text           varchar(36),     -- matches DB2
    row_hash            char(32),
    load_ts             datetime2(3),
    change_code         tinyint     not null   -- 1=Insert, 2=Delete, 3=Update
);
