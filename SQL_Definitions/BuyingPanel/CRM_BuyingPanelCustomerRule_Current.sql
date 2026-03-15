CREATE TABLE dbo.CRM_BuyingPanelCustomerRule_Current
(
company_number VARCHAR(5) NOT NULL,
customer_account VARCHAR(20) NOT NULL,
delivery_sequence VARCHAR(10) NOT NULL,
rule_number VARCHAR(10) NOT NULL,

rule_description VARCHAR(255) NULL,

row_hash CHAR(32) NOT NULL,
load_ts DATETIME2(3) NULL,

CONSTRAINT PK_CRM_BuyingPanelCustomerRule_Current PRIMARY KEY
(
company_number,
customer_account,
delivery_sequence,
rule_number
)
);

ALTER TABLE dbo.CRM_BuyingPanelCustomerRule_Current
ADD DEFAULT GETDATE() FOR load_ts;