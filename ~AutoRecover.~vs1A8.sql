create table Usuario (
Id_usuario int not null,
Contraseña_usuario varchar (30) not null,
Tipo_usuario varchar (20)not null,
primary key (Id_usuario))

create table bebida(
Codigo_bebida numeric not null,
Nombre_bebida varchar(20) not null,
Precio_bebida float  not null,
primary key  (Codigo_bebida))


create table plato(
Codigo_plato numeric  not null,
Nombre_plato varchar(20) not null,
Precio_plato float not null,
primary key (Codigo_plato))

create table pedido(
id_pedido numeric not null,
nombre_plato varchar(30) not null,
cantidad_plato int not null,
precio_plato int not null,
nombre_bebida varchar(30) not null,
cantidad_bebida int not null,
precio_bebida int not null,
codigo_mesa numeric not null,
codigo_mesero numeric not null,
fecha_pedido varchar(30) not null,
primary key (id_pedido)) 

select*from pedido



select*from plato



selec
from 

select*from mesa

select*from mesero

insert into Usuario(Id_usuario,Contraseña_usuario,Tipo_usuario)
values (1001834177,'gokuesmipapá','cajero')

insert into Usuario(Id_usuario,Contraseña_usuario,Tipo_usuario)
values (1048435447,'SEBASTIAN','cajero')

insert into Usuario(id_usuario,Contraseña_usuario,Tipo_usuario)
values (1003126680,'Llorente','administrador')

SELECT*FROM Usuario

select*from mesero

select*from pedido

selec
from 
