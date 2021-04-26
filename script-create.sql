CREATE TABLE [dbo].[TipoVacunas] (
    [Id]          CHAR (5) NOT NULL,
    [Descripcion] TEXT     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Usuarios] (
	[Documento] VARCHAR (50) NOT NULL,
    [Nombre]    VARCHAR (50) NOT NULL,
    [Password]  VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Documento] ASC)
);

CREATE TABLE [dbo].[Laboratorios] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]      VARCHAR (50) NOT NULL,
    [PaisOrigen] CHAR (3)     NOT NULL,
    [Experiencia] BIT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Nombre] ASC)
);

CREATE TABLE [dbo].[Vacunas] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [IdTipo]             CHAR (5)       NOT NULL,
    [IdUsuario]          VARCHAR (50)   NOT NULL,
    [Nombre]             VARCHAR (50)   NOT NULL,
    [CantidadDosis]      INT            NOT NULL,
    [LapsoDiasDosis]     INT            DEFAULT ((0)) NOT NULL,
    [MaxEdad]            INT            NOT NULL,
    [MinEdad]            INT            NOT NULL,
    [EficaciaPrev]       INT            NOT NULL,
    [EficaciaHosp]       INT            NOT NULL,
    [EficaciaCti]        INT            NOT NULL,
    [MaxTemp]            INT            NOT NULL,
    [MinTemp]            INT            NOT NULL,
    [ProduccionAnual]    INT            NOT NULL,
    [FaseClinicaAprob]   INT            NOT NULL,
    [Emergencia]         BIT            NOT NULL,
    [EfectosAdversos]    TEXT           NOT NULL,
    [Precio]             DECIMAL (8, 2) DEFAULT ((-1)) NOT NULL,
    [UltimaModificacion] DATETIME       NOT NULL,
    [Covax]              BIT            DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Nombre] ASC),
    FOREIGN KEY ([IdTipo]) REFERENCES [dbo].[TipoVacunas] ([Id]),
    FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([Documento])
);

CREATE TABLE [dbo].[Status](
	[IdVac] INT NOT NULL, 
    [CodPais] CHAR(3) NOT NULL,
	PRIMARY KEY(IdVac,CodPais),
	FOREIGN KEY ([IdVac]) REFERENCES Vacunas([Id])
);

CREATE TABLE [dbo].[VacunaLaboratorios]
( 
    [IdVacuna] INT NOT NULL, 
    [IdLaboratorio] INT NOT NULL,
	PRIMARY KEY([IdVacuna],[IdLaboratorio]),
	FOREIGN KEY ([IdVacuna]) REFERENCES Vacunas([Id]),
	FOREIGN KEY ([IdLaboratorio]) REFERENCES Laboratorios([Id])
);

INSERT INTO Laboratorios (Nombre, PaisOrigen, Experiencia) 
VALUES ('Moderna','USA',1),('BioNTech','DEU',1),('Pfizer','USA',1),('Sinovac','CHN',1),('Oxford','SWE',1),('Astrazeneca','GBR',1);

INSERT INTO TipoVacunas (Id,Descripcion) 
VALUES ('VV','Vector viral'),('mRNA','ARN mensajero'),('IV','Virus inactivo'),('PB','Basado en proteínas');