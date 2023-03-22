CREATE TABLE IF NOT EXISTS Simian (
    id SERIAL PRIMARY KEY,
    dna VARCHAR (250) NOT NULL UNIQUE,
    is_simian BOOLEAN NOT NULL,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMPTZ NOT NULL DEFAULT NOW()
);


CREATE TABLE IF NOT EXISTS SimianCalc (
    id Date NOT NULL PRIMARY KEY,
    total numeric NOT NULL,
    count_is_simian numeric NOT NULL,
    count_is_human numeric NOT NULL,
    is_simian_percent numeric GENERATED ALWAYS AS (count_is_simian / total) STORED,
    is_human_percent numeric GENERATED ALWAYS AS (count_is_human / total) STORED,
    ratio numeric GENERATED ALWAYS AS (count_is_simian / count_is_human) STORED,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMPTZ NOT NULL DEFAULT NOW()
);

CREATE TABLE IF NOT EXISTS ChuckNorris (
    id VARCHAR (250) NOT NULL PRIMARY KEY UNIQUE,
    categories  TEXT NULL,
    createdAt  VARCHAR (250) NULL,
    iconUrl  TEXT NULL,
    updatedAt  VARCHAR (250) NULL,
    url  TEXT NULL,
    value  TEXT NULL
);

CREATE TABLE IF NOT EXISTS Slip (
    id SERIAL PRIMARY KEY UNIQUE,
    advice TEXT NULL
);

