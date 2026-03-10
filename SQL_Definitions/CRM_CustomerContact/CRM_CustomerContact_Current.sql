USE [CRMIntegration]
GO

/****** Object:  Table [dbo].[CRM_CustomerContact_Current]    Script Date: 10/03/2026 13:23:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CRM_CustomerContact_Current](
	[company_number] [varchar](5) NOT NULL,
	[customer_account] [varchar](8) NOT NULL,
	[delivery_sequence] [varchar](3) NOT NULL,
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
	[general_text2] [varchar](255) NULL
) ON [PRIMARY]
GO


