Create Database Examen_Practico_Danilo_Espinoza_Villalta

use Examen_Practico_Danilo_Espinoza_Villalta
--Creación tabla Usuario
Create table Usuario(
Nombre_Usuario varchar(100) not null,
Contrasenna_Usuario varchar(MAX),
Rol_Id int
)
--Constraint PK_Usuario
alter table Usuario add constraint Pk_Usuario primary key(Nombre_Usuario)

--Tabla Rol
Create table Rol(
Id int identity not null,
Descripcion varchar(100)
)
--Constraint PK_Rol
alter table Rol add constraint Pk_Rol primary key(id)

--Constraint FK_Rol_Usuario
alter table Usuario add constraint Fk_Rol_Usuario foreign key(Rol_Id) references Rol(Id)

--Tabla Permiso
Create table Permiso(
Id int identity not null,
Descripcion varchar(100)
)
--Constraint PK_Rol
alter table Permiso add constraint Pk_Permiso primary key(id)

Create table Rol_Permiso(
Rol_id int not null,
Permiso_id int not null
)
--Constraint PK_Rol
alter table Rol_Permiso add constraint Pk_Rol_Permiso primary key(Rol_id,Permiso_id)

--Constraint FK_Rol_Rol_Permiso
alter table Rol_Permiso add constraint Fk_Rol_Rol_Permiso foreign key(Rol_Id) references Rol(Id)

--Constraint FK_Permiso_Rol_Permiso
alter table Rol_Permiso add constraint Fk_Permiso_Rol_Permiso foreign key(Permiso_Id) references Permiso(Id)


-----Creación objetos----
-----Creación roles----
insert into Rol values('Administrador')
insert into Rol values('Cajero')

-----Creación permiso----
insert into Permiso values('Registrar')
insert into Permiso values('Listar')
insert into Permiso values('Eliminar')
insert into Permiso values('Actualizar')

-----Creación rol_permiso para administrador----
insert into Rol_Permiso values(1,1)
insert into Rol_Permiso values(1,2)
insert into Rol_Permiso values(1,3)
insert into Rol_Permiso values(1,4)

-----Creación rol_permiso para cajero----
insert into Rol_Permiso values(2,2)

-----Creación usuario----
insert into Usuario values('Juan Perez','12345',1)
insert into Usuario values('Maria Perez','12345',2)
