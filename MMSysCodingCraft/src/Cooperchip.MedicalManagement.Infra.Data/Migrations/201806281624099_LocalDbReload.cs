namespace Cooperchip.MedicalManagement.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocalDbReload : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Acesso",
                c => new
                    {
                        AcessoId = c.Guid(nullable: false),
                        IdUsuario = c.Guid(nullable: false),
                        AcessoTipo = c.Int(nullable: false),
                        Claim = c.String(nullable: false, maxLength: 30, unicode: false),
                        AllowRead = c.Boolean(nullable: false),
                        AllowUpdate = c.Boolean(nullable: false),
                        AllowCreate = c.Boolean(nullable: false),
                        AllowDelete = c.Boolean(nullable: false),
                        AllowAll = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AcessoId);
            
            CreateTable(
                "dbo.Agendamento",
                c => new
                    {
                        AgendamentoId = c.Int(nullable: false, identity: true),
                        PacienteId = c.Guid(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Hora = c.String(nullable: false, maxLength: 5, unicode: false),
                        Exames = c.String(maxLength: 1500, unicode: false),
                        Confirmado = c.Boolean(nullable: false),
                        MedicoId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.AgendamentoId)
                .ForeignKey("dbo.Medicos", t => t.MedicoId)
                .ForeignKey("dbo.Paciente", t => t.PacienteId)
                .Index(t => t.PacienteId)
                .Index(t => t.MedicoId);
            
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        MedicoId = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 80, unicode: false),
                        Crm = c.String(maxLength: 10, unicode: false),
                        DataNascimento = c.DateTime(nullable: false),
                        EspecialidadeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicoId)
                .ForeignKey("dbo.Especialidade", t => t.EspecialidadeId)
                .ForeignKey("dbo.PessoaFisica", t => t.MedicoId)
                .Index(t => t.MedicoId)
                .Index(t => t.EspecialidadeId);
            
            CreateTable(
                "dbo.Especialidade",
                c => new
                    {
                        EspecialidadeId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 80, unicode: false),
                    })
                .PrimaryKey(t => t.EspecialidadeId);
            
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        PessoaId = c.Guid(nullable: false),
                        NomeOuRazaoSocial = c.String(nullable: false, maxLength: 100, unicode: false),
                        DataNascimentoOuFundacao = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 80, unicode: false),
                        CpfOrCnpj = c.String(maxLength: 18, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                        DataUltimaModificacao = c.DateTime(),
                        UsuarioUltimaModificacao = c.String(maxLength: 80, unicode: false),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioInclusao = c.String(maxLength: 80, unicode: false),
                    })
                .PrimaryKey(t => t.PessoaId);
            
            CreateTable(
                "dbo.Paciente",
                c => new
                    {
                        PacienteId = c.Guid(nullable: false),
                        Peso = c.Int(nullable: false),
                        DataInternacao = c.DateTime(nullable: false),
                        Complicacao = c.String(maxLength: 4000, unicode: false),
                        HistoriaPatologicaPregressa = c.String(maxLength: 4000, unicode: false),
                        Alergia = c.String(maxLength: 4000, unicode: false),
                        CodigoCid = c.String(maxLength: 5, unicode: false),
                        Hepatopatia = c.Boolean(nullable: false),
                        Gravidez = c.Boolean(nullable: false),
                        Amamentacao = c.Boolean(nullable: false),
                        ConvenioId = c.Int(nullable: false),
                        LeitoId = c.Int(nullable: false),
                        Sexo = c.Int(nullable: false),
                        EstadoPacienteId = c.Int(nullable: false),
                        SetorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PacienteId)
                .ForeignKey("dbo.Convenio", t => t.ConvenioId)
                .ForeignKey("dbo.EstadoDoPaciente", t => t.EstadoPacienteId)
                .ForeignKey("dbo.Leito", t => t.LeitoId)
                .ForeignKey("dbo.PessoaFisica", t => t.PacienteId)
                .ForeignKey("dbo.Setor", t => t.SetorId)
                .Index(t => t.PacienteId)
                .Index(t => t.ConvenioId)
                .Index(t => t.LeitoId)
                .Index(t => t.EstadoPacienteId)
                .Index(t => t.SetorId);
            
            CreateTable(
                "dbo.Convenio",
                c => new
                    {
                        ConvenioId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ConvenioId);
            
            CreateTable(
                "dbo.EstadoDoPaciente",
                c => new
                    {
                        EstadoDoPacienteId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 80, unicode: false),
                    })
                .PrimaryKey(t => t.EstadoDoPacienteId);
            
            CreateTable(
                "dbo.Leito",
                c => new
                    {
                        LeitoId = c.Int(nullable: false, identity: true),
                        EspecificacaoDoLeito = c.String(maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.LeitoId);
            
            CreateTable(
                "dbo.ResultadoExame",
                c => new
                    {
                        ResultadoExameId = c.Guid(nullable: false),
                        PacienteId = c.Guid(nullable: false),
                        IdPrescricao = c.Guid(nullable: false),
                        IdExameParametros = c.Guid(nullable: false),
                        MedicoId = c.Guid(nullable: false),
                        PedidoEm = c.DateTime(nullable: false),
                        DataResultado = c.DateTime(nullable: false),
                        Resultado = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Observacao = c.String(maxLength: 80, unicode: false),
                    })
                .PrimaryKey(t => t.ResultadoExameId)
                .ForeignKey("dbo.ExameParametros", t => t.IdExameParametros)
                .ForeignKey("dbo.Medicos", t => t.MedicoId)
                .ForeignKey("dbo.Paciente", t => t.PacienteId)
                .Index(t => t.PacienteId)
                .Index(t => t.IdExameParametros)
                .Index(t => t.MedicoId);
            
            CreateTable(
                "dbo.ExameParametros",
                c => new
                    {
                        ExameParametrosId = c.Guid(nullable: false),
                        Exame = c.String(nullable: false, maxLength: 50, unicode: false),
                        Minimo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Maximo = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ExameParametrosId);
            
            CreateTable(
                "dbo.Setor",
                c => new
                    {
                        SetorId = c.Int(nullable: false, identity: true),
                        Sigla = c.String(nullable: false, maxLength: 4, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 35, unicode: false),
                    })
                .PrimaryKey(t => t.SetorId);
            
            CreateTable(
                "dbo.Alergia",
                c => new
                    {
                        AlergiaId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.AlergiaId);
            
            CreateTable(
                "dbo.Anticoagulacao",
                c => new
                    {
                        AnticoagulacaoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.AnticoagulacaoId);
            
            CreateTable(
                "dbo.ApresentacaoAjusteInteracao",
                c => new
                    {
                        ApresentacaoAjusteInteracaoId = c.Int(nullable: false, identity: true),
                        IdMedicamento = c.Int(nullable: false),
                        IdPosologia = c.Int(nullable: false),
                        IdGenerico = c.Int(nullable: false),
                        PacienteId = c.Guid(nullable: false),
                        ProntuarioGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ApresentacaoAjusteInteracaoId)
                .ForeignKey("dbo.Medicamento", t => t.IdMedicamento)
                .ForeignKey("dbo.MedicamentoPosologia", t => t.IdPosologia)
                .ForeignKey("dbo.Paciente", t => t.PacienteId)
                .ForeignKey("dbo.Prontuario", t => t.ProntuarioGuid)
                .Index(t => t.IdMedicamento)
                .Index(t => t.IdPosologia)
                .Index(t => t.PacienteId)
                .Index(t => t.ProntuarioGuid);
            
            CreateTable(
                "dbo.Medicamento",
                c => new
                    {
                        MedicamentoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 100, unicode: false),
                        Generico = c.String(nullable: false, maxLength: 100, unicode: false),
                        IdGenerico = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicamentoId)
                .ForeignKey("dbo.Generico", t => t.IdGenerico)
                .Index(t => t.IdGenerico);
            
            CreateTable(
                "dbo.Generico",
                c => new
                    {
                        GenericoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.GenericoId);
            
            CreateTable(
                "dbo.MedicamentoPosologia",
                c => new
                    {
                        MedicamentoPosologiaId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 300, unicode: false),
                        IdMedicamento = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicamentoPosologiaId)
                .ForeignKey("dbo.Medicamento", t => t.IdMedicamento)
                .Index(t => t.IdMedicamento);
            
            CreateTable(
                "dbo.Prontuario",
                c => new
                    {
                        ProntuarioId = c.Guid(nullable: false),
                        DataProntuario = c.DateTime(nullable: false),
                        NumAtendimento = c.String(nullable: false, maxLength: 10, unicode: false),
                        Pam = c.String(maxLength: 50, unicode: false),
                        PamData = c.DateTime(),
                        Hemodialise = c.String(maxLength: 50, unicode: false),
                        HemodialiseData = c.DateTime(),
                        ViaAerea = c.String(maxLength: 50, unicode: false),
                        ViaAereaData = c.DateTime(),
                        ViaDigestiva = c.String(maxLength: 50, unicode: false),
                        ViaDigestivaData = c.DateTime(),
                        AcessoVenoso = c.String(maxLength: 50, unicode: false),
                        AcessoVenosoData = c.DateTime(),
                        Marcapasso = c.String(maxLength: 50, unicode: false),
                        MarcapassoData = c.DateTime(),
                        ViaUrinaria = c.String(maxLength: 50, unicode: false),
                        ViaUrinariaData = c.DateTime(),
                        Pic = c.String(maxLength: 50, unicode: false),
                        Pia = c.String(maxLength: 50, unicode: false),
                        PicData = c.DateTime(),
                        PiaData = c.DateTime(),
                        Anticoagulacao = c.String(maxLength: 25, unicode: false),
                        PacienteId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ProntuarioId)
                .ForeignKey("dbo.Paciente", t => t.PacienteId)
                .Index(t => t.PacienteId);
            
            CreateTable(
                "dbo.ApresentacaoAux",
                c => new
                    {
                        ApresentacaoId = c.Int(nullable: false, identity: true),
                        Apresentacao1 = c.String(maxLength: 80, unicode: false),
                        Apresentacao2 = c.String(maxLength: 80, unicode: false),
                        Apresentacao3 = c.String(maxLength: 80, unicode: false),
                        Apresentacao4 = c.String(maxLength: 80, unicode: false),
                        Apresentacao5 = c.String(maxLength: 80, unicode: false),
                        Apresentacao6 = c.String(maxLength: 80, unicode: false),
                        Apresentacao7 = c.String(maxLength: 80, unicode: false),
                        Apresentacao8 = c.String(maxLength: 80, unicode: false),
                        Apresentacao9 = c.String(maxLength: 80, unicode: false),
                        Apresentacao10 = c.String(maxLength: 80, unicode: false),
                        Apresentacao11 = c.String(maxLength: 80, unicode: false),
                    })
                .PrimaryKey(t => t.ApresentacaoId);
            
            CreateTable(
                "dbo.AtbEmUso",
                c => new
                    {
                        AtbEmUsoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 50, unicode: false),
                        DataInicio = c.DateTime(nullable: false),
                        PacienteId = c.Guid(nullable: false),
                        ProntuarioGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.AtbEmUsoId)
                .ForeignKey("dbo.Paciente", t => t.PacienteId)
                .ForeignKey("dbo.Prontuario", t => t.ProntuarioGuid)
                .Index(t => t.PacienteId)
                .Index(t => t.ProntuarioGuid);
            
            CreateTable(
                "dbo.AtbJaUtilizado",
                c => new
                    {
                        AtbJaUtilizadoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 50, unicode: false),
                        PacienteId = c.Guid(nullable: false),
                        ProntuarioGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.AtbJaUtilizadoId)
                .ForeignKey("dbo.Paciente", t => t.PacienteId)
                .ForeignKey("dbo.Prontuario", t => t.ProntuarioGuid)
                .Index(t => t.PacienteId)
                .Index(t => t.ProntuarioGuid);
            
            CreateTable(
                "dbo.AuxUniGeog",
                c => new
                    {
                        UnidadeGeograficaId = c.Int(nullable: false, identity: true),
                        Cep = c.String(nullable: false, maxLength: 9, unicode: false),
                        Logradouro = c.String(nullable: false, maxLength: 120, unicode: false),
                        Complemento = c.String(maxLength: 120, unicode: false),
                        Local = c.String(maxLength: 120, unicode: false),
                        IdUf = c.Int(nullable: false),
                        IdCidade = c.Int(nullable: false),
                        IdBairro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UnidadeGeograficaId);
            
            CreateTable(
                "dbo.Bairro",
                c => new
                    {
                        BairroId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 60, unicode: false),
                        IdCidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BairroId);
            
            CreateTable(
                "dbo.BalancoHidrico",
                c => new
                    {
                        BalancoHidricoId = c.Int(nullable: false, identity: true),
                        PacienteId = c.Guid(nullable: false),
                        ProntuarioGuid = c.Guid(nullable: false),
                        DataBalancoHidrico = c.DateTime(nullable: false),
                        PicosFebris = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Diurese = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Febre = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Dialise = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BhParcial = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BhCumulativo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Creatinina = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BalancoHidricoId)
                .ForeignKey("dbo.Paciente", t => t.PacienteId)
                .ForeignKey("dbo.Prontuario", t => t.ProntuarioGuid)
                .Index(t => t.PacienteId)
                .Index(t => t.ProntuarioGuid);
            
            CreateTable(
                "dbo.BaseDeConhecimento",
                c => new
                    {
                        BaseDeConhecimentoId = c.Int(nullable: false, identity: true),
                        Pergunta = c.String(nullable: false, maxLength: 150, unicode: false),
                        Resposta = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.BaseDeConhecimentoId);
            
            CreateTable(
                "dbo.ChamadaMedico",
                c => new
                    {
                        ChamadaMedicoId = c.Int(nullable: false, identity: true),
                        Mensagem = c.String(nullable: false, maxLength: 150, unicode: false),
                        DataChamada = c.DateTime(nullable: false),
                        Medico = c.String(nullable: false, maxLength: 80, unicode: false),
                        Leito = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.ChamadaMedicoId);
            
            CreateTable(
                "dbo.CidAdaptada",
                c => new
                    {
                        CidAdaptadaId = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 5, unicode: false),
                        Diagnostico = c.String(nullable: false, maxLength: 300, unicode: false),
                    })
                .PrimaryKey(t => t.CidAdaptadaId);
            
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        CidadeId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 35, unicode: false),
                        IdUf = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CidadeId);
            
            CreateTable(
                "dbo.Classe",
                c => new
                    {
                        ClasseId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 60, unicode: false),
                    })
                .PrimaryKey(t => t.ClasseId);
            
            CreateTable(
                "dbo.Complicacao",
                c => new
                    {
                        ComplicacaoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 80, unicode: false),
                    })
                .PrimaryKey(t => t.ComplicacaoId);
            
            CreateTable(
                "dbo.Contato",
                c => new
                    {
                        ContatoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 80, unicode: false),
                        Telefone = c.String(maxLength: 80, unicode: false),
                        Data = c.String(maxLength: 80, unicode: false),
                        Operadora = c.String(maxLength: 80, unicode: false),
                    })
                .PrimaryKey(t => t.ContatoId);
            
            CreateTable(
                "dbo.ContraIndicacao",
                c => new
                    {
                        ContraIndicacaoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 2000, unicode: false),
                        IdGenerico = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContraIndicacaoId)
                .ForeignKey("dbo.Generico", t => t.IdGenerico)
                .Index(t => t.IdGenerico);
            
            CreateTable(
                "dbo.Dieta",
                c => new
                    {
                        DietaId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 12, unicode: false),
                    })
                .PrimaryKey(t => t.DietaId);
            
            CreateTable(
                "dbo.Dreno",
                c => new
                    {
                        DrenoId = c.Int(nullable: false, identity: true),
                        PacienteId = c.Guid(nullable: false),
                        ProntuarioGuid = c.Guid(nullable: false),
                        IdTipoDreno = c.Int(nullable: false),
                        Local = c.String(nullable: false, maxLength: 35, unicode: false),
                        DataInsercao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DrenoId)
                .ForeignKey("dbo.Paciente", t => t.PacienteId)
                .ForeignKey("dbo.Prontuario", t => t.ProntuarioGuid)
                .ForeignKey("dbo.TipoDreno", t => t.IdTipoDreno)
                .Index(t => t.PacienteId)
                .Index(t => t.ProntuarioGuid)
                .Index(t => t.IdTipoDreno);
            
            CreateTable(
                "dbo.TipoDreno",
                c => new
                    {
                        TipoDrenoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 25, unicode: false),
                    })
                .PrimaryKey(t => t.TipoDrenoId);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        EnderecoId = c.Int(nullable: false, identity: true),
                        PacienteId = c.Guid(nullable: false),
                        IdUf = c.Int(nullable: false),
                        IdCidade = c.Int(nullable: false),
                        IdBairro = c.Int(nullable: false),
                        Local = c.String(nullable: false, maxLength: 80, unicode: false),
                        Numero = c.String(maxLength: 80, unicode: false),
                        Complemento = c.String(maxLength: 80, unicode: false),
                        Referencia = c.String(maxLength: 80, unicode: false),
                        Cep = c.String(nullable: false, maxLength: 9, unicode: false),
                    })
                .PrimaryKey(t => t.EnderecoId)
                .ForeignKey("dbo.Bairro", t => t.IdBairro)
                .ForeignKey("dbo.Cidade", t => t.IdCidade)
                .ForeignKey("dbo.Paciente", t => t.PacienteId)
                .ForeignKey("dbo.Uf", t => t.IdUf)
                .Index(t => t.PacienteId)
                .Index(t => t.IdUf)
                .Index(t => t.IdCidade)
                .Index(t => t.IdBairro);
            
            CreateTable(
                "dbo.Uf",
                c => new
                    {
                        UfId = c.Int(nullable: false, identity: true),
                        Sigla = c.String(nullable: false, maxLength: 2, unicode: false),
                        Estado = c.String(nullable: false, maxLength: 40, unicode: false),
                        CodigoEstado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UfId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100, unicode: false),
                        Description = c.String(maxLength: 250, unicode: false),
                        StartAt = c.DateTime(nullable: false),
                        EndAt = c.DateTime(nullable: false),
                        IsFullDay = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.ExameDeImagem",
                c => new
                    {
                        ExameDeImagemId = c.Int(nullable: false, identity: true),
                        PacienteId = c.Guid(nullable: false),
                        ProntuarioGuid = c.Guid(nullable: false),
                        Exame = c.String(nullable: false, maxLength: 40, unicode: false),
                        PedidoEm = c.DateTime(nullable: false),
                        RealizadoEm = c.DateTime(),
                        LaudoEssencial = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.ExameDeImagemId)
                .ForeignKey("dbo.Paciente", t => t.PacienteId)
                .ForeignKey("dbo.Prontuario", t => t.ProntuarioGuid)
                .Index(t => t.PacienteId)
                .Index(t => t.ProntuarioGuid);
            
            CreateTable(
                "dbo.ExameDescricao",
                c => new
                    {
                        ExameDescricaoId = c.Int(nullable: false, identity: true),
                        Exame = c.String(maxLength: 60, unicode: false),
                    })
                .PrimaryKey(t => t.ExameDescricaoId);
            
            CreateTable(
                "dbo.Fisioterapia",
                c => new
                    {
                        FisioterapiaId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 35, unicode: false),
                    })
                .PrimaryKey(t => t.FisioterapiaId);
            
            CreateTable(
                "dbo.HistoriaPatologicaPregressa",
                c => new
                    {
                        HistoriaPatologicaPregressaId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 80, unicode: false),
                    })
                .PrimaryKey(t => t.HistoriaPatologicaPregressaId);
            
            CreateTable(
                "dbo.InteracaoMedicamentosa",
                c => new
                    {
                        InteracaoMedicamentosaId = c.Int(nullable: false, identity: true),
                        IdMedicamentoA = c.Int(nullable: false),
                        IdMedicamentoB = c.Int(nullable: false),
                        Interacao = c.String(nullable: false, maxLength: 4000, unicode: false),
                    })
                .PrimaryKey(t => t.InteracaoMedicamentosaId)
                .ForeignKey("dbo.Generico", t => t.IdMedicamentoA)
                .ForeignKey("dbo.Generico", t => t.IdMedicamentoB)
                .Index(t => t.IdMedicamentoA)
                .Index(t => t.IdMedicamentoB);
            
            CreateTable(
                "dbo.Invasoes",
                c => new
                    {
                        InvasoesId = c.Guid(nullable: false),
                        ProntuarioGuid = c.Guid(nullable: false),
                        PacienteId = c.Guid(nullable: false),
                        Pam = c.String(maxLength: 50, unicode: false),
                        PamData = c.DateTime(),
                        Hemodialise = c.String(maxLength: 50, unicode: false),
                        HemodialiseData = c.DateTime(),
                        ViaAerea = c.String(maxLength: 50, unicode: false),
                        ViaAereaData = c.DateTime(),
                        ViaDigestiva = c.String(maxLength: 50, unicode: false),
                        ViaDigestivaData = c.DateTime(),
                        AcessoVenoso = c.String(maxLength: 50, unicode: false),
                        AcessoVenosoData = c.DateTime(),
                        Marcapasso = c.String(maxLength: 50, unicode: false),
                        MarcapassoData = c.DateTime(),
                        ViaUrinaria = c.String(maxLength: 50, unicode: false),
                        ViaUrinariaData = c.DateTime(),
                        Pic = c.String(maxLength: 50, unicode: false),
                        Pia = c.String(maxLength: 50, unicode: false),
                        PicData = c.DateTime(),
                        PiaData = c.DateTime(),
                        Anticoagulacao = c.String(maxLength: 25, unicode: false),
                    })
                .PrimaryKey(t => t.InvasoesId)
                .ForeignKey("dbo.Paciente", t => t.PacienteId)
                .ForeignKey("dbo.ProntuarioBase", t => t.ProntuarioGuid)
                .Index(t => t.ProntuarioGuid)
                .Index(t => t.PacienteId);
            
            CreateTable(
                "dbo.ProntuarioBase",
                c => new
                    {
                        ProntuarioId = c.Guid(nullable: false),
                        PacienteId = c.Guid(nullable: false),
                        DataProntuario = c.DateTime(nullable: false),
                        NumAtendimento = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.ProntuarioId)
                .ForeignKey("dbo.Paciente", t => t.PacienteId)
                .Index(t => t.PacienteId);
            
            CreateTable(
                "dbo.MedicamentoAjustes",
                c => new
                    {
                        MedicamentoAjustesId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 1500, unicode: false),
                        IdMedicamento = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicamentoAjustesId)
                .ForeignKey("dbo.Medicamento", t => t.IdMedicamento)
                .Index(t => t.IdMedicamento);
            
            CreateTable(
                "dbo.MedicamentoApresentacao",
                c => new
                    {
                        MedicamentoApresentacaoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 800, unicode: false),
                        IdMedicamento = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicamentoApresentacaoId)
                .ForeignKey("dbo.Medicamento", t => t.IdMedicamento)
                .Index(t => t.IdMedicamento);
            
            CreateTable(
                "dbo.Mural",
                c => new
                    {
                        MuralId = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Titulo = c.String(nullable: false, maxLength: 30, unicode: false),
                        Aviso = c.String(nullable: false, maxLength: 335, unicode: false),
                        Autor = c.String(nullable: false, maxLength: 28, unicode: false),
                        Email = c.String(maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.MuralId);
            
            CreateTable(
                "dbo.NotificacoesProntuario",
                c => new
                    {
                        NotificacoesProntuarioId = c.Guid(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Mensagem = c.String(nullable: false, maxLength: 65, unicode: false),
                        Link = c.String(maxLength: 1000, unicode: false),
                    })
                .PrimaryKey(t => t.NotificacoesProntuarioId);
            
            CreateTable(
                "dbo.Operadora",
                c => new
                    {
                        OperadoraId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 80, unicode: false),
                        Codigo = c.String(maxLength: 80, unicode: false),
                        Categoria = c.String(maxLength: 80, unicode: false),
                        Preco = c.String(maxLength: 80, unicode: false),
                    })
                .PrimaryKey(t => t.OperadoraId);
            
            CreateTable(
                "dbo.Parametro",
                c => new
                    {
                        ParametroId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 50, unicode: false),
                        Minimo = c.Double(nullable: false),
                        Maximo = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ParametroId);
            
            CreateTable(
                "dbo.Precaucao",
                c => new
                    {
                        PrecaucaoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 80, unicode: false),
                        IdTipoPrecaucao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PrecaucaoId)
                .ForeignKey("dbo.TipoDePrecaucao", t => t.IdTipoPrecaucao)
                .Index(t => t.IdTipoPrecaucao);
            
            CreateTable(
                "dbo.TipoDePrecaucao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Prescricao",
                c => new
                    {
                        PrescricaoId = c.Guid(nullable: false),
                        PacienteId = c.Guid(nullable: false),
                        ProntuarioGuid = c.Guid(nullable: false),
                        DataPrescricao = c.DateTime(nullable: false),
                        Dieta = c.String(maxLength: 12, unicode: false),
                        DietaSondaGastrica = c.String(maxLength: 25, unicode: false),
                        DietaConsistencia = c.String(maxLength: 80, unicode: false),
                        DietaComorbidade = c.String(maxLength: 80, unicode: false),
                        DietaVolume = c.String(maxLength: 80, unicode: false),
                        Hidratacao = c.String(maxLength: 80, unicode: false),
                        HidratacaoVolume = c.String(maxLength: 80, unicode: false),
                        NebulizacaoIntervalo = c.String(maxLength: 80, unicode: false),
                        Berotec = c.String(maxLength: 20, unicode: false),
                        BerotecGotas = c.Int(nullable: false),
                        Atrovent = c.String(maxLength: 20, unicode: false),
                        AtroventGotas = c.Int(nullable: false),
                        Fluimucil = c.String(maxLength: 20, unicode: false),
                        FluimucilGotas = c.Int(nullable: false),
                        Sf09 = c.String(maxLength: 20, unicode: false),
                        Sf09Gotas = c.Int(nullable: false),
                        Antiacido = c.String(maxLength: 20, unicode: false),
                        AntiacidoPosologia = c.String(maxLength: 80, unicode: false),
                        Anticoagulacao = c.String(maxLength: 20, unicode: false),
                        AnticoagulacaoPosologia = c.String(maxLength: 80, unicode: false),
                        Procinetico = c.String(maxLength: 20, unicode: false),
                        ProcineticoIntervalo = c.String(maxLength: 80, unicode: false),
                        Amiodarana = c.Boolean(nullable: false),
                        Dobutamina = c.Boolean(nullable: false),
                        Dopamina = c.Boolean(nullable: false),
                        Noradrenalina = c.Boolean(nullable: false),
                        Nitroprussiato = c.Boolean(nullable: false),
                        Nitroglicerina = c.Boolean(nullable: false),
                        Midazolam = c.Boolean(nullable: false),
                        Fentanil = c.Boolean(nullable: false),
                        GlicemiaCapilar = c.String(maxLength: 25, unicode: false),
                        InsulinaRegular = c.String(maxLength: 25, unicode: false),
                        Oxigenoterapia = c.String(maxLength: 25, unicode: false),
                        Fisioterapia = c.String(maxLength: 25, unicode: false),
                        FebreDor = c.String(maxLength: 25, unicode: false),
                        Emese = c.String(maxLength: 25, unicode: false),
                        Captopril = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PrescricaoId)
                .ForeignKey("dbo.Paciente", t => t.PacienteId)
                .ForeignKey("dbo.Prontuario", t => t.ProntuarioGuid)
                .Index(t => t.PacienteId)
                .Index(t => t.ProntuarioGuid);
            
            CreateTable(
                "dbo.ProntuarioPrecaucao",
                c => new
                    {
                        ProntuarioPrecaucaoId = c.Int(nullable: false, identity: true),
                        IdPrecaucao = c.Int(nullable: false),
                        IdTipoPrecaucao = c.Int(nullable: false),
                        PacienteId = c.Guid(nullable: false),
                        ProntuarioGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ProntuarioPrecaucaoId)
                .ForeignKey("dbo.Paciente", t => t.PacienteId)
                .ForeignKey("dbo.Precaucao", t => t.IdPrecaucao)
                .ForeignKey("dbo.Prontuario", t => t.ProntuarioGuid)
                .ForeignKey("dbo.TipoDePrecaucao", t => t.IdTipoPrecaucao)
                .Index(t => t.IdPrecaucao)
                .Index(t => t.IdTipoPrecaucao)
                .Index(t => t.PacienteId)
                .Index(t => t.ProntuarioGuid);
            
            CreateTable(
                "dbo.SinaisVitais",
                c => new
                    {
                        SinaisVitaisId = c.Int(nullable: false, identity: true),
                        PacienteId = c.Guid(nullable: false),
                        ProntuarioGuid = c.Guid(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Hora = c.String(nullable: false, maxLength: 5, unicode: false),
                        Entubado = c.String(nullable: false, maxLength: 3, unicode: false),
                        PressaoArterialSistolica = c.Int(nullable: false),
                        PressaoArterialDiastolica = c.Int(nullable: false),
                        FrequenciaCardiaca = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FrequenciaRespiratoria = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TemperaturaAxilar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SaturacaoOxigeno = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pvc = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pic = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GlicemiaCapilar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Insulina = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Glicose = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SinaisVitaisId)
                .ForeignKey("dbo.Paciente", t => t.PacienteId)
                .ForeignKey("dbo.Prontuario", t => t.ProntuarioGuid)
                .Index(t => t.PacienteId)
                .Index(t => t.ProntuarioGuid);
            
            CreateTable(
                "dbo.TabelasBase",
                c => new
                    {
                        TabelasBaseId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 40, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 70, unicode: false),
                        Action = c.String(nullable: false, maxLength: 60, unicode: false),
                        Controller = c.String(nullable: false, maxLength: 60, unicode: false),
                        Ativa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TabelasBaseId);
            
            CreateTable(
                "dbo.TelefonePaciente",
                c => new
                    {
                        TelefonePacienteId = c.Int(nullable: false, identity: true),
                        PacienteId = c.Guid(nullable: false),
                        Ddd = c.String(nullable: false, maxLength: 2, unicode: false),
                        Numero = c.String(nullable: false, maxLength: 10, unicode: false),
                        TipoTelefone = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.TelefonePacienteId)
                .ForeignKey("dbo.Paciente", t => t.PacienteId)
                .Index(t => t.PacienteId);
            
            CreateTable(
                "dbo.TipoTelefone",
                c => new
                    {
                        TipoTelefoneId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 12, unicode: false),
                    })
                .PrimaryKey(t => t.TipoTelefoneId);
            
            CreateTable(
                "dbo.UnidadeGeografica",
                c => new
                    {
                        UnidadeGeograficaId = c.Int(nullable: false, identity: true),
                        Cep = c.String(nullable: false, maxLength: 9, unicode: false),
                        Logradouro = c.String(nullable: false, maxLength: 120, unicode: false),
                        Complemento = c.String(maxLength: 120, unicode: false),
                        Local = c.String(maxLength: 120, unicode: false),
                        IdUf = c.Int(nullable: false),
                        IdCidade = c.Int(nullable: false),
                        IdBairro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UnidadeGeograficaId);
            
            CreateTable(
                "dbo.PessoaFisica",
                c => new
                    {
                        PessoaId = c.Guid(nullable: false),
                        Rg = c.String(maxLength: 14, unicode: false),
                        OrgaoEmissorRg = c.String(maxLength: 10, unicode: false),
                        DataEmissaoRg = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PessoaId)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId)
                .Index(t => t.PessoaId);
            
            CreateTable(
                "dbo.PessoaJuridica",
                c => new
                    {
                        PessoaId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.PessoaId)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId)
                .Index(t => t.PessoaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PessoaJuridica", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.PessoaFisica", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.TelefonePaciente", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.SinaisVitais", "ProntuarioGuid", "dbo.Prontuario");
            DropForeignKey("dbo.SinaisVitais", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.ProntuarioPrecaucao", "IdTipoPrecaucao", "dbo.TipoDePrecaucao");
            DropForeignKey("dbo.ProntuarioPrecaucao", "ProntuarioGuid", "dbo.Prontuario");
            DropForeignKey("dbo.ProntuarioPrecaucao", "IdPrecaucao", "dbo.Precaucao");
            DropForeignKey("dbo.ProntuarioPrecaucao", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.Prescricao", "ProntuarioGuid", "dbo.Prontuario");
            DropForeignKey("dbo.Prescricao", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.Precaucao", "IdTipoPrecaucao", "dbo.TipoDePrecaucao");
            DropForeignKey("dbo.MedicamentoApresentacao", "IdMedicamento", "dbo.Medicamento");
            DropForeignKey("dbo.MedicamentoAjustes", "IdMedicamento", "dbo.Medicamento");
            DropForeignKey("dbo.Invasoes", "ProntuarioGuid", "dbo.ProntuarioBase");
            DropForeignKey("dbo.ProntuarioBase", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.Invasoes", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.InteracaoMedicamentosa", "IdMedicamentoB", "dbo.Generico");
            DropForeignKey("dbo.InteracaoMedicamentosa", "IdMedicamentoA", "dbo.Generico");
            DropForeignKey("dbo.ExameDeImagem", "ProntuarioGuid", "dbo.Prontuario");
            DropForeignKey("dbo.ExameDeImagem", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.Endereco", "IdUf", "dbo.Uf");
            DropForeignKey("dbo.Endereco", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.Endereco", "IdCidade", "dbo.Cidade");
            DropForeignKey("dbo.Endereco", "IdBairro", "dbo.Bairro");
            DropForeignKey("dbo.Dreno", "IdTipoDreno", "dbo.TipoDreno");
            DropForeignKey("dbo.Dreno", "ProntuarioGuid", "dbo.Prontuario");
            DropForeignKey("dbo.Dreno", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.ContraIndicacao", "IdGenerico", "dbo.Generico");
            DropForeignKey("dbo.BalancoHidrico", "ProntuarioGuid", "dbo.Prontuario");
            DropForeignKey("dbo.BalancoHidrico", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.AtbJaUtilizado", "ProntuarioGuid", "dbo.Prontuario");
            DropForeignKey("dbo.AtbJaUtilizado", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.AtbEmUso", "ProntuarioGuid", "dbo.Prontuario");
            DropForeignKey("dbo.AtbEmUso", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.ApresentacaoAjusteInteracao", "ProntuarioGuid", "dbo.Prontuario");
            DropForeignKey("dbo.Prontuario", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.ApresentacaoAjusteInteracao", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.ApresentacaoAjusteInteracao", "IdPosologia", "dbo.MedicamentoPosologia");
            DropForeignKey("dbo.MedicamentoPosologia", "IdMedicamento", "dbo.Medicamento");
            DropForeignKey("dbo.ApresentacaoAjusteInteracao", "IdMedicamento", "dbo.Medicamento");
            DropForeignKey("dbo.Medicamento", "IdGenerico", "dbo.Generico");
            DropForeignKey("dbo.Agendamento", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.Agendamento", "MedicoId", "dbo.Medicos");
            DropForeignKey("dbo.Medicos", "MedicoId", "dbo.PessoaFisica");
            DropForeignKey("dbo.Paciente", "SetorId", "dbo.Setor");
            DropForeignKey("dbo.ResultadoExame", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.ResultadoExame", "MedicoId", "dbo.Medicos");
            DropForeignKey("dbo.ResultadoExame", "IdExameParametros", "dbo.ExameParametros");
            DropForeignKey("dbo.Paciente", "PacienteId", "dbo.PessoaFisica");
            DropForeignKey("dbo.Paciente", "LeitoId", "dbo.Leito");
            DropForeignKey("dbo.Paciente", "EstadoPacienteId", "dbo.EstadoDoPaciente");
            DropForeignKey("dbo.Paciente", "ConvenioId", "dbo.Convenio");
            DropForeignKey("dbo.Medicos", "EspecialidadeId", "dbo.Especialidade");
            DropIndex("dbo.PessoaJuridica", new[] { "PessoaId" });
            DropIndex("dbo.PessoaFisica", new[] { "PessoaId" });
            DropIndex("dbo.TelefonePaciente", new[] { "PacienteId" });
            DropIndex("dbo.SinaisVitais", new[] { "ProntuarioGuid" });
            DropIndex("dbo.SinaisVitais", new[] { "PacienteId" });
            DropIndex("dbo.ProntuarioPrecaucao", new[] { "ProntuarioGuid" });
            DropIndex("dbo.ProntuarioPrecaucao", new[] { "PacienteId" });
            DropIndex("dbo.ProntuarioPrecaucao", new[] { "IdTipoPrecaucao" });
            DropIndex("dbo.ProntuarioPrecaucao", new[] { "IdPrecaucao" });
            DropIndex("dbo.Prescricao", new[] { "ProntuarioGuid" });
            DropIndex("dbo.Prescricao", new[] { "PacienteId" });
            DropIndex("dbo.Precaucao", new[] { "IdTipoPrecaucao" });
            DropIndex("dbo.MedicamentoApresentacao", new[] { "IdMedicamento" });
            DropIndex("dbo.MedicamentoAjustes", new[] { "IdMedicamento" });
            DropIndex("dbo.ProntuarioBase", new[] { "PacienteId" });
            DropIndex("dbo.Invasoes", new[] { "PacienteId" });
            DropIndex("dbo.Invasoes", new[] { "ProntuarioGuid" });
            DropIndex("dbo.InteracaoMedicamentosa", new[] { "IdMedicamentoB" });
            DropIndex("dbo.InteracaoMedicamentosa", new[] { "IdMedicamentoA" });
            DropIndex("dbo.ExameDeImagem", new[] { "ProntuarioGuid" });
            DropIndex("dbo.ExameDeImagem", new[] { "PacienteId" });
            DropIndex("dbo.Endereco", new[] { "IdBairro" });
            DropIndex("dbo.Endereco", new[] { "IdCidade" });
            DropIndex("dbo.Endereco", new[] { "IdUf" });
            DropIndex("dbo.Endereco", new[] { "PacienteId" });
            DropIndex("dbo.Dreno", new[] { "IdTipoDreno" });
            DropIndex("dbo.Dreno", new[] { "ProntuarioGuid" });
            DropIndex("dbo.Dreno", new[] { "PacienteId" });
            DropIndex("dbo.ContraIndicacao", new[] { "IdGenerico" });
            DropIndex("dbo.BalancoHidrico", new[] { "ProntuarioGuid" });
            DropIndex("dbo.BalancoHidrico", new[] { "PacienteId" });
            DropIndex("dbo.AtbJaUtilizado", new[] { "ProntuarioGuid" });
            DropIndex("dbo.AtbJaUtilizado", new[] { "PacienteId" });
            DropIndex("dbo.AtbEmUso", new[] { "ProntuarioGuid" });
            DropIndex("dbo.AtbEmUso", new[] { "PacienteId" });
            DropIndex("dbo.Prontuario", new[] { "PacienteId" });
            DropIndex("dbo.MedicamentoPosologia", new[] { "IdMedicamento" });
            DropIndex("dbo.Medicamento", new[] { "IdGenerico" });
            DropIndex("dbo.ApresentacaoAjusteInteracao", new[] { "ProntuarioGuid" });
            DropIndex("dbo.ApresentacaoAjusteInteracao", new[] { "PacienteId" });
            DropIndex("dbo.ApresentacaoAjusteInteracao", new[] { "IdPosologia" });
            DropIndex("dbo.ApresentacaoAjusteInteracao", new[] { "IdMedicamento" });
            DropIndex("dbo.ResultadoExame", new[] { "MedicoId" });
            DropIndex("dbo.ResultadoExame", new[] { "IdExameParametros" });
            DropIndex("dbo.ResultadoExame", new[] { "PacienteId" });
            DropIndex("dbo.Paciente", new[] { "SetorId" });
            DropIndex("dbo.Paciente", new[] { "EstadoPacienteId" });
            DropIndex("dbo.Paciente", new[] { "LeitoId" });
            DropIndex("dbo.Paciente", new[] { "ConvenioId" });
            DropIndex("dbo.Paciente", new[] { "PacienteId" });
            DropIndex("dbo.Medicos", new[] { "EspecialidadeId" });
            DropIndex("dbo.Medicos", new[] { "MedicoId" });
            DropIndex("dbo.Agendamento", new[] { "MedicoId" });
            DropIndex("dbo.Agendamento", new[] { "PacienteId" });
            DropTable("dbo.PessoaJuridica");
            DropTable("dbo.PessoaFisica");
            DropTable("dbo.UnidadeGeografica");
            DropTable("dbo.TipoTelefone");
            DropTable("dbo.TelefonePaciente");
            DropTable("dbo.TabelasBase");
            DropTable("dbo.SinaisVitais");
            DropTable("dbo.ProntuarioPrecaucao");
            DropTable("dbo.Prescricao");
            DropTable("dbo.TipoDePrecaucao");
            DropTable("dbo.Precaucao");
            DropTable("dbo.Parametro");
            DropTable("dbo.Operadora");
            DropTable("dbo.NotificacoesProntuario");
            DropTable("dbo.Mural");
            DropTable("dbo.MedicamentoApresentacao");
            DropTable("dbo.MedicamentoAjustes");
            DropTable("dbo.ProntuarioBase");
            DropTable("dbo.Invasoes");
            DropTable("dbo.InteracaoMedicamentosa");
            DropTable("dbo.HistoriaPatologicaPregressa");
            DropTable("dbo.Fisioterapia");
            DropTable("dbo.ExameDescricao");
            DropTable("dbo.ExameDeImagem");
            DropTable("dbo.Events");
            DropTable("dbo.Uf");
            DropTable("dbo.Endereco");
            DropTable("dbo.TipoDreno");
            DropTable("dbo.Dreno");
            DropTable("dbo.Dieta");
            DropTable("dbo.ContraIndicacao");
            DropTable("dbo.Contato");
            DropTable("dbo.Complicacao");
            DropTable("dbo.Classe");
            DropTable("dbo.Cidade");
            DropTable("dbo.CidAdaptada");
            DropTable("dbo.ChamadaMedico");
            DropTable("dbo.BaseDeConhecimento");
            DropTable("dbo.BalancoHidrico");
            DropTable("dbo.Bairro");
            DropTable("dbo.AuxUniGeog");
            DropTable("dbo.AtbJaUtilizado");
            DropTable("dbo.AtbEmUso");
            DropTable("dbo.ApresentacaoAux");
            DropTable("dbo.Prontuario");
            DropTable("dbo.MedicamentoPosologia");
            DropTable("dbo.Generico");
            DropTable("dbo.Medicamento");
            DropTable("dbo.ApresentacaoAjusteInteracao");
            DropTable("dbo.Anticoagulacao");
            DropTable("dbo.Alergia");
            DropTable("dbo.Setor");
            DropTable("dbo.ExameParametros");
            DropTable("dbo.ResultadoExame");
            DropTable("dbo.Leito");
            DropTable("dbo.EstadoDoPaciente");
            DropTable("dbo.Convenio");
            DropTable("dbo.Paciente");
            DropTable("dbo.Pessoa");
            DropTable("dbo.Especialidade");
            DropTable("dbo.Medicos");
            DropTable("dbo.Agendamento");
            DropTable("dbo.Acesso");
        }
    }
}
