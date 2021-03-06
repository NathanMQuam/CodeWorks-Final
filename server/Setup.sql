-- NOTE: Profiles
-- CREATE TABLE profiles (
--    id VARCHAR(255) NOT NULL PRIMARY KEY,
--    name VARCHAR(255),
--    email VARCHAR(255) NOT NULL UNIQUE,
--    picture VARCHAR(255)
-- );
-- NOTE: Vaults
-- CREATE TABLE vaults (
--    id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
--    creatorId VARCHAR(255) NOT NULL,
--    name VARCHAR(255) NOT NULL,
--    description VARCHAR(255) NOT NULL,
--    isPrivate TINYINT,
--    FOREIGN KEY (creatorId) REFERENCES profiles (id)
-- );
-- NOTE: Keeps
-- CREATE TABLE keeps (
--    id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
--    creatorId VARCHAR(255) NOT NULL,
--    name VARCHAR(255) NOT NULL,
--    description VARCHAR(255) NOT NULL,
--    image VARCHAR(255) NOT NULL,
--    views INT,
--    shares INT,
--    keeps INT,
--    FOREIGN KEY (creatorId) REFERENCES profiles (id)
-- );
-- NOTE: VaultKeeps
-- CREATE TABLE vaultKeeps (
--    id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
--    creatorId VARCHAR(255) NOT NULL,
--    vaultId INT NOT NULL,
--    keepId INT NOT NULL,
--    FOREIGN KEY (creatorId)
--       REFERENCES profiles (id)
--        ON DELETE CASCADE,
--    FOREIGN KEY (vaultId)
--       REFERENCES vaults (id)
--       ON DELETE CASCADE,
--    FOREIGN KEY (keepId)
--       REFERENCES keeps (id)
--       ON DELETE CASCADE
-- );
-- SELECT * FROM vaults;
-- SELECT * FROM keeps;
-- SELECT * FROM vaultKeeps;
-- INSERT INTO vaultKeeps
-- (creatorId, vaultId, keepId)
-- VALUES
-- ("9fd6652a-512b-4661-9704-7983e12be4f8", 16, 16);