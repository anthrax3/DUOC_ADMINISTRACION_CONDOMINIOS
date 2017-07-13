/*==============================================================*/
/* DBMS name:      ORACLE Version 11g                           */
/* Created on:     26-06-2017 1:01:46                           */
/*==============================================================*/


alter table ANUNCIOS
   drop constraint FK_ANUNCIOS_REFERENCE_CONDOMIN;

alter table COMUNA
   drop constraint FK_COMUNA_COMUNA_RE_REGION;

alter table CONDOMINIO
   drop constraint FK_CONDOMIN_CONDOMINI_COMUNA;

alter table ESPACIOS_COMUNES
   drop constraint FK_ESPACIOS_ESPACIOS__CONDOMIN;

alter table GASTO
   drop constraint FK_GASTO_GASTOS_VI_VIVIENDA;

alter table GASTO
   drop constraint FK_GASTO_GASTO_TIP_TIPO_GAS;

alter table LIBRO_SUCESOS
   drop constraint FK_LIBRO_SU_LIBRO_CON_CONDOMIN;

alter table PAGO
   drop constraint FK_PAGO_PAGO_TIPO_TIPO_PAG;

alter table PAGOXGASTO
   drop constraint FK_PAGOXGAS_PAGOXGAST_GASTO;

alter table PAGOXGASTO
   drop constraint FK_PAGOXGAS_PAGOXGAST_PAGO;

alter table RESERVA
   drop constraint FK_RESERVA_RESERVA_E_ESPACIOS;

alter table RESERVA
   drop constraint FK_RESERVA_RESERVA_V_VIVIENDA;

alter table RESIDENTE
   drop constraint FK_RESIDENT_RESIDENTE_PERSONA;

alter table RESIDENTE
   drop constraint FK_RESIDENT_RESIDENTE_VIVIENDA;

alter table USUARIO
   drop constraint FK_USUARIO_USUARIO_P_PERSONA;

alter table USUARIO
   drop constraint FK_USUARIO_USUARIO_T_TIPO_USU;

alter table USUARIO_X_CONDOMINIO
   drop constraint FK_USUARIO__UXC_CONDO_CONDOMIN;

alter table USUARIO_X_CONDOMINIO
   drop constraint FK_USUARIO__UXC_USUAR_USUARIO;

alter table VIVIENDA
   drop constraint FK_VIVIENDA_VIVIENDA__CONDOMIN;

drop table ANUNCIOS cascade constraints;

drop table COMUNA cascade constraints;

drop table CONDOMINIO cascade constraints;

drop table ESPACIOS_COMUNES cascade constraints;

drop table GASTO cascade constraints;

drop table LIBRO_SUCESOS cascade constraints;

drop table PAGO cascade constraints;

drop table PAGOXGASTO cascade constraints;

drop table PERSONA cascade constraints;

drop table REGION cascade constraints;

drop table RESERVA cascade constraints;

drop table RESIDENTE cascade constraints;

drop table TIPO_GASTO cascade constraints;

drop table TIPO_PAGO cascade constraints;

drop table TIPO_USUARIO cascade constraints;

drop table USUARIO cascade constraints;

drop table USUARIO_X_CONDOMINIO cascade constraints;

drop table VIVIENDA cascade constraints;

/*==============================================================*/
/* Table: ANUNCIOS                                              */
/*==============================================================*/
create table ANUNCIOS 
(
   ID_ANUNCIO           INTEGER              not null,
   ID_CONDOMINIO        INTEGER,
   TITULO               VARCHAR2(30),
   CUERPO               VARCHAR2(500),
   REMITENTE            VARCHAR2(50),
   FECHA_ANUNCIO        DATE,
   constraint PK_ANUNCIOS primary key (ID_ANUNCIO)
);

/*==============================================================*/
/* Table: COMUNA                                                */
/*==============================================================*/
create table COMUNA 
(
   ID_COMUNA            INTEGER              not null,
   ID_REGION            INTEGER,
   NOMBRE_COMUNA        VARCHAR2(100),
   constraint PK_COMUNA primary key (ID_COMUNA)
);

/*==============================================================*/
/* Table: CONDOMINIO                                            */
/*==============================================================*/
create table CONDOMINIO 
(
   ID_CONDOMINIO        INTEGER              not null,
   NOMBRE               VARCHAR2(100),
   DIRECCION            VARCHAR2(100),
   NUMERO_DIRECCION     INTEGER,
   ID_COMUNA            INTEGER,
   TELEFONO             INTEGER,
   constraint PK_CONDOMINIO primary key (ID_CONDOMINIO)
);

/*==============================================================*/
/* Table: ESPACIOS_COMUNES                                      */
/*==============================================================*/
create table ESPACIOS_COMUNES 
(
   ID_ESPACIO           INTEGER              not null,
   ID_CONDOMINIO        INTEGER,
   NOMBRE_ESPACIO       VARCHAR2(30),
   DESCRIPCION_ESPACIO  VARCHAR2(150),
   constraint PK_ESPACIOS_COMUNES primary key (ID_ESPACIO)
);

/*==============================================================*/
/* Table: GASTO                                                 */
/*==============================================================*/
create table GASTO 
(
   ID_GASTO             INTEGER              not null,
   NOMBRE_GASTO         VARCHAR2(30),
   DESCRIPCION          VARCHAR2(100),
   FECHA_GASTO          DATE,
   ID_VIVIENDA          INTEGER,
   ID_TIPO_GASTO        INTEGER,
   MONTO_GASTO          INTEGER,
   ESTADO               VARCHAR2(10),
   OBSERVACION          VARCHAR2(150),
   constraint PK_GASTO primary key (ID_GASTO)
);

/*==============================================================*/
/* Table: LIBRO_SUCESOS                                         */
/*==============================================================*/
create table LIBRO_SUCESOS 
(
   ID_SUCESO            INTEGER              not null,
   ID_CONDOMINIO        INTEGER,
   REFERENCIA           VARCHAR2(30),
   DETALLES             VARCHAR2(1000),
   FECHA_SUCESO         DATE,
   constraint PK_LIBRO_SUCESOS primary key (ID_SUCESO)
);

/*==============================================================*/
/* Table: PAGO                                                  */
/*==============================================================*/
create table PAGO 
(
   ID_PAGO              INTEGER              not null,
   ID_TIPO_PAGO         INTEGER,
   MONTO_PAGO           INTEGER,
   DOCUMENTO            VARCHAR2(100),
   FECHA                DATE,
   constraint PK_PAGO primary key (ID_PAGO)
);

/*==============================================================*/
/* Table: PAGOXGASTO                                            */
/*==============================================================*/
create table PAGOXGASTO 
(
   ID_PAGOXGASTO        INTEGER              not null,
   ID_GASTO             INTEGER,
   ID_PAGO              INTEGER,
   constraint PK_PAGOXGASTO primary key (ID_PAGOXGASTO)
);

/*==============================================================*/
/* Table: PERSONA                                               */
/*==============================================================*/
create table PERSONA 
(
   RUT                  INTEGER              not null,
   PRIMER_NOMBRE        VARCHAR2(30),
   SEGUNDO_NOMBRE       VARCHAR2(30),
   APELLIDO_PATERNO     VARCHAR2(30),
   APELLIDO_MATERNO     VARCHAR2(30),
   FECHA_NACIMIENTO     DATE,
   TELEFONO             INTEGER,
   CORREO               VARCHAR2(30),
   SEXO                 CHAR(1),
   constraint PK_PERSONA primary key (RUT)
);

/*==============================================================*/
/* Table: REGION                                                */
/*==============================================================*/
create table REGION 
(
   ID_REGION            INTEGER              not null,
   NOMBRE_REGION        VARCHAR2(100),
   constraint PK_REGION primary key (ID_REGION)
);

/*==============================================================*/
/* Table: RESERVA                                               */
/*==============================================================*/
create table RESERVA 
(
   ID_RESERVA           INTEGER              not null,
   ID_VIVIENDA          INTEGER,
   FECHA_SOLICITUD      DATE,
   FECHA_RESERVADA      DATE,
   ID_ESPACIO           INTEGER,
   ESTADO_RESERVA       VARCHAR2(10),
   constraint PK_RESERVA primary key (ID_RESERVA)
);

/*==============================================================*/
/* Table: RESIDENTE                                             */
/*==============================================================*/
create table RESIDENTE 
(
   ID_RESIDENTE         INTEGER              not null,
   RUT                  INTEGER,
   ID_VIVIENDA          INTEGER,
   FECHA_INGRESO        DATE,
   constraint PK_RESIDENTE primary key (ID_RESIDENTE)
);

/*==============================================================*/
/* Table: TIPO_GASTO                                            */
/*==============================================================*/
create table TIPO_GASTO 
(
   ID_TIPO_GASTO        INTEGER              not null,
   DESCRPCION           VARCHAR2(30),
   constraint PK_TIPO_GASTO primary key (ID_TIPO_GASTO)
);

/*==============================================================*/
/* Table: TIPO_PAGO                                             */
/*==============================================================*/
create table TIPO_PAGO 
(
   ID_TIPO_PAGO         INTEGER              not null,
   DESCRIPCION_TIPO     VARCHAR2(30),
   constraint PK_TIPO_PAGO primary key (ID_TIPO_PAGO)
);

/*==============================================================*/
/* Table: TIPO_USUARIO                                          */
/*==============================================================*/
create table TIPO_USUARIO 
(
   ID_TIPO_USUARIO      INTEGER              not null,
   DESCRIPCION_TIPO     VARCHAR2(30),
   constraint PK_TIPO_USUARIO primary key (ID_TIPO_USUARIO)
);

/*==============================================================*/
/* Table: USUARIO                                               */
/*==============================================================*/
create table USUARIO 
(
   ID_USUARIO           INTEGER              not null,
   ID_TIPO_USUARIO      INTEGER,
   RUT                  INTEGER,
   CLAVE                VARCHAR2(20),
   constraint PK_USUARIO primary key (ID_USUARIO)
);

/*==============================================================*/
/* Table: USUARIO_X_CONDOMINIO                                  */
/*==============================================================*/
create table USUARIO_X_CONDOMINIO 
(
   ID_UXC               INTEGER              not null,
   ID_USUARIO           INTEGER,
   ID_CONDOMINIO        INTEGER,
   constraint PK_USUARIO_X_CONDOMINIO primary key (ID_UXC)
);

/*==============================================================*/
/* Table: VIVIENDA                                              */
/*==============================================================*/
create table VIVIENDA 
(
   ID_VIVIENDA          INTEGER              not null,
   ID_CONDOMINIO        INTEGER,
   NUMERO               VARCHAR2(10),
   NOMBRE_CALLE         VARCHAR2(100),
   PLANTA_UBICACION     VARCHAR2(10),
   constraint PK_VIVIENDA primary key (ID_VIVIENDA)
);

alter table ANUNCIOS
   add constraint FK_ANUNCIOS_REFERENCE_CONDOMIN foreign key (ID_CONDOMINIO)
      references CONDOMINIO (ID_CONDOMINIO);

alter table COMUNA
   add constraint FK_COMUNA_COMUNA_RE_REGION foreign key (ID_REGION)
      references REGION (ID_REGION);

alter table CONDOMINIO
   add constraint FK_CONDOMIN_CONDOMINI_COMUNA foreign key (ID_COMUNA)
      references COMUNA (ID_COMUNA);

alter table ESPACIOS_COMUNES
   add constraint FK_ESPACIOS_ESPACIOS__CONDOMIN foreign key (ID_CONDOMINIO)
      references CONDOMINIO (ID_CONDOMINIO);

alter table GASTO
   add constraint FK_GASTO_GASTOS_VI_VIVIENDA foreign key (ID_VIVIENDA)
      references VIVIENDA (ID_VIVIENDA);

alter table GASTO
   add constraint FK_GASTO_GASTO_TIP_TIPO_GAS foreign key (ID_TIPO_GASTO)
      references TIPO_GASTO (ID_TIPO_GASTO);

alter table LIBRO_SUCESOS
   add constraint FK_LIBRO_SU_LIBRO_CON_CONDOMIN foreign key (ID_CONDOMINIO)
      references CONDOMINIO (ID_CONDOMINIO);

alter table PAGO
   add constraint FK_PAGO_PAGO_TIPO_TIPO_PAG foreign key (ID_TIPO_PAGO)
      references TIPO_PAGO (ID_TIPO_PAGO);

alter table PAGOXGASTO
   add constraint FK_PAGOXGAS_PAGOXGAST_GASTO foreign key (ID_GASTO)
      references GASTO (ID_GASTO);

alter table PAGOXGASTO
   add constraint FK_PAGOXGAS_PAGOXGAST_PAGO foreign key (ID_PAGO)
      references PAGO (ID_PAGO);

alter table RESERVA
   add constraint FK_RESERVA_RESERVA_E_ESPACIOS foreign key (ID_ESPACIO)
      references ESPACIOS_COMUNES (ID_ESPACIO);

alter table RESERVA
   add constraint FK_RESERVA_RESERVA_V_VIVIENDA foreign key (ID_VIVIENDA)
      references VIVIENDA (ID_VIVIENDA);

alter table RESIDENTE
   add constraint FK_RESIDENT_RESIDENTE_PERSONA foreign key (RUT)
      references PERSONA (RUT);

alter table RESIDENTE
   add constraint FK_RESIDENT_RESIDENTE_VIVIENDA foreign key (ID_VIVIENDA)
      references VIVIENDA (ID_VIVIENDA);

alter table USUARIO
   add constraint FK_USUARIO_USUARIO_P_PERSONA foreign key (RUT)
      references PERSONA (RUT);

alter table USUARIO
   add constraint FK_USUARIO_USUARIO_T_TIPO_USU foreign key (ID_TIPO_USUARIO)
      references TIPO_USUARIO (ID_TIPO_USUARIO);

alter table USUARIO_X_CONDOMINIO
   add constraint FK_USUARIO__UXC_CONDO_CONDOMIN foreign key (ID_CONDOMINIO)
      references CONDOMINIO (ID_CONDOMINIO);

alter table USUARIO_X_CONDOMINIO
   add constraint FK_USUARIO__UXC_USUAR_USUARIO foreign key (ID_USUARIO)
      references USUARIO (ID_USUARIO);

alter table VIVIENDA
   add constraint FK_VIVIENDA_VIVIENDA__CONDOMIN foreign key (ID_CONDOMINIO)
      references CONDOMINIO (ID_CONDOMINIO);

