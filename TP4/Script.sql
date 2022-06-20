CREATE DATABASE GIMNASIO
GO
USE GIMNASIO
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[NOMBRE] [varchar](50) NOT NULL,
	[APELLIDO] [varchar](50) NOT NULL,
	[EDAD] [int] NOT NULL,
	[DNI] [int] PRIMARY KEY NOT NULL,
	[PLAN_GIMNASIO] [INT] 
) ON [PRIMARY]
GO

insert into Clientes (NOMBRE, APELLIDO, EDAD, DNI, PLAN_GIMNASIO) values ('Robertini', 'Mcgil', 35, '42385607', 0);
insert into Clientes (NOMBRE, APELLIDO, EDAD, DNI, PLAN_GIMNASIO) values ('Papano', 'Robert', 12, '13495760', 1);
insert into Clientes (NOMBRE, APELLIDO, EDAD, DNI, PLAN_GIMNASIO) values ('Carlos', 'Gonzalez', 90, '42315607', 2);
insert into Clientes (NOMBRE, APELLIDO, EDAD, DNI, PLAN_GIMNASIO) values ('Pepe', 'Pepardo', 20, '42567807', 0);
insert into Clientes (NOMBRE, APELLIDO, EDAD, DNI, PLAN_GIMNASIO) values ('Roberto', 'Maldini', 24, '30225607', 1);
insert into Clientes (NOMBRE, APELLIDO, EDAD, DNI, PLAN_GIMNASIO) values ('Kaka', 'Hulkeano', 38, '90892345', 2);
insert into Clientes (NOMBRE, APELLIDO, EDAD, DNI, PLAN_GIMNASIO) values ('Martin', 'Benitez', 44, '12335607', 0);
insert into Clientes (NOMBRE, APELLIDO, EDAD, DNI, PLAN_GIMNASIO) values ('Teofilo', 'Sacado', 49, '93023607', 1);
insert into Clientes (NOMBRE, APELLIDO, EDAD, DNI, PLAN_GIMNASIO) values ('Mariano', 'Marianitis', 55, '12345678', 2);
insert into Clientes (NOMBRE, APELLIDO, EDAD, DNI, PLAN_GIMNASIO) values ('Sergio', 'Lahipotermia', 59, '87654321', 0);
insert into Clientes (NOMBRE, APELLIDO, EDAD, DNI, PLAN_GIMNASIO) values ('Pablo', 'Mirano', 79, '12344321', 1);
insert into Clientes (NOMBRE, APELLIDO, EDAD, DNI, PLAN_GIMNASIO) values ('Nadia', 'Nadina', 12, '12345432', 2);

