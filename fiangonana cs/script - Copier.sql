CREATE DATABASE fiangonana
go 

USE fiangonana
go    

CREATE TABLE mpiangona (
    idMpiangona int primary key,
    nom varchar(50),
    prenom varchar(50),
    dateNaissance date,
    adresse varchar(50),
    email varchar(50),
    mdp varchar(64),
    role varchar(20)
);
go

CREATE TABLE dimanche(
    idDimanche int primary key,
    numeroDimanche int,
    annee int,
    typeDimanche varchar(10)
);
go

CREATE TABLE rakitra(
    idRakitra int primary key,
    idDimanche int,
    montant decimal(11,2),
    foreign key (idDimanche) references dimanche(idDimanche)
);
go

CREATE TABLE demandePret(
    idDemande int primary key,
    idMpiangona int,
    idDimanche int,
    montant decimal(11,2),
    dureeRemboursement int,
    foreign key (idMpiangona) references mpiangona(idMpiangona),
    foreign key (idDimanche) references dimanche(idDimanche)
);
go

CREATE TABLE detailsRemboursement(
    idDetail int primary key,
    idDemande int,
    numeroDimanche int,
    annee int,
    montant decimal(11,2),
    foreign key (idDemande) references demandePret(idDemande)
);
go

CREATE TABLE pretEnCours(
    idPretEnCours int primary key,
    idDemande int, 
    numeroDimanche int,
    annee int,         
    montant decimal(11,2),
    foreign key (idDemande) references demandePret(idDemande)
);
go

CREATE TABLE categorie(
    idCategorie int,
    nom varchar(30),
    type varchar(10),
    frequence int,
    primary key(idcategorie)
);
go

CREATE TABLE depenseFixe(
    idFixe int primary key,
    idCategorie int,
    montant decimal(11,2),
    foreign key (idCategorie) references categorie(idCategorie)
);
go

CREATE TABLE depenseVariable(
    idVariable int primary key,
    idCategorie int,
    mois int, 
    annee int,
    montant decimal(11,2),
    foreign key (idCategorie) references categorie(idCategorie)
);
go

CREATE SEQUENCE seq_mpiangona
MINVALUE 1
START WITH 1
INCREMENT BY 1;
go

CREATE SEQUENCE seq_dimanche
MINVALUE 1
START WITH 1
INCREMENT BY 1;
go

CREATE SEQUENCE seq_rakitra
MINVALUE 1
START WITH 1
INCREMENT BY 1;
go

CREATE SEQUENCE seq_demandePret
MINVALUE 1
START WITH 1
INCREMENT BY 1;
go

CREATE SEQUENCE seq_detailsRemboursement
MINVALUE 1
START WITH 1
INCREMENT BY 1;
go

CREATE SEQUENCE seq_pretEnCours
MINVALUE 1
START WITH 1
INCREMENT BY 1;
go

CREATE SEQUENCE seq_categorie
MINVALUE 1
START WITH 1
INCREMENT BY 1;
go

CREATE SEQUENCE seq_fixe
MINVALUE 1
START WITH 1
INCREMENT BY 1;
go

CREATE SEQUENCE seq_variable
MINVALUE 1
START WITH 1
INCREMENT BY 1;
go


-- to get the current value of a sequence
-- SELECT current_value FROM sys.sequences WHERE name = 'seq_mpiangona' ;

INSERT INTO mpiangona VALUES (NEXT VALUE FOR seq_mpiangona, 'Miarantsoa', 'Ainaharison', '2005-04-27', 'Lot II H 40 Bis', 'miarantsoa@itu.mg', '090b235e9eb8f197f2dd927937222c570396d971222d9009a9189e2b6cc0a2c1', 'kristianina')
go

INSERT INTO mpiangona VALUES (NEXT VALUE FOR seq_mpiangona, 'Bob', 'Denary', '2004-03-26', 'Lot III T', 'bobdenary@itu.mg', 'ca16cdf9827c1c1f7dd8dcd389af051e86d6155c82ac82ddada11c98a78a7378', 'kristianina')
go

INSERT INTO mpiangona VALUES (NEXT VALUE FOR seq_mpiangona, 'Pasi', 'Tera', '1986-10-30', 'Lot I IJK', 'pasitera@itu.mg', 'f7fd7ed262064005c5d280b78abf35a204e73f0e5147563ad5a9b2877e3753fe', 'pasitera')
go

INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 1, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 2, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 3, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 4, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 5, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 6, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 7, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 8, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 9, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 10, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 11, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 12, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 13, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 14, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 15, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 16, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 17, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 18, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 19, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 20, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 21, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 22, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 23, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 24, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 25, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 26, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 27, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 28, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 29, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 30, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 31, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 32, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 33, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 34, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 35, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 36, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 37, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 38, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 39, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 40, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 41, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 42, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 43, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 44, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 45, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 46, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 47, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 48, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 49, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 50, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 51, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 52, 2022, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 1, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 2, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 3, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 4, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 5, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 6, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 7, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 8, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 9, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 10, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 11, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 12, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 13, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 14, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 15, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 16, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 17, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 18, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 19, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 20, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 21, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 22, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 23, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 24, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 25, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 26, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 27, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 28, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 29, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 30, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 31, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 32, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 33, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 34, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 35, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 36, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 37, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 38, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 39, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 40, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 41, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 42, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 43, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 44, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 45, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 46, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 47, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 48, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 49, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 50, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 51, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 52, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 53, 2023, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 1, 2024, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 2, 2024, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 3, 2024, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 4, 2024, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 5, 2024, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 6, 2024, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 7, 2024, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 8, 2024, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 9, 2024, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 10, 2024, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 11, 2024, 'Tsotra')
INSERT INTO dimanche VALUES(NEXT VALUE FOR seq_dimanche, 12, 2024, 'Tsotra')
go

INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 1, 1785347.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 2, 2493554.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 3, 1943028.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 4, 1224778.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 5, 2123103.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 6, 863170.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 7, 1456140.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 8, 1750274.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 9, 1868880.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 10, 1680000.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 11, 1443484.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 12, 1251760.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 13, 2240582.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 14, 1383943.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 15, 2482869.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 16, 1635536.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 17, 1408553.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 18, 2136155.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 19, 1288352.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 20, 1288998.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 21, 966183.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 22, 1915968.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 23, 1181604.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 24, 1172188.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 25, 974678.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 26, 2116528.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 27, 963836.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 28, 1948753.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 29, 1740897.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 30, 1980008.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 31, 1000336.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 32, 1575679.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 33, 831672.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 34, 1509647.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 35, 1063296.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 36, 1258767.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 37, 1175881.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 38, 2085613.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 39, 2265460.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 40, 1146522.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 41, 1256339.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 42, 2288269.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 43, 2057056.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 44, 2278999.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 45, 1547634.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 46, 2052875.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 47, 2351552.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 48, 2330102.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 49, 1313146.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 50, 1028230.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 51, 2091938.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 52, 1981938.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 53, 1034717.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 54, 2088480.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 55, 2268591.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 56, 2248062.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 57, 1511873.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 58, 1252042.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 59, 1052193.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 60, 1618762.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 61, 1333933.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 62, 1894582.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 63, 1610751.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 64, 2036055.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 65, 898038.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 66, 1203923.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 67, 1538451.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 68, 1018612.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 69, 1318840.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 70, 2014014.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 71, 1635913.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 72, 1047601.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 73, 1651479.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 74, 2272309.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 75, 1246328.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 76, 893238.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 77, 1928502.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 78, 1840343.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 79, 970042.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 80, 1908845.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 81, 2393482.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 82, 2100838.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 83, 2251352.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 84, 1944293.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 85, 1999351.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 86, 1046293.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 87, 1155558.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 88, 1833945.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 89, 927862.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 90, 1453844.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 91, 1931819.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 92, 1895531.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 93, 878072.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 94, 1409053.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 95, 2287849.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 96, 2135902.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 97, 2066375.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 98, 1627350.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 99, 2086252.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 100, 2197180.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 101, 1978387.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 102, 1335976.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 103, 1709069.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 104, 1992546.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 105, 1990000.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 106, 2224761.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 107, 2782304.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 108, 1554495.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 109, 2633209.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 110, 2394950.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 111, 1515962.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 112, 2213440.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 113, 2220491.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 114, 2188935.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 115, 1890000.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 116, 1610000.0)
INSERT INTO rakitra VALUES(NEXT VALUE FOR seq_rakitra, 117, 2000000.0)
go

INSERT INTO categorie VALUES(NEXT VALUE FOR seq_categorie, 'Jirama', 'variable', 12);
INSERT INTO categorie VALUES(NEXT VALUE FOR seq_categorie, 'Reparations', 'variable', 6);
INSERT INTO categorie VALUES(NEXT VALUE FOR seq_categorie, 'hofan-tany', 'fixe', 12);
INSERT INTO categorie VALUES(NEXT VALUE FOR seq_categorie, 'Donations', 'fixe', 4);
go

INSERT INTO depenseFixe VALUES(NEXT VALUE FOR seq_fixe, 3, 1750000);
INSERT INTO depenseFixe VALUES(NEXT VALUE FOR seq_fixe, 4, 3000000);
go

INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 1, 1, 2022, 1205000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 1, 2, 2022, 1267000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 1, 3, 2022, 1234000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 1, 4, 2022, 1259000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 1, 5, 2022, 1292000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 1, 6, 2022, 1223000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 1, 7, 2022, 1280000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 1, 8, 2022, 1276000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 1, 9, 2022, 1211000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 1, 10, 2022, 1248000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 1, 11, 2022, 1303000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 1, 12, 2022, 1264000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 1, 1, 2023, 1332000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 1, 2, 2023, 1368000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 1, 3, 2023, 1394000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 1, 4, 2023, 1325000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 1, 5, 2023, 1387000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 1, 6, 2023, 1349000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 1, 7, 2023, 1306000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 1, 8, 2023, 1373000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 1, 9, 2023, 1310000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 1, 10, 2023, 1352000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 1, 11, 2023, 1404000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 1, 12, 2023, 1331000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 1, 1, 2024, 1074500.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 1, 2, 2024, 1259000.00);

INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 2, 2, 2022, 1300000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 2, 4, 2022, 1350000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 2, 6, 2022, 1370000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 2, 8, 2022, 1395000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 2, 10, 2022, 1805000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 2, 12, 2022, 1300000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 2, 2, 2023, 1256000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 2, 4, 2023, 1985000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 2, 6, 2023, 1235500.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 2, 8, 2023, 1450000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 2, 10, 2023, 1710000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 2, 12, 2023, 1500000.00);
INSERT INTO depenseVariable VALUES(NEXT VALUE FOR seq_variable, 2, 2, 2024, 1100000.00);

go

CREATE VIEW caisse as SELECT sum(montant) as caisse from (SELECT sum(montant) as montant from rakitra union all select -sum(montant) as montant from pret) vola
go

CREATE VIEW montantEnCours AS SELECT sum(montant) AS montantEnCours
FROM pretEnCours
go


select avg(montant) as moyenne from (SELECT montant FROM rakitra r JOIN dimanche d ON r.idDimanche = d.idDimanche WHERE d.numeroDimanche = 2 AND d.annee = 2022 UNION ALL SELECT montant FROM rakitra r JOIN dimanche d ON r.idDimanche = d.idDimanche WHERE d.numeroDimanche = 2 AND d.annee = 2023) as average
go