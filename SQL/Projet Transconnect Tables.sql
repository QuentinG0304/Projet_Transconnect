CREATE DATABASE IF NOT EXISTS TransConnect;
USE TransConnect ;
SET SQL_SAFE_UPDATES = 0;
/*Mise en place*/
drop table commande;
drop table salarie;
drop table Vehicule;
DROP TABLE Plus_COurt_chemin;


CREATE TABLE IF NOT EXISTS Salarie(
n_ss int,
nom varchar(40),
prenom varchar(40),
naissance datetime,
adresse varchar(50),
mail varchar(40),
num_tel varchar(40),
date_entree datetime,
poste varchar(40),
salaire float,
id_nplus1 int,
actif bool,
PRIMARY KEY(n_ss) 
);

drop table Client;
CREATE TABLE IF NOT EXISTS Client(
n_ss int,
nom varchar(40),
prenom varchar(40),
naissance datetime,
adresse varchar(50),
mail varchar(40),
num_tel varchar(15),
mdp varchar(20),
statut varchar(20),
PRIMARY KEY(n_ss) 
);

CREATE OR REPLACE VIEW Chauffeur AS
SELECT * FROM Salarie WHERE poste = "chauffeur";


CREATE TABLE IF NOT EXISTS Vehicule(
imma VARCHAR(30) PRIMARY KEY,
type_vehicule Varchar(30),
prix_par_litre float,
nb_passager int,
volume int
);

CREATE TABLE IF NOT EXISTS Commande(
id_commande int PRIMARY KEY,
n_ss_client int,
n_ss_chauffeur int,
imma VARCHAR(30),
depart varchar(20),
arrivee varchar(20),
jour Datetime,
prix float,
nb_passagers int,
usage_ VARCHAR(100),
volume int,
FOREIGN KEY(n_ss_client) references Client(n_ss),
FOREIGN KEY(n_ss_chauffeur) references Salarie(n_ss),
FOREIGN KEY(imma) references Vehicule(imma)
);

DROP Table Plus_Court_Chemin;
CREATE TABLE IF NOT EXISTS Plus_Court_Chemin(
ville_depart VARCHAR(20),
ville_arrivee VARCHAR(20),
distance INT,
temp DATETIME,
chemin VARCHAR(1000),
PRIMARY KEY(ville_depart,ville_arrivee)
);


