create table dbo.crm_customercontactnotes_current (

company_number      varchar(5)  not null,
customer_account    varchar(20) not null,
delivery_sequence   varchar(10) not null,
contact_type        varchar(4)  null,
contact_number      int         not null,

note_line           int         not null,
note_text           varchar(36),

row_hash            char(32),
load_ts             datetime2(3) default getdate()

);

alter table dbo.crm_customercontactnotes_current
add constraint pk_crm_customercontactnotes_current primary key (

company_number,
customer_account,
delivery_sequence,
contact_number,
note_line

);