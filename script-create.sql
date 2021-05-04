CREATE TABLE [dbo].[TipoVacunas] (
    [Id]          CHAR (5) NOT NULL,
    [Descripcion] VARCHAR(255)     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Usuarios] (
	[Documento] VARCHAR (50) NOT NULL,
    [Nombre]    VARCHAR (50) NOT NULL,
    [Password]  VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Documento] ASC)
);

CREATE TABLE [dbo].[Paises]
(
	[CodPais] CHAR(3) NOT NULL PRIMARY KEY, 
    [Nombre] VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE [dbo].[Laboratorios] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]      VARCHAR (50) NOT NULL,
    [PaisOrigen]  CHAR (3)     NOT NULL,
    [Experiencia] BIT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	FOREIGN KEY ([PaisOrigen]) REFERENCES [dbo].[Paises] ([CodPais]),
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
    [ProduccionAnual]    BIGINT         NOT NULL,
    [FaseClinicaAprob]   INT            NOT NULL,
    [Emergencia]         BIT            NOT NULL,
    [EfectosAdversos]    TEXT           NOT NULL,
    [Precio]             DECIMAL (8, 2) DEFAULT ((-1)),
    [UltimaModificacion] DATETIME       NOT NULL,
    [Covax]              BIT            DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Nombre] ASC),
    FOREIGN KEY ([IdTipo]) REFERENCES [dbo].[TipoVacunas] ([Id]),
    FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([Documento])
);

CREATE TABLE [dbo].[StatusVacuna] (
    [IdVac]   INT      NOT NULL,
    [CodPais] CHAR (3) NOT NULL,
    PRIMARY KEY CLUSTERED ([IdVac] ASC, [CodPais] ASC),
    FOREIGN KEY ([IdVac]) REFERENCES [dbo].[Vacunas] ([Id]),
	FOREIGN KEY ([CodPais]) REFERENCES [dbo].[Paises] ([CodPais])
);

CREATE TABLE [dbo].[VacunaLaboratorios]
( 
    [IdVacuna] INT NOT NULL, 
    [IdLaboratorio] INT NOT NULL,
	PRIMARY KEY([IdVacuna],[IdLaboratorio]),
	FOREIGN KEY ([IdVacuna]) REFERENCES Vacunas([Id]),
	FOREIGN KEY ([IdLaboratorio]) REFERENCES Laboratorios([Id])
);

INSERT INTO Paises 
VALUES ('USA','Estados Unidos'),('DEU','Alemania'),('CHN','China'),('SWE','Suecia'),('GBR','Reino Unido'),('URY','Uruguay'),('BRA','Brasil'),('ARG','Argentina'),('ISR','Israel'),('MEX','México'),('RUS', 'Rusia'),('IND', 'India');

INSERT INTO Laboratorios (Nombre, PaisOrigen, Experiencia) 
VALUES ('Moderna','USA',1),('BioNTech','DEU',1),('Pfizer','USA',1),('Sinovac','CHN',1),('Oxford','SWE',1),('Astrazeneca','GBR',1),('Laboratorio Ruso','RUS',1),('laboratorio Indio', 'IND', 1),('Novavax', 'USA', 1);

INSERT INTO TipoVacunas (Id,Descripcion) 
VALUES ('VV','Vector viral'),('mRNA','ARN mensajero'),('IV','Virus inactivo'),('PB','Basado en proteínas');

INSERT INTO Usuarios VALUES
('45544061','Fausto','gHCBvUu6/+H8LO6FLL4MJo469G4='), 
('46902781','Emanuel','7WHutpgHO4comhHzgQnUnZee3vM=');

INSERT INTO Vacunas (idTipo, IdUsuario, Nombre, CantidadDosis, LapsoDiasDosis, MaxEdad, MinEdad, EficaciaPrev, EficaciaHosp, EficaciaCti, MaxTemp, MinTemp, ProduccionAnual, FaseClinicaAprob, Emergencia, EfectosAdversos, Precio, UltimaModificacion,Covax) 
VALUES 
('VV','45544061','Sputnik V', 2, 30, 60, 18, 91.6, 85, 87, 23, 2, 45000000, 4,1, 'Irritaciones de piel, gripe, dolor de cabeza y fatiga', 15,GETDATE(),0),
('IV','45544061','Sinopharm', 2, 45, 90, 15, 79, 87, 85, 25, 0, 19800000, 3,1, 'Fiebre, diarrea, dolor de cabeza', 20,GETDATE(), 0),
('mRNA ','46902781','Moderna',2,90,100,15,94.1,98,100,15, -5, 300000000, 4,1, 'fiebre, escalofríos, cansancio y dolor de cabeza', 23, GETDATE(), 0),
('IV','46902781','Covaxin', 2, 28, 65,12, 81, 85, 90, 8, 2, 20400000, 4,1, 'Fiebre, nausas', 17, GETDATE(), 0),
('VV','46902781','Janssen', 1, 0, 120, 18, 66.3, 70, 68, 12, 2, 45900000, 3, 1, 'Fiebre, gripe severa, calambres', 23, GETDATE(), 0),
('PB','45544061','Novavax', 1, 0, 90, 10, 96.4, 95, 100, 12, 0, 2909990, 3,0, 'Jaqueca, fiebre', 26, GETDATE(), 0),
('PB','45544061' ,'Oxford-Astrazeneca', 2, 90, 90, 15, 70, 65, 73, 18, 5, 54000000, 3, 0, 'Trombosis, fiebre, gripe', 16, GETDATE(), 1),
('mRNA','46902781','Vacunita', 1, 0, 90, 12, 70,78,80, 20, 5, 12300000, 2, 0, 'Diarrea, vomitos, dolor de espalda' , 5, GETDATE(), 1);

INSERT INTO StatusVacuna VALUES
(1,'IND'),
(1, 'RUS'),
(1, 'MEX'), 
(2, 'CHN'),
(2, 'DEU'),
(3, 'CHN'),
(3, 'SWE'),
(4,'USA'),
(4,'SWE'),
(5,'URY'),
(5,'ISR'),
(6,'ARG'),
(6,'CHN'),
(7,'DEU'),
(7,'USA'),
(8,'MEX'),
(8,'GBR');

INSERT INTO VacunaLaboratorios VALUES
(1,7),
(2,4),
(3,1),
(4,8),
(5,5),
(6,9),
(7,5),
(7,6),
(8,2);
