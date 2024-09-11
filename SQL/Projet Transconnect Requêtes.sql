SELECT * FROM Plus_Court_CHemin;

SELECT * FROM Client;

SELECT * FROM client WHERE mail = "laurent.bernard@example.com" and mdp = "mdp1";
/*Afficher les commandes d'un client"*/
SELECT id_commande FROM Commande
INNER join client on n_ss = n_ss_client
WHERE n_ss = 11;

DELETE FROM Client WHERE n_ss = 21;
SELECT * FROM client;

SELECT max(n_ss) FROM client ;

SELECT * FROM commande WHERE id_commande = 1;

/* Afficher par chauffeur le nombre de livraisons effectuées */
SELECT nom,prenom,Count(n_ss_chauffeur) as  nombre_de_livraisons_effectuées FROM chauffeur
LEFT JOIN commande ON n_ss = n_ss_chauffeur
GROUP BY nom,prenom
ORDER BY nombre_de_livraisons_effectuées DESC;

/* Afficher les commandes selon une période de temps */
SELECT * FROM commande
ORDER BY jour;

SELECT * FROM commande
WHERE Day(jour) < 03 
Order By jour; 

/*Afficher la moyenne des prix des commandes*/
SELECT AVG(prix)
FROM commande;

/*Afficher la moyenne des comptes clients (Changer le AVG en SUM pour avoir le plus gros client)*/ 
SELECT Nom,Prenom,AVG(Prix)
FROM Client
LEFT JOIN Commande on n_ss_client=n_ss
GROUP BY Nom,Prenom
ORDER BY AVG(Prix) DESC;



SELECT DISTINCT n_ss_chauffeur,Count(n_ss_chauffeur) FROM commande
Group BY n_ss_chauffeur;

/*Recherche si dispo ou non*/
SELECT count(*) FROM Vehicule 
INNER JOIN Commande ON Vehicule.imma=Commande.imma
WHERE Day(jour) = 3 AND Month(jour) = 1 AND Year(jour)= 1;

SELECT count(*) FROM Chauffeur 
INNER JOIN Commande ON n_ss_chauffeur= n_ss
WHERE Day(jour) = 13 AND Month(jour) = 5 AND Year(jour)= 2024 and n_ss = '13';


SELECT chemin FROM Plus_Court_Chemin
JOIN Commande ON Commande.depart = ville_depart AND commande.arrivee = ville_arrivee
WHERE id_commande = 6;

SELECT chemin FROM Plus_Court_Chemin
JOIN Commande ON Commande.depart = ville_arrivee AND commande.arrivee = ville_depart
WHERE id_commande = 6;

SELECT * FROM Plus_Court_Chemin;
SELECT Count(ville_depart) FROM Plus_Court_Chemin;
/*Suppression des valeurs d'une table*/
DELETE FROM Plus_Court_Chemin;
/*Ajout des valeurs*/
INSERT INTO Plus_Court_Chemin(ville_depart, ville_arrivee, distance,temp) VALUES('Paris', 'Rouen', 133, '0001-01-01 01:45:00');

SELECT distance FROM Plus_Court_Chemin
WHERE (ville_depart = '' AND ville_arrivee = '') OR (ville_depart = '' AND ville_arrivee = '');

DELETE FROM Salarie WHERE n_ss = 22;
INSERT INTO Salarie (n_ss, nom, prenom, naissance, adresse, mail, num_tel, date_entree, poste, salaire, id_nplus1)
VALUES (22, 'Nouveau', 'Mme', '1990-05-15', '123 Rue ', 'john.doe@example.com', '123456789', '2024-05-12', 'Chauffeur', 0, 1);
SELECT * FROM Salarie;


SELECT Distinct(ville_depart) FROM Plus_Court_Chemin;
SELECT Distinct(ville_arrivee) FROM Plus_Court_Chemin;


INSERT INTO Vehicule (imma, type_vehicule, prix_par_litre, nb_passager, volume)
VALUES 
('ABC123', 'Voiture', 1.5, 5, 0),
('DEF456', 'Voiture', 1.7, 4, 0),
('GHI789', 'Voiture', 1.6, 5, 0),
('JKL012', 'Voiture', 1.8, 4, 0),
('MNO345', 'Voiture', 1.9, 5, 0);

SELECT * FROM salarie WHERE actif = true;

SELECT max(id_commande) FROM Commande;
SELECT * FROM Commande;

Update Salarie SET mail = "a" WHERE n_ss = 1;


SELECT * FROM Salarie;
DELETE FROM Salarie WHERE n_ss =0;
SELECT * FROM Chauffeur;
INSERT INTO Commande (id_commande, n_ss_client, n_ss_chauffeur, imma, depart, arrivee, jour, prix)
VALUES 
(20, 21, 13, 'ABC123', 'Lieu de départ A', 'Lieu d\'arrivée B', '2024-05-13 08:00:00', 50.00);

DELETE FROM Commande WHERE id_commande =2;
update Salarie SET actif = true WHERE n_ss = 17;
SELECT * FROM Salarie ;

SELECT nom, prenom FROM client WHERE n_ss = (SELECT n_ss_client FROM commande GROUP BY n_ss_client ORDER BY SUM(prix) DESC LIMIT 1);
SELECT type_vehicule, SUM(prix) AS revenus_totaux
FROM Vehicule
JOIN Commande ON Vehicule.imma = Commande.imma
GROUP BY type_vehicule
ORDER BY revenus_totaux DESC
LIMIT 1;
SELECT n_ss_client FROM commande GROUP BY n_ss_client ORDER BY SUM(prix) DESC LIMIT 1;

UPDATE CLient SET num_tel = "0652688269" WHERE n_ss = 21;
SELECT * FRom CLient;
SELECT count(*) FROM commande WHERE n_ss_client = 21; 

SELECT * FROM Vehicule;

SELECT * FROM client;
SELECT * FROM Commande WHERE n_ss_client = 21;
SELECT * FROM salarie;

UPDATE salarie SET id_nplus1 = 3 WHERE n_ss = 8;

DELETE FROM SAlarie Where n_ss<0;

SELECT chemin FROM Plus_Court_Chemin 
JOIN Commande ON Commande.depart = ville_depart AND commande.arrivee = ville_arrivee
                    WHERE id_commande =1;
                    
                    
SELECT * FROM client ORDER BY Nom DESC;

SELECT * FROM commande WHERE jour > NOW() - INTERVAL 1 MONTH ;SELECT * FROM Plus_Court_CHemin;

SELECT * FROM Client;

SELECT * FROM client WHERE mail = "laurent.bernard@example.com" and mdp = "mdp1";
/*Afficher les commandes d'un client"*/
SELECT id_commande FROM Commande
INNER join client on n_ss = n_ss_client
WHERE n_ss = 11;

DELETE FROM Client WHERE n_ss = 21;
SELECT * FROM client;

SELECT max(n_ss) FROM client ;

SELECT * FROM commande WHERE id_commande = 1;

/* Afficher par chauffeur le nombre de livraisons effectuées */
SELECT nom,prenom,Count(n_ss_chauffeur) as  nombre_de_livraisons_effectuées FROM chauffeur
LEFT JOIN commande ON n_ss = n_ss_chauffeur
GROUP BY nom,prenom
ORDER BY nombre_de_livraisons_effectuées DESC;

/* Afficher les commandes selon une période de temps */
SELECT * FROM commande
ORDER BY jour;

SELECT * FROM commande
WHERE Day(jour) < 03 
Order By jour; 

/*Afficher la moyenne des prix des commandes*/
SELECT AVG(prix)
FROM commande;

/*Afficher la moyenne des comptes clients (Changer le AVG en SUM pour avoir le plus gros client)*/ 
SELECT Nom,Prenom,AVG(Prix)
FROM Client
LEFT JOIN Commande on n_ss_client=n_ss
GROUP BY Nom,Prenom
ORDER BY AVG(Prix) DESC;



SELECT DISTINCT n_ss_chauffeur,Count(n_ss_chauffeur) FROM commande
Group BY n_ss_chauffeur;

/*Recherche si dispo ou non*/
SELECT count(*) FROM Vehicule 
INNER JOIN Commande ON Vehicule.imma=Commande.imma
WHERE Day(jour) = 3 AND Month(jour) = 1 AND Year(jour)= 1;

SELECT count(*) FROM Chauffeur 
INNER JOIN Commande ON n_ss_chauffeur= n_ss
WHERE Day(jour) = 13 AND Month(jour) = 5 AND Year(jour)= 2024 and n_ss = '13';


SELECT chemin FROM Plus_Court_Chemin
JOIN Commande ON Commande.depart = ville_depart AND commande.arrivee = ville_arrivee
WHERE id_commande = 6;

SELECT chemin FROM Plus_Court_Chemin
JOIN Commande ON Commande.depart = ville_arrivee AND commande.arrivee = ville_depart
WHERE id_commande = 6;

SELECT * FROM Plus_Court_Chemin;
SELECT Count(ville_depart) FROM Plus_Court_Chemin;
/*Suppression des valeurs d'une table*/
DELETE FROM Plus_Court_Chemin;
/*Ajout des valeurs*/
INSERT INTO Plus_Court_Chemin(ville_depart, ville_arrivee, distance,temp) VALUES('Paris', 'Rouen', 133, '0001-01-01 01:45:00');

SELECT distance FROM Plus_Court_Chemin
WHERE (ville_depart = '' AND ville_arrivee = '') OR (ville_depart = '' AND ville_arrivee = '');

DELETE FROM Salarie WHERE n_ss = 22;
INSERT INTO Salarie (n_ss, nom, prenom, naissance, adresse, mail, num_tel, date_entree, poste, salaire, id_nplus1)
VALUES (22, 'Nouveau', 'Mme', '1990-05-15', '123 Rue ', 'john.doe@example.com', '123456789', '2024-05-12', 'Chauffeur', 0, 1);
SELECT * FROM Salarie;


SELECT Distinct(ville_depart) FROM Plus_Court_Chemin;
SELECT Distinct(ville_arrivee) FROM Plus_Court_Chemin;


INSERT INTO Vehicule (imma, type_vehicule, prix_par_litre, nb_passager, volume)
VALUES 
('ABC123', 'Voiture', 1.5, 5, 0),
('DEF456', 'Voiture', 1.7, 4, 0),
('GHI789', 'Voiture', 1.6, 5, 0),
('JKL012', 'Voiture', 1.8, 4, 0),
('MNO345', 'Voiture', 1.9, 5, 0);

SELECT * FROM salarie WHERE actif = true;

SELECT max(id_commande) FROM Commande;
SELECT * FROM Commande;

Update Salarie SET mail = "a" WHERE n_ss = 1;


SELECT * FROM Salarie;
DELETE FROM Salarie WHERE n_ss =0;
SELECT * FROM Chauffeur;
INSERT INTO Commande (id_commande, n_ss_client, n_ss_chauffeur, imma, depart, arrivee, jour, prix)
VALUES 
(20, 21, 13, 'ABC123', 'Lieu de départ A', 'Lieu d\'arrivée B', '2024-05-13 08:00:00', 50.00);

DELETE FROM Commande WHERE id_commande =2;
update Salarie SET actif = true WHERE n_ss = 17;
SELECT * FROM Salarie ;

SELECT nom, prenom FROM client WHERE n_ss = (SELECT n_ss_client FROM commande GROUP BY n_ss_client ORDER BY SUM(prix) DESC LIMIT 1);
SELECT type_vehicule, SUM(prix) AS revenus_totaux
FROM Vehicule
JOIN Commande ON Vehicule.imma = Commande.imma
GROUP BY type_vehicule
ORDER BY revenus_totaux DESC
LIMIT 1;
SELECT n_ss_client FROM commande GROUP BY n_ss_client ORDER BY SUM(prix) DESC LIMIT 1;

UPDATE CLient SET num_tel = "0652688269" WHERE n_ss = 21;
SELECT * FRom CLient;
SELECT count(*) FROM commande WHERE n_ss_client = 21; 

SELECT * FROM Vehicule;

SELECT * FROM client;
SELECT * FROM Commande WHERE n_ss_client = 21;
SELECT * FROM salarie;

UPDATE salarie SET id_nplus1 = 3 WHERE n_ss = 8;

DELETE FROM SAlarie Where n_ss<0;

SELECT chemin FROM Plus_Court_Chemin 
JOIN Commande ON Commande.depart = ville_depart AND commande.arrivee = ville_arrivee
                    WHERE id_commande =1;
                    
                    
SELECT * FROM 
client ORDER BY Nom DESC;
DELETE FROM client WHERE n_ss = 22;
SELECT * FROM commande WHERE jour > NOW() - INTERVAL 1 MONTH AND jour < NOW();