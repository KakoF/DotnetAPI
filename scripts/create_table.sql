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
