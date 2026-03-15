USE [CRMIntegration]
GO

/****** Object:  Table [dbo].[CRM_CustomerContact_Current]    Script Date: 14/03/2026 09:27:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CRM_CustomerContact_Current](
	[company_number] [varchar](5) NOT NULL,
	[customer_account] [varchar](20) NOT NULL,
	[delivery_sequence] [varchar](10) NOT NULL,
	[contact_type] [varchar](4) NOT NULL,
	[contact_number] [int] NOT NULL,
	[contact_name] [varchar](255) NULL,
	[job_title] [varchar](255) NULL,
	[correspondence_name] [varchar](255) NULL,
	[phone_home] [varchar](50) NULL,
	[phone_preferred] [varchar](50) NULL,
	[phone_office] [varchar](50) NULL,
	[phone_mobile] [varchar](50) NULL,
	[email] [varchar](255) NULL,
	[general_text1] [varchar](255) NULL,
	[general_text2] [varchar](255) NULL,
	[row_hash] [char](32) NOT NULL,
	[load_ts] [datetime2](3) NULL,
 CONSTRAINT [PK_CRM_CustomerContact_Current] PRIMARY KEY CLUSTERED 
(
	[company_number] ASC,
	[customer_account] ASC,
	[delivery_sequence] ASC,
	[contact_type] ASC,
	[contact_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CRM_CustomerContact_Current] ADD  CONSTRAINT [DF_CustomerContact_LoadTS]  DEFAULT (getdate()) FOR [load_ts]
GO


