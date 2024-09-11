/*A faire tourner pour initialiser la bdd*/
INSERT INTO Client (n_ss, nom, prenom, naissance, adresse, mail, num_tel, mdp,statut)
VALUES
(11, 'Bernard', 'Laurent', '1975-04-04', '555 Rue des Bleuets', 'laurent.bernard@example.com', '0611223344', 'mdp1','Bronze'),
(12, 'David', 'Marc', '1981-08-08', '666 Avenue des Tournesols', 'marc.david@example.com', '0622334455', 'mdp2','Bronze'),
(13, 'Fournier', 'Isabelle', '1986-12-12', '777 Boulevard des Mimosas', 'isabelle.fournier@example.com', '0633445566', 'mdp3','Bronze'),
(14, 'Gauthier', 'Thomas', '1992-05-15', '888 Rue des Perce-neige', 'thomas.gauthier@example.com', '0644556677', 'mdp4','Bronze'),
(15, 'Huynh', 'Nathalie', '1997-10-20', '999 Avenue des Jacinthes', 'nathalie.huynh@example.com', '0655667788', 'mdp5','Bronze'),
(16, 'Imbault', 'Vincent', '1983-03-03', '1010 Boulevard des Glaïeuls', 'vincent.imbault@example.com', '0666778899', 'mdp6','Bronze'),
(17, 'Jacques', 'Audrey', '1998-07-07', '1111 Rue des Narcisses', 'audrey.jacques@example.com', '0677889900', 'mdp7','Bronze'),
(18, 'Kerjean', 'Benjamin', '1985-11-11', '1212 Avenue des Hortensias', 'benjamin.kerjean@example.com', '0688990011', 'mdp8','Bronze'),
(19, 'Lopez', 'Catherine', '1990-02-02', '1313 Boulevard des Magnolias', 'catherine.lopez@example.com', '0699001122', 'mdp9','Bronze'),
(20, 'Muller', 'Damien', '1995-06-06', '1414 Rue des Orangers', 'damien.muller@example.com', '0600112233', 'mdp10','Bronze');


INSERT INTO Vehicule (imma, type_vehicule, prix_par_litre, nb_passager, volume)
VALUES 
('EF123GH', 'Voiture', 1.3, 5, 500),
('IJ456KL', 'Voiture', 1.4, 5, 450),
('MN789QR', 'Voiture', 1.5, 5, 400),
('UV012WX', 'Voiture', 1.6, 5, 480),
('YZ345AB', 'Voiture', 1.7, 5, 520),
('AB123CD', 'Camionnette', 1.5, 0, 0),
('XY456ZW', 'Camionnette', 1.7, 0, 0),
('LM789OP', 'Camionnette', 1.6, 0, 0),
('JK012LM', 'Camionnette', 1.8, 0, 0),
('RS345TU', 'Camionnette', 1.9, 0, 0);

INSERT INTO Vehicule (imma, type_vehicule, prix_par_litre, nb_passager, volume)
VALUES 
('ABC129', 'Camion-Citerne', 1.5, 0, 10000),
('DEF458', 'Camion-Citerne', 1.7, 0, 12000),
('GHI787', 'Camion-Citerne', 1.6, 0, 13000),
('JKL016', 'Camion-Citerne', 1.8, 0, 14000),
('MNO342', 'Camion-Citerne', 1.9, 0, 15000),

('PQR678', 'Camion Benne', 2.0, 0, 16000),
('STU901', 'Camion Benne', 2.1, 0, 17000),
('VWX234', 'Camion Benne', 2.2, 0, 18000),
('YZA567', 'Camion Benne', 2.3, 0, 19000),
('BCD890', 'Camion Benne', 2.4, 0, 20000),

('EFG123', 'Camion Frigorifique', 2.5, 0, 21000),
('HIJ456', 'Camion Frigorifique', 2.6, 0, 22000),
('KLM789', 'Camion Frigorifique', 2.7, 0, 23000),
('NOP012', 'Camion Frigorifique', 2.8, 0, 24000),
('QRS345', 'Camion Frigorifique', 2.9, 0, 25000);

DELETE FROM SALARIE;
INSERT INTO Salarie (n_ss, nom, prenom, naissance, adresse, mail, num_tel, date_entree, poste, salaire, id_nplus1, actif) VALUES
(1, 'Dupond', 'Mr', '2024-05-12', '123 Rue de la République', 'a', '1234567890', '2024-05-12', 'Directeur Général', 0, 0, true),
(2, 'Fiesta', 'Mme', '2024-05-12', '456 Avenue du Commerce', 'fiesta@example.com', '2345678901', '2024-05-12', 'Directeur Commercial', 0, 1, true),
(3, 'Fetard', 'Mr', '2024-05-12', '789 Boulevard des Opérations', 'fetard@example.com', '3456789012', '2024-05-12', 'Directeur des Opérations', 0, 1, true),
(4, 'Joyeuse', 'Mme', '2024-05-12', '101 Rue des Ressources Humaines', 'joyeuse@example.com', '4567890123', '2024-05-12', 'Directeur des Ressources Humaines', 0, 1, true),
(5, 'GripSous', 'Mr', '2024-05-12', '202 Avenue des Finances', 'gripsous@example.com', '5678901234', '2024-05-12', 'Directeur Financier', 0, 1, true),
(6, 'Forge', 'Mr', '2024-05-12', '303 Rue des Ventes', 'forge@example.com', '6789012345', '2024-05-12', 'Commercial', 0, 2, true),
(7, 'Royal', 'Mr', '2024-05-12', '404 Chemin de l Équipe', 'royal@example.com', '7890123456', '2024-05-12', 'Chef d Équipe', 0, 3, true),
(8, 'Prince', 'Mme', '2024-05-12', '505 Allée des Équipes', 'prince@example.com', '8901234567', '2024-05-12', 'Chef d Équipe', 0, 3, true),
(9, 'Couleur', 'Mme', '2024-05-12', '606 Rue de la Formation', 'couleur@example.com', '9012345678', '2024-05-12', 'Formation', 0, 4, true),
(10, 'Picsou', 'Mr', '2024-05-12', '707 Boulevard de la Comptabilité', 'picsou@example.com', '0123456789', '2024-05-12', 'Direction Comptable', 0, 5, true),
(11, 'GrossSous', 'Mr', '2024-05-12', '808 Avenue du Contrôle', 'grosssous@example.com', '1234567890', '2024-05-12', 'Contrôleur de Gestion', 0, 5, true),
(12, 'Fermi', 'Mme', '2024-05-12', '909 Rue des Ventes', 'fermi@example.com', '2345678901', '2024-05-12', 'Commercial', 0, 2, true),
(13, 'Romu', 'Mr', '2024-05-12', '1010 Chemin du Chauffage', 'romu@example.com', '3456789012', '2024-05-12', 'Chauffeur', 25, 7, true),
(14, 'Rome', 'Mme', '2024-05-12', '1111 Route du Roulement', 'rome@example.com', '4567890123', '2024-05-12', 'Chauffeur', 25, 8, true),
(15, 'Romi', 'Mme', '2024-05-12', '1212 Allée du Transport', 'romi@example.com', '5678901234', '2024-05-12', 'Chauffeur', 25, 7, true),
(16, 'Rimou', 'Mme', '2024-05-12', '1313 Avenue de la Livraison', 'rimou@example.com', '6789012345', '2024-05-12', 'Chauffeur', 25, 8, true),
(17, 'Roma', 'Mr', '2024-05-12', '1414 Boulevard du Déplacement', 'roma@example.com', '7890123456', '2024-05-12', 'Chauffeur', 25, 7, true),
(18, 'Toutlemonde', 'Mme', '2024-05-12', '1515 Rue des Contrats', 'toutlemonde@example.com', '8901234567', '2024-05-12', 'Contrat', 0, 4, true),
(19, 'Gautier', 'Mme', '2024-05-12', '1616 Chemin de la Comptabilité', 'gautier@example.com', '9012345678', '2024-05-12', 'Comptable', 0, 10, true),
(20, 'Fournier', 'Mme', '1990-05-15', '123 Rue', 'john.doe@example.com', '123456789', '2024-05-12', 'Comptable', 0, 10, true);

INSERT INTO Commande (id_commande, n_ss_client, n_ss_chauffeur, imma, depart, arrivee, jour, prix, nb_passagers, usage_, volume) VALUES
(1, 11, 13, 'EFG123', 'Paris', 'Angers', '2024-05-14 00:00:00', 1514.5, 0, '', 200),
(2, 20, 13, 'ABC129', 'Avignon', 'Montpellier', '2024-05-15 00:00:00', 415.5, 0, '', 1000);

