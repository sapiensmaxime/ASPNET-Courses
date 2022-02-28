--
-- Table structure for table `Classes`
--

DROP TABLE IF EXISTS "Classes";
DROP TABLE IF EXISTS "Eleves";

CREATE TABLE `Classes` (
  `ClasseID` INTEGER PRIMARY KEY,
  `NomClasse` nvarchar(45) NOT NULL,
  `NiveauClasse` nvarchar(45) NOT NULL
);
CREATE INDEX "NomClasse" ON "Classes"("NomClasse");

-- --------------------------------------------------------

--
-- Table structure for table `Eleves`
--

CREATE TABLE `Eleves` (
  `EleveID` INTEGER PRIMARY KEY,
  `NomEleve` nvarchar(45) NOT NULL,
  `PrenomEleve` nvarchar(45) NOT NULL,
  `ClasseID` "int" NULL,
  CONSTRAINT "FK_Eleves_Classes" FOREIGN KEY 
  (
    "ClasseID"
  ) REFERENCES "Classes" (
    "ClasseID"
  )
);
CREATE INDEX "ClasseID" ON "Eleves"("ClasseID");
CREATE INDEX "NomEleve" ON "Eleves"("NomEleve");


INSERT INTO "Classes" VALUES(1, 'A', 'bac + 2' );
INSERT INTO "Classes" VALUES(2, 'B', 'bac + 3' );
INSERT INTO "Classes" VALUES(3, 'C', 'bac + 4' );

INSERT INTO "Eleves" VALUES(1, 'ABSCHEN', 'Jean', 1 );
INSERT INTO "Eleves" VALUES(2, 'ADAMO', 'Stéphane', 1 );
INSERT INTO "Eleves" VALUES(3, 'AMELLAL', 'Viviane', 1 );
INSERT INTO "Eleves" VALUES(4, 'ANGONIN', 'Jean-Pierre', 1 );
INSERT INTO "Eleves" VALUES(5, 'AZOURA', 'Marie-France', 1 );
INSERT INTO "Eleves" VALUES(6, 'AZRIA', 'Maryse', 1 );
INSERT INTO "Eleves" VALUES(7, 'BACH', 'Sylvie', 1 );
INSERT INTO "Eleves" VALUES(8, 'BARNAUD', 'Janine', 1 );
INSERT INTO "Eleves" VALUES(9, 'BENSIMHON', 'Pascal', 1 );
INSERT INTO "Eleves" VALUES(10, 'BERTRAND', 'Roger', 1 );

INSERT INTO "Eleves" VALUES(11, 'BOUDART', 'Orianne', 2 );
INSERT INTO "Eleves" VALUES(12, 'BOULLICAUD', 'Paul', 2 );
INSERT INTO "Eleves" VALUES(13, 'BOUSLAH', 'Fabien', 2 );
INSERT INTO "Eleves" VALUES(14, 'BOUZCKAR', 'Ghislaine', 2 );
INSERT INTO "Eleves" VALUES(15, 'BOVERO', 'Gilbert', 2 );
INSERT INTO "Eleves" VALUES(16, 'BRELEUR', 'Christophe', 2 );
INSERT INTO "Eleves" VALUES(17, 'CERCOTTE', 'Marie-Isabelle', 2 );
INSERT INTO "Eleves" VALUES(18, 'CHI', 'Nicole', 2 );
INSERT INTO "Eleves" VALUES(19, 'CHICHE', 'Vincent', 2 );
INSERT INTO "Eleves" VALUES(20, 'COBHEN', 'Gaylord', 2 );

INSERT INTO "Eleves" VALUES(21, 'DUPRÉ', 'Sophie', 3 );
INSERT INTO "Eleves" VALUES(22, 'EGREVE', 'Jean-René', 3 );
INSERT INTO "Eleves" VALUES(23, 'FALZON', 'Patricia', 3 );
INSERT INTO "Eleves" VALUES(24, 'FAUCHEUX', 'Michel', 3 );
INSERT INTO "Eleves" VALUES(25, 'FEBVRE', 'Denis', 3 );
INSERT INTO "Eleves" VALUES(26, 'FERNANDEZ', 'Yvette', 3 );
INSERT INTO "Eleves" VALUES(27, 'FERNANDEZ', 'Yvette', 3 );
INSERT INTO "Eleves" VALUES(28, 'FERRAND', 'Sophie', 3 );
INSERT INTO "Eleves" VALUES(29, 'FILLEAU', 'Sylvie', 3 );
INSERT INTO "Eleves" VALUES(30, 'FITOUSSI', 'Samuel', 3 );


