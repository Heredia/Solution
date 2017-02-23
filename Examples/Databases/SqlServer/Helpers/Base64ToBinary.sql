-- Base64 to Varbinary
DECLARE @StringBase64 VARCHAR(MAX);
SET @StringBase64 = 'iVBORw0KGgoAAAANSUhEUgAAATkAAAE5AQMAAADRL8WyAAAAAXNSR0IArs4c6QAAAAZQTFRFAAAA////pdmf3QAAANZJREFUeNrt2jEKg0AQheERi5QeIUfxaPFoHiVHsEwhvjAyOAsmgRHS/a/axc9yecyqnTNqMxukyXpptk5azAwIBJbhTU1eDj0OjwCBwItwjiUQCPwzjFbrfbUBgcAS9A0QCLwIMw7j4D2kfeYCAoEFWLrQ8ExAILAI9SNr03dAILAIs+Kescl5rD2FQCCwCCXls4RZcREgEFiCkbE9hZH2IzIQCKxDSVlk8V7WX05qQCBwh3kV/7G5IkAgsA4lBbxLhz9fxQOBwBr89v/g4nC1CBAILMM34TG2uvMH+igAAAAASUVORK5CYII=';
SELECT CAST(N'' AS XML).VALUE('xs:base64Binary(sql:variable("@StringBase64"))', 'VARBINARY(MAX)') AS BINARY;

-- Varbinary to Base64
DECLARE @binary VARBINARY(MAX);
SET @binary = 0x89504E470D0A1A0A0000000D4948445200000139000001390103000000D12FC5B2000000017352474200AECE1CE900000006504C5445000000FFFFFFA5D99FDD000000D64944415478DAEDDA310A83401085E1118B941E2147F168F1681E2547B04C21BE3032380B268111D2FDAFDAC5CF7279CCAA9D336A331BA4C97A69B64E5ACC0C080496E14D4D5E0E3D0E8F0081C08B708E251008FC338C56EB7DB50181C012F40D1008BC08330EE3E03DA47DE60202810558BAD0F04C4020B008F5236BD3774020B008B3E29EB1C979AC3D854020B00825E5B3845971112010588291B13D8591F623321008AC43495964F15ED65F4E6A402070877915FFB1B9224020B00E2505BC4B873F5FC50381C01AFCF6FFE0E270B50810082CC337E131B6BAF307FA280000000049454E44AE426082;
SELECT CAST(N'' AS XML).VALUE('xs:base64Binary(xs:hexBinary(sql:variable("@binary")))', 'VARCHAR(MAX)') AS StringBase64;