CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS keeps(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  creatorId VARCHAR(255) COMMENT 'users account Id',
  name TEXT NOT NULL COMMENT 'Keeps Name',
  description TEXT NOT NULL COMMENT 'Keeps Description',
  img TEXT NOT NULL COMMENT 'Keeps Image',
  views INT COMMENT 'Keeps viewcount',
  shares INT COMMENT 'Keeps sharecount',
  keeps INT COMMENT 'How many other users kept the keep',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS vaults(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  creatorId VARCHAR(255) COMMENT 'users account Id',
  name TEXT NOT NULL COMMENT 'Vaults Name',
  description TEXT NOT NULL COMMENT 'Vaults Description',
  isPrivate BOOLEAN NOT NULL COMMENT 'If vault is private or not',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS vaultKeeps(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  creatorId VARCHAR(255) COMMENT 'users account Id',
  vaultId INT NOT NULL COMMENT 'Vaults ID',
  keepId int NOT NULL COMMENT 'Keep ID',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (vaultId) REFERENCES vaults(id) ON DELETE CASCADE,
  FOREIGN KEY (keepId) REFERENCES keeps(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
-- SELECTS --
SELECT
  *
FROM
  accounts;
SELECT
  *
FROM
  keeps;
SELECT
  *
FROM
  vaults;
SELECT
  *
FROM
  vaultKeeps;
-- INSERT --
INSERT INTO
  keeps (id, name, description, img)
VALUES
  (1, "Ryan", "Stuff", "string");
INSERT INTO
  vaults (id, creatorId, name, description, isPrivate)
VALUES
  (
    1,
    "61cc69e8955b2a8b17de965c",
    "Stuff",
    "Descrip",
    0
  );
-- DELETE --
DELETE FROM
  vaults;
DELETE FROM
  keeps;