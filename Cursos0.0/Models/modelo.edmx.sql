
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/21/2023 00:48:57
-- Generated from EDMX file: D:\Users\Usuario Dell\Desktop\Cursos0.0\Cursos0.0\Models\modelo.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Cursos];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Instructor_Id] int  NOT NULL,
    [Estudiante_Id] int  NOT NULL
);
GO

-- Creating table 'Instructores'
CREATE TABLE [dbo].[Instructores] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Idio_Cult] nvarchar(max)  NOT NULL,
    [Experiencia] nvarchar(max)  NOT NULL,
    [Disponibilidad] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [ImagIns] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Estudiantes'
CREATE TABLE [dbo].[Estudiantes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Idio_Cult] nvarchar(max)  NOT NULL,
    [Nivel] nvarchar(max)  NOT NULL,
    [ImagEst] nvarchar(max)  NOT NULL,
    [DetCrs_Est_Id] int  NOT NULL,
    [ResultadoEva_Id] int  NOT NULL
);
GO

-- Creating table 'Cursos'
CREATE TABLE [dbo].[Cursos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Nivel] nvarchar(max)  NOT NULL,
    [TpCurso] nvarchar(max)  NOT NULL,
    [ImagCrs] nvarchar(max)  NOT NULL,
    [VideoIntr] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [InstructorId] int  NOT NULL,
    [DetCrs_Est_Id] int  NOT NULL
);
GO

-- Creating table 'DetCrs_Est'
CREATE TABLE [dbo].[DetCrs_Est] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Lecciones'
CREATE TABLE [dbo].[Lecciones] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Contenido] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [VideoLec] nvarchar(max)  NOT NULL,
    [DocumentoLec] nvarchar(max)  NOT NULL,
    [ImagLec] nvarchar(max)  NOT NULL,
    [CursoId] int  NOT NULL
);
GO

-- Creating table 'Evaluaciones'
CREATE TABLE [dbo].[Evaluaciones] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [DocumentoEva] nvarchar(max)  NOT NULL,
    [LeccionId] int  NOT NULL
);
GO

-- Creating table 'ResultadosEva'
CREATE TABLE [dbo].[ResultadosEva] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Comentario] nvarchar(max)  NOT NULL,
    [Valoracion] nvarchar(max)  NOT NULL,
    [EstudianteId] int  NOT NULL,
    [Evaluacion_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Instructores'
ALTER TABLE [dbo].[Instructores]
ADD CONSTRAINT [PK_Instructores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Estudiantes'
ALTER TABLE [dbo].[Estudiantes]
ADD CONSTRAINT [PK_Estudiantes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cursos'
ALTER TABLE [dbo].[Cursos]
ADD CONSTRAINT [PK_Cursos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DetCrs_Est'
ALTER TABLE [dbo].[DetCrs_Est]
ADD CONSTRAINT [PK_DetCrs_Est]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Lecciones'
ALTER TABLE [dbo].[Lecciones]
ADD CONSTRAINT [PK_Lecciones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Evaluaciones'
ALTER TABLE [dbo].[Evaluaciones]
ADD CONSTRAINT [PK_Evaluaciones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ResultadosEva'
ALTER TABLE [dbo].[ResultadosEva]
ADD CONSTRAINT [PK_ResultadosEva]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Instructor_Id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [FK_UsuarioInstructor]
    FOREIGN KEY ([Instructor_Id])
    REFERENCES [dbo].[Instructores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioInstructor'
CREATE INDEX [IX_FK_UsuarioInstructor]
ON [dbo].[Usuarios]
    ([Instructor_Id]);
GO

-- Creating foreign key on [Estudiante_Id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [FK_UsuarioEstudiante]
    FOREIGN KEY ([Estudiante_Id])
    REFERENCES [dbo].[Estudiantes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioEstudiante'
CREATE INDEX [IX_FK_UsuarioEstudiante]
ON [dbo].[Usuarios]
    ([Estudiante_Id]);
GO

-- Creating foreign key on [InstructorId] in table 'Cursos'
ALTER TABLE [dbo].[Cursos]
ADD CONSTRAINT [FK_InstructorCurso]
    FOREIGN KEY ([InstructorId])
    REFERENCES [dbo].[Instructores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InstructorCurso'
CREATE INDEX [IX_FK_InstructorCurso]
ON [dbo].[Cursos]
    ([InstructorId]);
GO

-- Creating foreign key on [DetCrs_Est_Id] in table 'Estudiantes'
ALTER TABLE [dbo].[Estudiantes]
ADD CONSTRAINT [FK_EstudianteDetCrs_Est]
    FOREIGN KEY ([DetCrs_Est_Id])
    REFERENCES [dbo].[DetCrs_Est]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EstudianteDetCrs_Est'
CREATE INDEX [IX_FK_EstudianteDetCrs_Est]
ON [dbo].[Estudiantes]
    ([DetCrs_Est_Id]);
GO

-- Creating foreign key on [DetCrs_Est_Id] in table 'Cursos'
ALTER TABLE [dbo].[Cursos]
ADD CONSTRAINT [FK_CursoDetCrs_Est]
    FOREIGN KEY ([DetCrs_Est_Id])
    REFERENCES [dbo].[DetCrs_Est]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CursoDetCrs_Est'
CREATE INDEX [IX_FK_CursoDetCrs_Est]
ON [dbo].[Cursos]
    ([DetCrs_Est_Id]);
GO

-- Creating foreign key on [CursoId] in table 'Lecciones'
ALTER TABLE [dbo].[Lecciones]
ADD CONSTRAINT [FK_CursoLeccion]
    FOREIGN KEY ([CursoId])
    REFERENCES [dbo].[Cursos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CursoLeccion'
CREATE INDEX [IX_FK_CursoLeccion]
ON [dbo].[Lecciones]
    ([CursoId]);
GO

-- Creating foreign key on [LeccionId] in table 'Evaluaciones'
ALTER TABLE [dbo].[Evaluaciones]
ADD CONSTRAINT [FK_LeccionEvaluacion]
    FOREIGN KEY ([LeccionId])
    REFERENCES [dbo].[Lecciones]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LeccionEvaluacion'
CREATE INDEX [IX_FK_LeccionEvaluacion]
ON [dbo].[Evaluaciones]
    ([LeccionId]);
GO

-- Creating foreign key on [Evaluacion_Id] in table 'ResultadosEva'
ALTER TABLE [dbo].[ResultadosEva]
ADD CONSTRAINT [FK_EvaluacionResultadoEva]
    FOREIGN KEY ([Evaluacion_Id])
    REFERENCES [dbo].[Evaluaciones]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EvaluacionResultadoEva'
CREATE INDEX [IX_FK_EvaluacionResultadoEva]
ON [dbo].[ResultadosEva]
    ([Evaluacion_Id]);
GO

-- Creating foreign key on [ResultadoEva_Id] in table 'Estudiantes'
ALTER TABLE [dbo].[Estudiantes]
ADD CONSTRAINT [FK_EstudianteResultadoEva]
    FOREIGN KEY ([ResultadoEva_Id])
    REFERENCES [dbo].[ResultadosEva]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EstudianteResultadoEva'
CREATE INDEX [IX_FK_EstudianteResultadoEva]
ON [dbo].[Estudiantes]
    ([ResultadoEva_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------