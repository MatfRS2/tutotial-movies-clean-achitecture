CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "Contributors" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Contributors" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL
);

CREATE TABLE "Projects" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Projects" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "Priority" INTEGER NOT NULL
);

CREATE TABLE "ToDoItems" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_ToDoItems" PRIMARY KEY AUTOINCREMENT,
    "Title" TEXT NOT NULL,
    "Description" TEXT NOT NULL,
    "ContributorId" INTEGER NULL,
    "IsDone" INTEGER NOT NULL,
    "ProjectId" INTEGER NULL,
    CONSTRAINT "FK_ToDoItems_Projects_ProjectId" FOREIGN KEY ("ProjectId") REFERENCES "Projects" ("Id")
);

CREATE INDEX "IX_ToDoItems_ProjectId" ON "ToDoItems" ("ProjectId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221202103627_InitialMigrationName', '7.0.0');

COMMIT;

