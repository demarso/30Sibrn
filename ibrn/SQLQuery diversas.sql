select * from tblPessoa

Select * from ibrn$

delete tblPessoa where IDPessoa > 869

UPDATE tblPessoa SET StatID = 1

DBCC CHECKIDENT (tblPessoa, NORESEED)

DBCC CHECKIDENT (tblPessoa, RESEED, 0)

INSERT INTO tblPessoa
  (Nome,Endereco,Telefone,Celular,Nascimento)
     SELECT Nome,Endereco,Telefone,Celular,Nascimento From ibrn$