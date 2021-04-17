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
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]           VARCHAR (50)   NOT NULL,
    [IdTipo]           CHAR (5)       NULL,
    [CantidadDosis]    INT            NOT NULL,
    [LapsoDiasDosis]   INT            DEFAULT ((0)) NOT NULL,
    [MaxEdad]          VARCHAR (50)   NOT NULL,
    [MinEdad]          VARCHAR (50)   NOT NULL,
    [EficaciaPrev]     INT            NOT NULL,
    [EficaciaHosp]     INT            NOT NULL,
    [EficaciaCti]      INT            NOT NULL,
    [MaxTemp]          VARCHAR (50)   NOT NULL,
    [MinTemp]          VARCHAR (50)   NOT NULL,
    [ProduccionAnual]  INT            NOT NULL,
    [FaseClinicaAprob] INT            NOT NULL,
    [Emergencia]       BIT            NOT NULL,
    [EfectosAdversos]  TEXT           NOT NULL,
    [Precio]           DECIMAL (8, 2) NOT NULL,
    [IdUsuario]        VARCHAR (50)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([IdTipo]) REFERENCES [dbo].[TipoVacunas] ([Id]),
    FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([Documento])
);



CREATE TABLE [dbo].[Status](
	[IdVac] INT NOT NULL, 
    [CodPais] CHAR(3) NOT NULL,
	PRIMARY KEY(IdVac,CodPais),
	FOREIGN KEY ([IdVac]) REFERENCES Vacunas([Id])
);

CREATE TABLE [dbo].[Table]
( 
    [IdVacuna] INT NOT NULL, 
    [IdLaboratorio] INT NOT NULL,
	PRIMARY KEY([IdVacuna],[IdLaboratorio]),
	FOREIGN KEY ([IdVacuna]) REFERENCES Vacunas([Id]),
	FOREIGN KEY ([IdLaboratorio]) REFERENCES Laboratorios([Id])
);