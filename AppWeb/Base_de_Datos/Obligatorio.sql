create database Obligatorio
go

use Obligatorio
go

set language spanish
go

create table Cliente
(
	ci int primary key,
	nombre varchar(30) not null,
	apellido varchar(30)
)
go

create table Telefono
(
	numTel int not null,
	ci int not null references Cliente(ci)
	primary key(numTel, ci)
)
go

create table Tarjeta
(
	NroTarj int identity primary key,
	ci int not null foreign key references Cliente(ci),
	fechaVencimiento datetime not null,
	pers bit
)
go

create table Credito
(
	NroTarj int not null primary key foreign key references Tarjeta(NroTarj),
	cat int not null,
	credito int not null
)
go

create table Debito
(
	NroTarj int not null primary key foreign key references Tarjeta(NroTarj), --Es FK de Tarjeta, al mismo tiempo que es PK de esta entidad
	CantCuentAsoc tinyint not null,
	saldo int not null
)
go

create table Compra
(
	NroCompra int identity(1000,1) primary key,
	NroTarj int not null foreign key references Tarjeta(NroTarj),
	FechaCompra datetime not null,
	ImporteCompra int not null
)
go

--Carga de datos

insert Cliente values(11111111,'Andres','Sueto'),
(22222222,'Lucas','Perez'),
(33333333,'Anibal','Suarez'),
(44444444,'Roberto','Bolaños'),
(55555555,'Joaquin','Sabina'),
(66666666,'Alberto','Rodriguez'),
(77777777,'Sergio','Vazquez'),
(88888888,'Leticia','Sosa'),
(99999999,'Julia','Perez')
go

insert Telefono values(29000001,11111111),
(29000002,22222222),
(98111222,33333333),
(29000003,44444444),
(98222333,55555555),
(98333444,66666666),
(98222444,77777777),
(29000004,88888888),
(47241340,99999999)
go

insert Tarjeta values(11111111,'20/05/2021',0),
(22222222,'08/02/2020',1),
(33333333,'11/07/2020',1),
(44444444,'15/08/2022',0),
(55555555,'23/10/2019',0),
(66666666,'20/04/2023',0),
(77777777,'12/11/2019',1),
(88888888,'03/05/2021',0),
(99999999,'02/06/2022',1),
(11111111,'09/01/2021',1)
go

insert Credito values(1,1,10000),
(2,3,20000),
(3,2,15000),
(4,2,15000)
go

insert Debito values(5,2,6000), 
(6,5,10000),
(7,7,25000),
(8,1,17000),
(9,1,15500)
go

insert Compra values(3, '01/06/2019', 500)
insert Compra values(6, '02/02/2019', 1000)
insert Compra values(6, '03/05/2019', 2000)
go

-------------------------------------------------------------------------------
--Creacion de procesos almacenados

--create proc sp_AgregarCliente
--go

--create proc sp_ModificarCliente
--go

create proc sp_EliminarCliente
@ci int
AS
	declare @NroTarjeta int
	select @NroTarjeta = NroTarj from Tarjeta where Tarjeta.ci = @ci
	if exists (select * from Compra C INNER JOIN Tarjeta T ON C.NroTarj = T.NroTarj where ci = @ci)
		return -2
	else if not exists (select * from Cliente where ci = @ci)
		return -1
	else if not exists (select NroTarj from Compra where NroTarj = @NroTarjeta) and exists (select * from Cliente where ci = @ci)
		begin
			begin tran
				delete Compra where NroTarj = @NroTarjeta
				if @@ERROR <> 0
					begin
						rollback tran
						return -3
					end
				declare @i int
				set @i = 1
				declare @cont int
				set @cont = IDENT_CURRENT('Tarjeta')
				while (@i <= @cont)
					begin
						if exists (select * from Tarjeta T INNER JOIN Credito C ON T.NroTarj = C.NroTarj where ci = @ci)
							begin
								delete Credito where NroTarj = (select T.NroTarj from Tarjeta T INNER JOIN Credito C ON T.NroTarj = C.NroTarj where ci = @ci) 
								if @@ERROR <> 0
									begin
										rollback tran
										return -3
									end
								set @i = @i + 1
							end
						else if exists (select * from Tarjeta T INNER JOIN  Debito D ON T.NroTarj = D.NroTarj where ci = @ci)
							begin
								delete Debito where NroTarj = (select T.NroTarj from Tarjeta T INNER JOIN Debito D ON T.NroTarj = D.NroTarj where ci = @ci)
								if @@ERROR <> 0
									begin
										rollback tran
										return -3
									end
								set @i = @i + 1
							end
						else
							set  @i = @i + 1
					end
				delete Tarjeta where NroTarj = @NroTarjeta
				if @@ERROR <> 0
					begin
						rollback tran
						return -9
					end
				------
				delete Telefono where ci = @ci
				if @@ERROR <> 0
					begin
						rollback tran
						return -3
					end
				delete Cliente where ci = @ci
				if @@ERROR <> 0
					begin
						rollback tran
						return -3
					end
			commit tran
		return 1
		end
go

--Pruebas 
--Eliminacion exitosa (con varias tarjetas ligadas a la CI)
declare @RET int
exec @RET = sp_EliminarCliente 11111111
print 'Resultado: ' + convert(varchar(5),@RET)
go

--CI no existente
declare @RET int
exec @RET = sp_EliminarCliente 12312312
print 'Resultado: ' + convert(varchar(5),@RET)
go

--Tiene compras existentes
declare @RET int
exec @RET = sp_EliminarCliente 33333333
print 'Resultado: ' + convert(varchar(5),@RET)
go
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--create proc sp_AgregarTarjetaCredito
--go

--create proc sp_AgregarTarjetaDebito
--go

--create proc sp_TotalClientes
--go

create proc sp_AgregarCompra
@NumTarjeta int,
@ImporteCompra int
AS
	if exists (select @NumTarjeta from Credito where credito < @ImporteCompra) OR exists (select @NumTarjeta from Debito where saldo < @ImporteCompra)
	begin
		return -1
	end
	else if exists (select * from Tarjeta where NroTarj = @NumTarjeta) and not exists (select * from Tarjeta where NroTarj = @NumTarjeta and fechaVencimiento < getdate()) --Si existe NumTarj se puede avanzar AND Tarjeta no esta vencida
		begin
			begin tran
				if exists (select * from Credito where NroTarj = @NumTarjeta) --Averiguo si es tarjeta de credito
					begin
						if exists (select @NumTarjeta from Credito where credito >= @ImporteCompra) --Chequeo que tenga saldo
							begin
								insert Compra values(@NumTarjeta, getdate(), @ImporteCompra)
								if @@ERROR <> 0
									begin
										rollback tran
										return -1
									end
								update Credito set credito = (credito - @ImporteCompra) where NroTarj = @NumTarjeta --Actualizo el credito de la tarjeta
								if @@ERROR <> 0
									begin
										rollback tran
										return -1
									end
							end
						else if exists (select @NumTarjeta from Debito where saldo >= @ImporteCompra) --Chequeo que tenga saldo
							begin
								insert Compra values(@NumTarjeta, getdate(), @ImporteCompra)
								if @@ERROR <> 0
									begin
										rollback tran
										return -1
									end
								update Debito set saldo = (saldo - @ImporteCompra) where NroTarj = @NumTarjeta --Actualizo el saldo de la tarjeta
								if @@ERROR <> 0
									begin
										rollback tran
										return -1
									end
							end
					end
			commit tran
			return 1
		end
	else
		return -2
go

--Pruebas
--Exitosas
declare @RET int
exec @RET = sp_AgregarCompra 3, 1000
print 'Resultado: ' + convert(varchar(5),@RET)
go

declare @RET int
exec @RET = sp_AgregarCompra 3, 500
print 'Resultado: ' + convert(varchar(5),@RET)
go

--Saldo/Credito insuficiente:
declare @RET int
exec @RET = sp_AgregarCompra 5, 1000000
print 'Resultado: ' + convert(varchar(5),@RET)
go

--Tarjeta vencida / Tarjeta inexistente
declare @RET int
exec @RET = sp_AgregarCompra 20, 1000
print 'Resultado: ' + convert(varchar(5),@RET)
go
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
create proc sp_TotalCompras --ESTE ES EL SP DE TOTAL COMPRAS POR CLIENTE
@ci int
AS
	if exists (select * from Cliente where ci = @ci)
		begin
			select * from Tarjeta T INNER JOIN Compra C ON T.NroTarj = C.NroTarj
			where ci = @ci
		end
	else
		return -1 --ESTO ES UN ERROR SQL
go

--Pruebas
declare @RET int
exec @RET = sp_TotalCompras 66666666, 2019
print 'Resultado: ' + convert(varchar(5), @RET)
go

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
create proc sp_TotalVentas
@FechaIni datetime,
@FechaFin datetime
AS
	declare @RET int
	select @RET = count(*) from Compra
	where FechaCompra between @FechaFin and @FechaIni
	return @RET
go

declare @RET int
exec @RET = sp_TotalVentas '31/12/2019','01/01/2019'
print 'Resultado: ' + convert(varchar(20), @RET)
go

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
create proc sp_ClientesNoRentables
AS
	select top 3 ci
	from Tarjeta T INNER JOIN Compra C ON T.NroTarj = C.NroTarj 
	where year(FechaCompra) = year(getdate())
	group by ci
	order by count(NroCompra) asc
go

exec sp_ClientesNoRentables
go
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

create proc sp_TarjetasVencidas
AS
	select * from Tarjeta
	where fechaVencimiento < GETDATE()
go
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------