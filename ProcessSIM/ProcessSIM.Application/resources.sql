USE [DB_processim]
GO
SET IDENTITY_INSERT [dbo].[ResourceCategory] ON 

INSERT [dbo].[ResourceCategory] ([ResourceCategoryId], [ResourceCategoryName]) VALUES (1, N'ПО')
INSERT [dbo].[ResourceCategory] ([ResourceCategoryId], [ResourceCategoryName]) VALUES (2, N'ТО')
INSERT [dbo].[ResourceCategory] ([ResourceCategoryId], [ResourceCategoryName]) VALUES (3, N'Человек')
SET IDENTITY_INSERT [dbo].[ResourceCategory] OFF
SET IDENTITY_INSERT [dbo].[ResourceType] ON 

INSERT [dbo].[ResourceType] ([ResourceTypeId], [ResourceTypeName], [ResourceCategoryId]) VALUES (1, N'САПР', 1)
INSERT [dbo].[ResourceType] ([ResourceTypeId], [ResourceTypeName], [ResourceCategoryId]) VALUES (2, N'Компьютеры', 2)
INSERT [dbo].[ResourceType] ([ResourceTypeId], [ResourceTypeName], [ResourceCategoryId]) VALUES (3, N'Исполнитель', 3)
INSERT [dbo].[ResourceType] ([ResourceTypeId], [ResourceTypeName], [ResourceCategoryId]) VALUES (4, N'Принтер', 2)
SET IDENTITY_INSERT [dbo].[ResourceType] OFF
SET IDENTITY_INSERT [dbo].[Resource] ON 

INSERT [dbo].[Resource] ([ResourceId], [ResourceName], [ResourceTypeId], [ResourceCategoryId], [Price]) VALUES (5, N'Василий', 3, NULL, CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Resource] ([ResourceId], [ResourceName], [ResourceTypeId], [ResourceCategoryId], [Price]) VALUES (6, N'Эдуард', 3, NULL, CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Resource] ([ResourceId], [ResourceName], [ResourceTypeId], [ResourceCategoryId], [Price]) VALUES (7, N'Артемий', 3, NULL, CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Resource] ([ResourceId], [ResourceName], [ResourceTypeId], [ResourceCategoryId], [Price]) VALUES (8, N'Николай', 3, NULL, CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Resource] ([ResourceId], [ResourceName], [ResourceTypeId], [ResourceCategoryId], [Price]) VALUES (9, N'[САПР] Smart Process', 1, NULL, CAST(60000.00 AS Decimal(18, 2)))
INSERT [dbo].[Resource] ([ResourceId], [ResourceName], [ResourceTypeId], [ResourceCategoryId], [Price]) VALUES (10, N'[САПР] Вертикаль', 1, NULL, CAST(50000.00 AS Decimal(18, 2)))
INSERT [dbo].[Resource] ([ResourceId], [ResourceName], [ResourceTypeId], [ResourceCategoryId], [Price]) VALUES (11, N'[САПР] Простая САПР', 1, NULL, CAST(20000.00 AS Decimal(18, 2)))
INSERT [dbo].[Resource] ([ResourceId], [ResourceName], [ResourceTypeId], [ResourceCategoryId], [Price]) VALUES (12, N'Компьютер (2ГБ)', 2, NULL, CAST(30000.00 AS Decimal(18, 2)))
INSERT [dbo].[Resource] ([ResourceId], [ResourceName], [ResourceTypeId], [ResourceCategoryId], [Price]) VALUES (13, N'Компьютер (4ГБ)', 2, NULL, CAST(50000.00 AS Decimal(18, 2)))
INSERT [dbo].[Resource] ([ResourceId], [ResourceName], [ResourceTypeId], [ResourceCategoryId], [Price]) VALUES (14, N'Компьютер (8ГБ)', 2, NULL, CAST(70000.00 AS Decimal(18, 2)))
INSERT [dbo].[Resource] ([ResourceId], [ResourceName], [ResourceTypeId], [ResourceCategoryId], [Price]) VALUES (15, N'Компьютер (16ГБ)', 2, NULL, CAST(90000.00 AS Decimal(18, 2)))
INSERT [dbo].[Resource] ([ResourceId], [ResourceName], [ResourceTypeId], [ResourceCategoryId], [Price]) VALUES (16, N'Принтер (10 стр/мин)', 4, NULL, CAST(10000.00 AS Decimal(18, 2)))
INSERT [dbo].[Resource] ([ResourceId], [ResourceName], [ResourceTypeId], [ResourceCategoryId], [Price]) VALUES (17, N'Принтер (20 стр/мин)', 4, NULL, CAST(20000.00 AS Decimal(18, 2)))
INSERT [dbo].[Resource] ([ResourceId], [ResourceName], [ResourceTypeId], [ResourceCategoryId], [Price]) VALUES (18, N'Принтер (5 стр/мин)', 4, NULL, CAST(5000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Resource] OFF
SET IDENTITY_INSERT [dbo].[ResourceParameter] ON 

INSERT [dbo].[ResourceParameter] ([ResourceParameterId], [ResourceParameterName], [ResourceParameterAlias], [ResourceTypeId]) VALUES (2, N'ram', N'Оперативная память, МБайт', 2)
INSERT [dbo].[ResourceParameter] ([ResourceParameterId], [ResourceParameterName], [ResourceParameterAlias], [ResourceTypeId]) VALUES (3, N'human_experience', N'Опыт', 3)
INSERT [dbo].[ResourceParameter] ([ResourceParameterId], [ResourceParameterName], [ResourceParameterAlias], [ResourceTypeId]) VALUES (4, N'cad_level', N'Уровень САПР', 1)
INSERT [dbo].[ResourceParameter] ([ResourceParameterId], [ResourceParameterName], [ResourceParameterAlias], [ResourceTypeId]) VALUES (5, N'print_speed', N'Скорость печати (стр/мин)', 4)
SET IDENTITY_INSERT [dbo].[ResourceParameter] OFF
SET IDENTITY_INSERT [dbo].[ResourceParameterValue] ON 

INSERT [dbo].[ResourceParameterValue] ([ResourceParameterValueId], [ParameterValue], [ResourceParameterId], [ResourceId]) VALUES (5, N'1', 3, 5)
INSERT [dbo].[ResourceParameterValue] ([ResourceParameterValueId], [ParameterValue], [ResourceParameterId], [ResourceId]) VALUES (6, N'2', 3, 6)
INSERT [dbo].[ResourceParameterValue] ([ResourceParameterValueId], [ParameterValue], [ResourceParameterId], [ResourceId]) VALUES (7, N'3', 3, 7)
INSERT [dbo].[ResourceParameterValue] ([ResourceParameterValueId], [ParameterValue], [ResourceParameterId], [ResourceId]) VALUES (8, N'4', 3, 8)
INSERT [dbo].[ResourceParameterValue] ([ResourceParameterValueId], [ParameterValue], [ResourceParameterId], [ResourceId]) VALUES (9, N'4', 4, 9)
INSERT [dbo].[ResourceParameterValue] ([ResourceParameterValueId], [ParameterValue], [ResourceParameterId], [ResourceId]) VALUES (10, N'3', 4, 10)
INSERT [dbo].[ResourceParameterValue] ([ResourceParameterValueId], [ParameterValue], [ResourceParameterId], [ResourceId]) VALUES (11, N'1', 4, 11)
INSERT [dbo].[ResourceParameterValue] ([ResourceParameterValueId], [ParameterValue], [ResourceParameterId], [ResourceId]) VALUES (12, N'2048', 2, 12)
INSERT [dbo].[ResourceParameterValue] ([ResourceParameterValueId], [ParameterValue], [ResourceParameterId], [ResourceId]) VALUES (13, N'4096', 2, 13)
INSERT [dbo].[ResourceParameterValue] ([ResourceParameterValueId], [ParameterValue], [ResourceParameterId], [ResourceId]) VALUES (14, N'8192', 2, 14)
INSERT [dbo].[ResourceParameterValue] ([ResourceParameterValueId], [ParameterValue], [ResourceParameterId], [ResourceId]) VALUES (15, N'16384', 2, 15)
INSERT [dbo].[ResourceParameterValue] ([ResourceParameterValueId], [ParameterValue], [ResourceParameterId], [ResourceId]) VALUES (16, N'10', 5, 16)
INSERT [dbo].[ResourceParameterValue] ([ResourceParameterValueId], [ParameterValue], [ResourceParameterId], [ResourceId]) VALUES (17, N'20', 5, 17)
INSERT [dbo].[ResourceParameterValue] ([ResourceParameterValueId], [ParameterValue], [ResourceParameterId], [ResourceId]) VALUES (18, N'5', 5, 18)
SET IDENTITY_INSERT [dbo].[ResourceParameterValue] OFF