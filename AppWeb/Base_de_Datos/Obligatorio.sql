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
	CantCuentAsoc int not null,
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

create proc sp_AgregarCliente
@ci int,
@nombre varchar(30),
@apellido varchar(30)
AS
	insert Cliente values(@ci, @nombre, @apellido)
go

exec sp_ModificarCliente 1, 
create proc sp_ModificarCliente
@ci int,
@nombre varchar(30),
@apellido varchar(30),

@numTel int
AS
	if exists (select * from Cliente where ci = @ci)
	begin
		BEGIN TRAN
		update Cliente set nombre = @nombre, apellido = @apellido
		where ci = @ci
		if (@@ERROR<>0)
			begin
				rollback tran
				return -2 --Esto es, error de transaccion
			end
		update Telefono set numTel = @numTel
		where ci = @ci
		if (@@ERROR<>0)
			begin
				rollback tran
				return -2 --Esto es, error de transaccion
			end
		COMMIT TRAN
		return 1 --Esto es, modificacion exitosa
	end
	else
		return -1 --Esto es, no existe un cliente con esa CI
go

select * from Cliente where ci = 1
exec sp_EliminarCliente 1
alter proc sp_EliminarCliente
@ci int
AS
	if exists (select * from Cliente where ci = @ci)
	begin
	if exists (select * from Tarjeta where Tarjeta.ci = @ci)
	begin
		if not exists (select * from Compra JOIN Tarjeta ON Compra.NroTarj = Tarjeta.NroTarj where Tarjeta.ci = @ci) --Si no tiene compras
		begin
			if exists (select * from Credito C JOIN Tarjeta T ON C.NroTarj = T.NroTarj where T.ci = @ci) or exists (select * from Debito D JOIN Tarjeta T ON D.NroTarj = T.NroTarj where T.ci = @ci)
				begin
				BEGIN TRAN
				delete Credito from Credito C JOIN Tarjeta T ON C.NroTarj = T.NroTarj where T.ci = @ci
				if @@ERROR <> 0
					begin
						rollback tran
						return -9
					end
				delete Debito from Debito D JOIN Tarjeta T ON D.NroTarj = T.NroTarj where T.ci = @ci
				if @@ERROR <> 0
					begin
						rollback tran
						return -9
					end
				COMMIT TRAN
				return 1
				end
				delete Tarjeta where Tarjeta.ci = @ci
				if @@ERROR <> 0
					begin
						rollback tran
						return -9
					end
				------
				delete Cliente where ci = @ci
				if @@ERROR <> 0
					begin
						rollback tran
						return -3
					end
				
			end
			else 
				return -2 --No tiene tarjetas para eliminar
		end
		else if not exists (select * from Tarjeta where ci = @ci)
		begin
			BEGIN TRAN
			delete Cliente where ci = @ci
			if @@ERROR <> 0
				begin
					rollback tran
					return -3
				end
			COMMIT TRAN
			return 1
		end
		else
			return -3 --No se puede borrar porque tiene compras
	end
	else
		return -1
go

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
create proc sp_ListarClientes
AS
	select * from Cliente
go
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
create proc sp_BuscarCliente
@ci int
AS
	select * from Cliente where ci = @ci
go
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

create proc sp_AgregarTarjetaCredito
@ci int,
@fechaVencimiento datetime,
@pers bit,

@cat int,
@credito int
AS
	if not exists (select * from Cliente where ci = @ci)
		return -1 --Esto es, no existe cliente
	else
	begin
		declare @NroTarj int
		BEGIN TRAN
			insert Tarjeta values(@ci, @fechaVencimiento, @pers)
			if (@@ERROR <> 0)
			begin
				rollback tran
				return -2 --Esto es, error de transaccion
			end
			set @NroTarj = @@IDENTITY
			insert Credito values(@NroTarj, @cat, @credito)
			if (@@ERROR <> 0)
			begin
				rollback tran
				return -2 --Esto es, error de transaccion
			end
		COMMIT TRAN
		return 1 --Esto es, operacion exitosa
	end
go

create proc sp_AgregarTarjetaDebito
@ci int,
@fechaVencimiento datetime,
@pers bit,

@CantCuentAsoc int,
@saldo int
AS
	if not exists (select * from Cliente where ci = @ci)
		return -1 --Esto es, no existe cliente
	else
	begin
		declare @NroTarj int
		BEGIN TRAN
			insert Tarjeta values(@ci, @fechaVencimiento, @pers)
			if (@@ERROR <> 0)
			begin
				rollback tran
				return -2 --Esto es, error de transaccion
			end
			set @NroTarj = @@IDENTITY
			insert Debito values(@NroTarj, @CantCuentAsoc, @saldo)
			if (@@ERROR <> 0)
			begin
				rollback tran
				return -2 --Esto es, error de transaccion
			end
		COMMIT TRAN
		return 1 --Esto es, operacion exitosa
	end
go

create proc sp_TotalClientes
AS
	if exists (select * from Cliente)
		select * from Cliente
	else
		return -1 --Esto es, aun no hay clientes cargados en el sistema
go

create proc sp_AgregarCompra
@NumTarjeta int,
@FechaCompra datetime,
@ImporteCompra int
AS
	if exists (select @NumTarjeta from Credito where credito < @ImporteCompra) OR exists (select @NumTarjeta from Debito where saldo < @ImporteCompra)
	begin
		return -1
	end
	else if exists (select * from Tarjeta where NroTarj = @NumTarjeta) and not exists (select * from Tarjeta where NroTarj = @NumTarjeta and fechaVencimiento < getdate()) --Si existe NumTarj se puede avanzar AND Tarjeta no esta vencida
		begin
				if exists (select * from Credito where NroTarj = @NumTarjeta) --Averiguo si es tarjeta de credito
					begin
						if exists (select @NumTarjeta from Credito where credito >= @ImporteCompra) --Chequeo que tenga saldo
							begin
								BEGIN TRAN
								insert Compra values(@NumTarjeta, @FechaCompra, @ImporteCompra)
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
								COMMIT TRAN
								return 1
							end
						else if exists (select @NumTarjeta from Debito where saldo >= @ImporteCompra) --Chequeo que tenga saldo
							begin
								BEGIN TRAN
								insert Compra values(@NumTarjeta, @FechaCompra, @ImporteCompra)
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
								COMMIT TRAN
								return 1
							end
					end
			return 1
		end
	else
		return -2
go

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
create proc sp_BuscarCompra
@ci int
AS
	select * from Compra INNER JOIN Tarjeta ON Compra.NroTarj = Tarjeta.NroTarj where Tarjeta.ci = @ci
go
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
create proc sp_TotalComprasXCliente --ESTE ES EL SP DE TOTAL COMPRAS POR CLIENTE
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

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
create proc sp_ListarCompras
AS
	select * from Compra
	if(@@ERROR<>0)
		return -1 --Esto es, error SQL
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

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

create proc sp_TarjetasVencidas
AS
	if exists (select * from Tarjeta)
	begin
		select * from Tarjeta
		where fechaVencimiento < GETDATE()
	end
	else
		return -1 --Esto es, aun no existen tarjetas cargadas en el sistema
go
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

create proc sp_CreditoVencidas
AS
	if exists (select * from Tarjeta)
	begin
		select * from Tarjeta T INNER JOIN Credito C ON T.NroTarj = C.NroTarj
		where fechaVencimiento < GETDATE()
	end
	else
		return -1 --Esto es, aun no existen tarjetas cargadas en el sistema
go
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

create proc sp_DebitoVencidas
AS
	if exists (select * from Tarjeta)
	begin
		select * from Tarjeta T INNER JOIN Debito D ON T.NroTarj = D.NroTarj
		where fechaVencimiento < GETDATE()
	end
	else
		return -1 --Esto es, aun no existen tarjetas cargadas en el sistema
go
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
create proc sp_CreditoXCliente
@ci int
AS
	if exists(select * from Credito)
	begin
		select * from Tarjeta T INNER JOIN Credito C ON T.NroTarj = C.NroTarj
		where ci = @ci
	end
	else
		return -1 --Esto es, aun no existen tarjetas de credito cargadas en el sistema
go

create proc sp_DebitoXCliente
@ci int
AS
	if exists(select * from Debito)
	begin
		select * from Tarjeta T INNER JOIN Debito D ON T.NroTarj = D.NroTarj
		where ci = @ci
	end
	else
		return -1 --Esto es, aun no existen tarjetas de debito cargadas en el sistema
go