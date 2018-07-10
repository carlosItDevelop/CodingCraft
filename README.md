
#Repositório Oficial do Projeto Hospital Management - Com a Consultoria de CodingCraft


##Diário de Bordo e Tasklist do Sistema HospitalManagement-Sys;
### Lista de tarefas pendentes e releases do aplicativo:

```html
- [x] Criação do 1º Service no Angular, que passará a ser nosso Frontend (Modulo: Genérico) - mai/2016;
- [x] RederScript na _Layout.cshtml - @Scripts.Render("~/bundles/core") e @Scripts.Render("~/bundles/datatableswithtools"); 
na MasterPage resolveu o problema de travamento do menu na Lista Anticoagulante e deve recolver nas outras também sem a TableTools. (Modulo: _Laout.cshtml
) - mai/2016
- [x] Meu módulo principal (AngularJS 1.5.x), chamado na tag <Html> da _ Layout.cshtml: var app = angular.module("App", ["ngMessages"]) - maio/2016;
- [x] Acertar o CRUD de Medico;
- [x] Isolar a Camada do Identity num projeto separado e desacoplado;
- [x] Criar a Tabela Usuário e decidir sobre duas possibilidades (ou criar na mesma instnca do AspNetUser, com campos virtuais, - [x] Implementar Services e Autorização por Claims em memória;
- [x] Validar CRUD de Medico;
- [x] Normalizar Precauções > dados de pesquisas no lugar da checkbox: (Padrão, Contato, Gotícula e Aerozol) > Tabelas relacionadas para cada caso; (continua abaixo...)
- [x] Desacolar Exame de Imagens de Prontuario;
- [x] Formatar Dt-Nascimento em Medico.cshtml - Por enquanto tenho de digitar (NÃO selecionar) e no formato "yyyy-mm-dd";
- [ ] Por mascara de edição em campos como Telefone, Cpf, etc.
- [x] Alergia deve ser informada em Cadastro de Pacientes pelo atendente técnico, enfermagem ou médico de plantão;
- [ ] O Campo Leito deve ser suburdinado à Setor. Ou seja cada setor tem seus leitos vinculados. (Modulo: Cadastro de Leitos e todas as tabelas relacionadas);
- [ ] Em Sinais Vitais usar o padrão de edição de paciente, com div de adição/edição;
- [x] Hepatopatia, Gravidez e Amamentação (em prontuário) não podem ser auto-excludentes > Trocar radiobutton por checkbox, pois estes três casos implicam no Re-Ajuste;
- [ ] Ao selecionar Paciente (prontuario) o GUID de prontuário some;
- [ ] Labels de Hidratação em Prescrição sumiu....?!?!?!?!;
- [x] Criar divs ou Tabs para adição/edição de endereço e telefones no cadastro de pacientes;
- [ ] Gravar um vídeo com as alterações em dreno, explicando porque o desenho do caso de uso é tão importante + defirença > Desktop vs Web;
- [x] Pesquisar uns Boxies bacana com Boostrap;
- [ ] Em telefone add o botao está habilitado indevidamente;
- [ ] Por MaxLength nos campos direto no (cs)HTML. Validação Inteligente;
- [ ] Retirar GetDdList() do Index de Prescricao > Escrever com AngularJS;
- [ ] Todos os CRUDs acima serão recliados numa única tabela com todos os dados, somados a uma nova coluna com o tipo de precaução;
- [ ] Parametrizar a paginação > Deixar esta opção em Configurações com acesso livre para os usuários (Ideia do Wallace);
- [ ] Verificar todos os Ids de todas as tabelas, pois em alguns casos os mesmos pularam para 1000 + último Id da PK;
- [ ] Validação NÃO está funcionando em "PartialsLayout/_TelefonePaciente.cshtml", inclusive o pattern: ng-pattern="/^\d{4,5}-\d{4}$/";
- [x] Criar duas Tabs em Paciente, para Telefone e Edendereço;
ou criar um modelo separado e ter uma chave estrangeira para vincular com o IdentityUser);
- [ ] Mudar as class CSS das tables. Tirar table-hover e por table-bordered, pois fica muito melhor;
- [x] Implementar Services e Autorização por Claims na tela e gravar no database;
- [ ] Ajustar LEIAME.md com as novas telas e Features de Autorização;

- [ ] O Guid do Novo prontuario será seu Key Id;
- [ ] Todas as tabelas relacionadas com prontuarios deverão sofrer ajustes para ter o Id(Guid) do Paciente e do Prontuario, pois a relação de Paciente para Prontuario é de OneToMany;
- [ ] Mdelos BHidrico e EImagens com ProntuarioGuid e PacienteGuid, falta preparar a listagem das Telas, que já são chamadas de Pacientes e faltam ser chamadas do menu leff;
- [ ] Usar Ajax Begin Form para Cadastro de Cid e depois em Endereços;
- [x] Implementar busca com Ajax PartialView com post em ajax em UniGeog;
- [ ] Implementar busca com Ajax PartialView com post em ajax em Bairro;
- [ ] Implementar busca com Ajax PartialView com post em ajax em Cidade;
- [ ] Implementar busca com Ajax PartialView com post em ajax em Uf;
- [ ] Implementar busca com select2 em Paciente (on('change'));
- [x] Por os métodos API do controller UnidadeGeografica em ApiResources, pois o controller de UG será apagado e sua implementação em AngulaJS também, assim como seu Ctrl e Service;
- [x] Ao fazer uma busca em UniGeog, preciso fazer com que a paginação obedeça a busca, pois só chama o parâmetro pagina;
- [ ] Conferir campo ?? em Prontuário, e/ou, Paciente;
- [ ] Antes de acionar Editar ou Adicionar pacientes, a aba Diagnóstico não pode estar editável;
- [ ] reescrever Uf, Cidade e Bairro, pois não ha performance na atual implementação;
- [ ] select2 em Medicamentos e genéricos;
- [ ] Em Ajustes deve ser selecionado o genérico e não o medicamento. Isso pode ser bem fácil com o select2;

- [ ] paciente populado, após seleção, via Angular e não pelo DOM do JavaScript;
- [ ] Por uma borda com radius 1 na tela de TFA em profile para dividir da tela com a img de perfil;
- [ ] Acabar com a Aba Cabeçalho em Pontuario/Evolucao e por um botão para visualizar os dados em Modal Angular. Já temos esses dados em Paciente;
- [ ] Criar uma div invisível com waiting... após login. Ela só esconde o login com a mensagem "Carregando Configurações do Sistema. Aguarde".
- [ ] Criar o assert que calcula a idade e atrinui ao paciente;
- [ ] Por Idade no Paciente (readonly) e depois calcular;
- [ ] Por SweetAlert nos botões de excluir das tables em AngulaJS. Matar esse pendência logo;
- [ ] Conferir os CRUDs de Cidade, Uf e Bairro para depois consertar o Endereço.
- [ ] Começar a Migrar os Id de int para Guid em Paciente, Prontuario, Prescricao e tabelas relacionadas;


- [x] Criar a tela Lista todos os Prontuarios;
- [x] Criar o campo PacienteGuid em Prescricao;
- [x] Excluir listagem na parte inferior de Prontuario, Prescricao, BalancoHidrico e E.Imagem;
- [x] Em BalancoHidrico, SinaisVitais e Ex.Imagem precisa haver PacienteGuid e também ProntuarioGuid.
- [x] Criar o CRUD de alergia e retirar o antigo campo Alergia de Paciente;
- [x] História Patológica Pregressa - Criar o Controller MVC5 e suas Actions;
- [x] Formatar as views com Modal;
- [x] Designer Indice/Listar com DataTable no formato do Make-Admin;
- [x] Por a chamada de HPPregressa no SubMenu Configurações;
- [x] Usar select2 para selecioar os dados do DDList;
- [x] Criar função getAllHppregressa em Prontuário para preencher a Coleção que alimentará a DDList, que será lida como TagInputs;
- [x] Desmembrar coleção gravada no campo: prontuario.HistoriaPatologicaPregressa para gravar string, separadas por vírgulas;
- [x] Complicacao, HPPregressa, CodigoCid e Alergia tem de ser migradas de prontuario para paciente;
- [x] OutrasComplicacoes: migrar para paciente;
- [x] Criar o CRUD de Alergia;
- [x] Após criar o CRUD de Alergia, implementar select2;
- [x] Aba Diagnóstico sairá de prontuario e irá para paciente;
- [x] Valor default em OutrasComplicacoes (Gravidez, Amamentacao e Hepatopatia) devem ser false, se Acao === 'Adicionar';
- [x] Pacientes em Prontuario selecionado pelo select2;
- [x] Conferir templates que criei para Modais, Botoes. Estavam preparadas para a nova template (descontinuado);
- [x] [x] SweetAlert - [x] Menu - [x] BundleConfig : Paciente;
- [x] [x] SweetAlert - [x] Menu - [x] BundleConfig : Fisioterapia;
- [x] [x] SweetAlert - [x] Menu - [x] BundleConfig : Dreno;
- [x] [x] SweetAlert - [x] Menu - [x] BundleConfig : Setor;
- [x] [x] SweetAlert - [x] Menu - [x] BundleConfig : TipoDreno;
- [x] [x] SweetAlert - [x] Menu - [x] BundleConfig : Complicacao;
- [x] [x] SweetAlert - [x] Menu - [x] BundleConfig : Uf;
- [x] [x] SweetAlert - [x] Menu - [x] BundleConfig : Cidade;
- [x] [x] SweetAlert - [x] Menu - [x] BundleConfig : Bairro;
- [x] [x] SweetAlert - [x] Menu - [x] BundleConfig : Endereco;
- [x] [x] SweetAlert - [x] Menu - [x] BundleConfig : Anticoagulacao;
- [ ] [x] SweetAlert - [ ] Menu - [x] BundleConfig : PrecaucaoAerosol;
- [ ] [x] SweetAlert - [ ] Menu - [x] BundleConfig : PrecaucaoContato;
- [ ] [x] SweetAlert - [ ] Menu - [x] BundleConfig : PrecaucaoGoticula;
- [ ] [x] SweetAlert - [ ] Menu - [x] BundleConfig : PrecaucaoPadrao;
- [x] [x] SweetAlert - [x] Menu - [x] BundleConfig : Leito;
- [x] [x] SweetAlert - [x] Menu - [x] BundleConfig : Dieta;
- [x] [x] SweetAlert - [x] Menu - [x] BundleConfig : Convenio;
- [x] [x] SweetAlert - [x] Menu - [x] BundleConfig : Genérico;
- [ ] [x] SweetAlert - [x] Menu - [x] BundleConfig : Interacaomedicamentosa;
- [ ] [x] SweetAlert - [ ] Menu - [x] BundleConfig : PrecaucaoCRUD;
- [ ] [x] SweetAlert - [ ] Menu - [x] BundleConfig : ExameDeImagem;
- [ ] [x] SweetAlert - [ ] Menu - [x] BundleConfig : Especialidade;
- [ ] Usar o plugin FluentValidator. Não substituirá o FluentApi, 
	pois ele não modela dados no banco, mas é exelente para validação de regras de negócios!

- [X] Criar um modelo da tela de Acessogeral no Photoshop, pois o CRUD todo é feito 
	em uma única Action, portanto preciso de um modelo visual bem definido;
- [ ] Usar listagem (IEnumrable) de ApplicationUser(UserManager) e Claims, abusando do select2;
- [x] Desabilitar LazyLoading e Proxy no Context de Entities;
- [ ] LazyLoading e Proxy desabilitados não funcionaram adequadamente (REVISAR);

- [ ] Criar um controller AngularJS com as seguintes características;
	> Preciso selecionar Usuários (usar select2);
	> Preciso selecionar(optar) a função {UserBase e FunctionBase};
	> Preciso selecionar Claims em cada linha (adição);
	> Nos radio buttons de acesso : true => 'true';
	> Ao selecionar(optar) AllowAll todos são 'true';
	> Ao adicionar (preciso do button Add) abrir uma <div>, originalmente oculta, com as opções 
		e habilitar 'Atualizar Permissões';
	> Não existe excluir (a priori);

- [ ] Validar tela de Asserts (conferir validações do Claudio);
- [ ] [ ] Usuário - [ ] Funções/Cargos : Validar tela de Controle de Acesso Global;
- [ ] Validar tela de Resultado de Exames;
- [ ] Escolher entre Home/Endereco ou Endereco/Index, respectivamente com Angular e MVC puro;
- [x] Escolher entre Home/UnidadeGeografica ou UniGeog/Index, respectivamente c/ Angular e MVC; (MVC escolhido)
- [x] Subir o Projeto até aqui: 30-06-2017;
- [x] Criar o Upload de imagem para o Perfil de usuário;
- [x] Criar imagem padrão para o Perfil de usuário no Login;
- [x] Criar Página de erro personalizada - Page Not Found 404;
- [x] Criar Modelo Pessoa;
- [x] Criar Enum TipoPessoa, com (Fisica=1, Juridica=2) para evitar que a enumeração seja iniciada por 0(zero), que é o padrão;
- [x] Incluir Enum TipoDePessoa com um método de exibição GetTipoPessoa;
- [x] No Construtor padrão, setar PessoaId e DataInclusao, respectivamente 
com PessoaId = Guid.NewGuid() e DataInclusao com DateTime.Now;
- [x] (conferir) > Os procedimentos do Contrutor Criam um Id para a Pessoa antes de gravá-la, o que facilita 
a pegar seu valor para gravações dos modelos que herdam ou derivam de Pessoa e a DataInclusao deve ser setada 
também na criação do objeto e se for necessário mudar, que seja feito na edição;
- [x] Outra coisa importante em setar Id DtInclusao ao instanciar a classe Pessoa está em não precisar 
desses dados, respectivamente em HttpPost(Create) e na View Create;
- [x] Gerar Guid para o campo PacienteGuid (que será depois PacienteId) e popular a tabela já existente;
- [x] Gerar o Guid antes de gravar paciente (Obs.: Paciente está todo no Angular e o método chamado está em ProntuarioController);
- [ ] Estou usando uma injeção de dependencia do $http em PacienteCtrl. Preciso tirar;
- [x] Criar a tela Lista todos os Prontuarios;
- [ ] Criar Relação de um p/ muitos de paciente para prontuario, pois já populei a tabela de prontuario com os Guids correspondentes...
- [ ] Chamar esta tela de Pacientes e do Menu Prontuario, que deixará de chamar o prontuario até aqui processado para chamar esta lista;
- [ ] O prontuário que sempre foi chamado de principal deverá ser chamado de dois lugares 
>> 1. Prontuário por Paciente, Edição de Prontuario ou Prontuario Novo, que terá seu Guid gerado no Controller MVC;

- [ ][x][ ][ ] - Menu - Migration - OnModelCreating: Usando Fluent API - Especialidade;
- [ ][x][ ][ ] - Menu - Migration - EspecialidadeValidator: Usando FluentValidation - Especialidade;

- [x] Migrando de int Id para Guid;
-----------------------------------
- [x] [x][x][x][x] - Prontuario: Excluir IdPaciente -> ForeignKey para PacienteGuid -> Corrigir as chamadas nos métodos (int p/ Guig) -> Migrations
- [x] [x][x][x][x] - Dreno: Excluir IdPaciente -> ForeignKey para PacienteGuid -> Corrigir as chamadas nos métodos (int p/ Guig) -> Migrations
- [x] [x][x][x][x] - Agendamento: Excluir IdPaciente -> ForeignKey para PacienteGuid -> Corrigir as chamadas nos métodos (int p/ Guig) -> Migrations
- [x] [x][x][x][x] - ApresentacaoAjustes: Excluir IdPaciente -> ForeignKey para PacienteGuid -> Corrigir as chamadas nos métodos (int p/ Guig) -> Migrations
- [x] [x][x][x][x] - AtbEmUso: Excluir IdPaciente -> ForeignKey para PacienteGuid -> Corrigir as chamadas nos métodos (int p/ Guig) -> Migrations
- [x] [x][x][x][x] - AtbJaUtilizados: Excluir IdPaciente -> ForeignKey para PacienteGuid -> Corrigir as chamadas nos métodos (int p/ Guig) -> Migrations
- [x] [x][x][x][x] - BalancoHidrico: Excluir IdPaciente -> ForeignKey para PacienteGuid -> Corrigir as chamadas nos métodos (int p/ Guig) -> Migrations
- [x] [x][x][x][x] - ExameDeImagem: Excluir IdPaciente -> ForeignKey para PacienteGuid -> Corrigir as chamadas nos métodos (int p/ Guig) -> Migrations
- [x] [x][x][x][x] - Endereco: Excluir IdPaciente -> ForeignKey para PacienteGuid -> Corrigir as chamadas nos métodos (int p/ Guig) -> Migrations
- [x] [x][x][x][x] - Prescricao: Excluir IdPaciente -> ForeignKey para PacienteGuid -> Corrigir as chamadas nos métodos (int p/ Guig) -> Migrations
- [x] [x][x][x][x] - ProntuarioPrecaucao: Excluir IdPaciente -> ForeignKey para PacienteGuid -> Corrigir as chamadas nos métodos (int p/ Guig) -> Migrations
- [x] [x][x][x][x] - ResultadoExames: Excluir IdPaciente -> ForeignKey para PacienteGuid -> Corrigir as chamadas nos métodos (int p/ Guig) -> Migrations
- [x] [x][x][x][x] - SinaisVitais: Excluir IdPaciente -> ForeignKey para PacienteGuid -> Corrigir as chamadas nos métodos (int p/ Guig) -> Migrations
- [x] -> Chave Primária:
- [x] [x][x][x][x] - Paciente: Excluir PacienteId -> PrimaryKey para PacienteGuid -> Corrigir as chamadas nos métodos (int p/ Guig) -> Migrations

- [x] -> Métodos Afetados/Corrigidos: 
------------------------------------
- [x] ApiResources/GetApiProntuarioPorId(int id => Guid id);
- [x] Home/Buscar(int id => Guid id);
- [x] ApiResources/PacienteExists(int id => Guid id);
- [x] Home/BuscaPacienteMenuRight(int id => Guid id);
- [x] Prontuario/BuscaPaciente(int id => Guid id);
- [x] Prontuario/Index(int id => Guid id);
- [x] Home/GetApresentacaoAjustesPorId(int id => Guid id);
- [x] AtbEmUso/GetAtbemUsoPorId(int id => Guid id);
- [x] AtbJaUtilizado/getAtbJaUtilizadoPorId(int id => Guid id);
- [x] BalancoHidrico/GetBalancoHidricoPorId(int id => Guid id);
- [x] Prontuario/Index(int id => Guid id);
- [x] Endereco [Edit/Create];
- [x] Home/BuscarEndereco(int id => Guid id);
- [x] ExameDeImagem/GetExameDeImagemPorId(int id => Guid id);
- [x] ApiResources/GetProntuarioPrecaucaoPorIdPaciente(int id => Guid id);
- [x] TelefonePaciente/getTelefonePacientePorId(int id => Guid id);

- [x] Reescrever Prontuario do Zero, pois é necessário que cada prontuario seja um objeto independente e o mesmo é uma coleção em Paciente;
- [x] Adicionar, Listar e Alterar prontuarios de acordo com o paciente selecionado!
- [x] Se for chamado direto de menu, sem paciente selecionado, devem ser listados todos os prontuarios de todos os pacientes;

- [x] Mostrar Nome do Paciente que está sendo Incluído ou Editado;
- [x] Permitir Datas Nulas... Depois verificar se em algum caso tem de ser Not Null (Não pode ser em todos, pois tem casos em que a data fica inibida!
- [x] Ao listar um Fk e tentar ordenar com AngulaJS na coluna dele deve ser informada a notação correta. Ex.: "<th><a href="#" ng-click="ordenarPor('Paciente.Nome')">Paciente</a></th>", dentro do Model Prontuario;
- [x] Dados do Paciente, em Prontuario, devem ser populados implicitaente, pois Prontuario tem Paciente obrigatoriamente;
- [x] Mostrar dados de Endereço em Prontuario;
- [x] Carregamento de dreno tem de funcionar em Prontuario, através de uma simulação de Click()
- [x] Carregamento de Telefones do Paciente tem de funcionar em Prontuario, através de uma simulação de Click()
- [x] Carregamento de AtbEmUso tem de funcionar em Prontuario, através de uma simulação de Click()
- [x] Carregamento de AtbJaUtilizado tem de funcionar em Prontuario, através de uma simulação de Click()
- [x] Carregamento de ProntuarioPrecaucao tem de funcionar em Prontuario, através de uma simulação de Click()
- [x] Mostrar Idade calculada em Paciente e Prontuario, para efeito demostrativo e para relatórios;
- [x] Gravar e ler data null em prontuário, quando necessário.
- [x] Carregar dados do paciente e seus telefones na adição de um novo prontuario!

- [x] Ao inibir preenchimento de datas, também torná-las nulas;

- [x] Replicar a técnica de carregamento através da simulação do evento click() para TelefonePaciente, AtbEmUso, AtbJaUtilizado e Dreno também na adição de novo Prontuario;

- [x] Verificar a função genérica que inibe data para corrigir uns testes que fiz;

- [x] excluir BuscaPaciente de Prontuario MVC - (Subtituído pela implementação WebAPI c/Service usando $http);
- [x] excluir AddProntuario de Prontuario MVC - (Subtituído pela implementação WebAPI c/Service usando $http);
- [x] excluir DelProntuario de Prontuario MVC - (Subtituído pela implementação WebAPI c/Service usando $http);
- [x] Excluir a função getInibirData no controller AngulaJS pronturio;

- [ ] Refactory de Prescricao;
- [x] Criar ObterPrescricaoPorId (este id é da Prescricao) em ApiResources;
- [x] Criar ObterTodasAsPrescricoes (passando o Guid? do Paciente) em ApiResources;
- [x] Excluir as ActionResults equivalentes (mvcController), pois usaremos as 2 acima (apiController);
- [x] Criar o Service: servicePrescricao, pois usaremos services com o $http injection;
- [x] Injetar pacienteService e prescricaoService no controller AngulaJS de Prescricao;
- [x] Registrar no BundleConfig o Service prescricaoService;
- [x] Passar o Model IEnumerable<.../Prescricao> para a Index de Prescricao;
- [x] Usar a diretiva AngulaJS: ng-init="init(@Newtonsoft.Json.JsonConvert.SerializeObject(Model))"> para o Model prescricao receber os dados serializados;
- [x] Criar no Controler AngulaJS de prescricao a função ng-click="incluirPrescricaoDiv(prescricao.PacienteGuid)"
- [x] Criar no Controler AngulaJS de prescricao a função ng-click="carregaPrescricaoPorId(prescricao)"
- [x] Criar no Controler AngulaJS de prescricao a função ng-click="ArquivarPrescricao(prescricao)"
- [x] Excluir a função ctrlGetPaciente de Prescricao, pois não preciso mais selecionar o paciente, visto que ele vem da lista suspensa;

- [x] Criar a função buscaEnderecoPaciente em Prescricao;
- [x] Criar o campo NumAtendimento em prescricao;
- [ ][x][ ] Popular para testes NumAtendimento / Prescricao -> (Depois validar esse modelo, pois meparece que este campo deveria ser apenas de prontuario);
- [x] Corrigir TyFluimicilGotasPe => FluimicilGotas;


- [x] Criar função AdicionarEditarProntuario em prescricao;
- [x] Criar função ObterPacientePorId // Carregar dados pessoais e telefones;
- [x] Criar função carregaProntuarios(polimórfilos => com e sem Guid?) // Carrega todas as prescrições de todos os pacientes;

- [x] Criar no Controler AngulaJS de prescricao a diretiva a seguir que envolverá todo o conteúdo de edição da prescricao selecionada: <div class="row" ng-show="divprescricao">
- [x] Excluir a Action geraGuid de Prontuario e Prescricao;
- [x] Refatorar a Action Index de Prescricao;
- [x] Criar a Action e a View NovaPrescricao;
- [x] inibeBtnEdicao, verificaAcao e mostrarAcao em prescricao;
- [x] Excluir do Controller AngularJS o $scope adicionarPrescricao;
- [x] Excluir do Controller MVC a Action AddPrescricao;
- [x] Implementar incluirPrescricaoDiv em prescricao;
- [x] Incluir calculaIdade em prescricao e depois tornar essa funcção genérica para chamar de qualquer lugar passando apenas a data Ini, pois a fim será sempre a atual;
- [x] Excluir $scope.apagarPrescricoes do acontrller AngulaJS de Prescricao;
- [x] Excluir DelPrescricao do acontrller MVC de Prescricao;
- [x] Excluir getPrescricoes e GetPrescricaoPorId de Prescricaocontoller (MVC);
- [x] Excluir getPrescricoes e GetPrescricaoPorId de pescricaoCtrl (AngulaJS);
- [x] Excluir a Implementação isPrescricaoSelecionado, pois não há mais rotina de Exclusão;
- [ ] Mudar a Função IibirData para InibirCombo em Prescricao, pois nestes processos ela é utilizada para este fim e não com datas!
- [ ] Telefone grava, mas não mostra novos registros, como em AtbEmUso, AtbJaUtilizado e Dreno...

- [x] Criar a função: cancelaEdicao() em prescricao;
- [x] Implementar o SimulaClique em prescricao;
- [x] Substituir a Implementação de DDLList() => ViewBag.DDLDieta por uma implentação AngularJS ou MVC em PrescricaoController (MVC);
- [ ][x] Data ao chamarPrescricao tá dando erro, mas carrega... ???; Deixar o input como text e readonly até segunda ordem;
- [x] ProntuarioId e PrescricaoId podem e devem ser setadas na Adição tb, visto que não são campos auto-increments;

- [x] Nova Prescricao (Paciente sem Prescricao);
- [x] Criar um mecanismo para identificar que trata-se de uma nova prescricao (de um usuário sem prescricao alguma);
- [x] Se NumAtendimento = "0000000" essa é uma nova precricao de um paciente sem prescricao previa;
- [x] Não tem de ter buscar, Editar e Arquivar;

- [x] Novo Prontuario (Paciente sem Prontuario);
- [x] Criar um mecanismo para identificar que trata-se de um novo prontuario (de um usuário sem prontuario algum);
- [x] Se NumAtendimento = "0000000" esse é um novo prontuario de um paciente sem prontuario previo;
- [x] Não tem de ter buscar, Editar e Arquivar;

- [x] Alterar o nome das Views /Prontuario/Index e Prescricao/Index para ListaProntuario e ListaPrescricao, respectivamente em Prontuario e Precaução;
- [x] ChamadaMedico tem erro ao Obter Médicos;
- [x] ChamadaMedico tem erro de validação em leito e medico nas DDLists;
- [x] Ajustar datas para validação em ChamadaMedico;
- [x] Criar Action/View ExcluirChamadaMedico;
- [ ] Verificar a possibilidade de navegar na paginação de ChamdaMedico;

- [x] Popular prontuarioGuid em AtbEmUso, após criar a tabela;
- [x] Implementar ForeignKey "ProntuarioId" em AtbEmUso;
- [x] Testar Listagem da ForeignKey;
- [x] Get em AtbEmUso com dois parametros: idpaciente e idprontuario;
- [x] Implementar o resto do CRUD em AtbEmUso;
- [x] Gravar e Atualizar AtbEmUso com o novo Objeto Virtual [Prontuario], que é requerido;
- [x] Get em AtbJaUtilizado com dois parametros: idpaciente e idprontuario;
- [x] Get em Dreno com dois parametros: idpaciente e idprontuario;
- [x] Get em ProntuarioPrecaucao com dois parametros: idpaciente e idprontuario;
- [x] Atualizar CRUD de Dreno, ProntuarioPrecaucao, AtbJaUtilizado;


- [x] Criar um form-wizard para gravação em progresso, com obrigatoriedade para Invasões em Prontuario;
- [ ] Implementar DropDrowList para Medicamentos em Antibióticos em Uso e Utilizados, usando select2;
- [ ] Criar um form-wizard para gravação em progresso, com obrigatoriedade na 1ª aba em Prescricao;

- [ ] Implementar Exame de Imagens dentro de prontuario;
- [x] [x] Por ProntuarioGuid em EImagem;
- [x] [x] Vincular a tela de IEmagem ao Prontuario;
- [x] [x] Excluir ExameDeImagem.cshtml;
- [x] [x] Excluir arquivo ListaExameDeImagem;
- [x] [x] Excluir exame de Imagem do MenuLeft;
- [x] [x] Ajustar Exame de Imagem na Tela de prontuario, pois ele faz parte do mesmo;
- [x] [x] Substituir EImagem por ChamadaMedico na Tela Inicial;
- [ ] [ ] Trocar Imagem de EImagem por ChamadaMedico na Tela Inicial;
- [x] [x] Tornar Campo "PedidoEm" Nullable no objeto EImagem;
- [x] [x] Criar Prontuario Virtual no Objeto ExameDeImagem;
- [x] [x] Estilizar Tables com Class: table-hover, table-bordered;
- [x] [x] Estilizar th da View ExameDeImagem: class="alert alert-success";

- [x] Implementar BalançoHidrico e Sinais Vitais dentro de prontuario;
- [x] [x] Por ProntuarioGuid em BalancoHidrico;
- [x] [x] Vincular a tela de BHidrico ao Prontuario;
- [x] [x] Excluir BalancoHidrico.cshtml;
- [x] [x] Excluir arquivo ListaBalancoHidrico;
- [x] [x] Excluir BHidrico do MenuLeft;
- [x] [x] Ajustar BHidrico na Tela de prontuario, pois ele faz parte do mesmo;
- [x] [x] Substituir BHidrico por (item provisorio) na Tela Inicial;
- [ ] [ ] Trocar Imagem de BHidrico por (item provisorio) na Tela Inicial;
- [x] [x] Criar Prontuario Virtual no Objeto BHidrico;
- [x] [x] Estilizar Tables com Class: table-hover, table-bordered;
- [x] [x] Estilizar th da View BHidrico: class="alert alert-success";

- [x] Usar select2 em AtbEmUso e AtbJaUtilizado;
- [x] Editar a tela de Paciente para adequar às exclusões de EImagem e BHidrico;
- [x] Excluir Ctrl MVC de AtbEmUso, mas antes refatorá-lo em Ctrl MVC de Prontuario e ajustar sua Ctrl AngularJS;
- [x] Excluir Ctrl MVC de AtbJaUtilizado, mas antes refatorá-lo em Ctrl MVC de Prontuario e ajustar sua Ctrl AngularJS;


- [ ] Implementar Sinais Vitais e Balanço Hídrico dentro de prontuario;

- [ ] Criar prontuarioValidation;
- [ ] NumProntuario não pode ser null;
- [ ][ ] DataProntuario não pode ser null -> Data não pode ser futura
- [ ] PacienteGuid não pode ser null;
- [ ] ProntuarioId não pode ser null;


- [ ] Nebulizacao deve ser alterado para listagem, como dreno, telefones, etc...
- [ ] A concepção de alguns processos precisam ser corrigidos, como Dreno, AtbEmUso, AtbJáUtilizado, Nebulizacao, etc; Devem conter o Id doProntuario ou prescricao;
- [ ] Alterar forma de como as validações em AngularJS se mostram; usar o padrão que deixa a borda vermelha ao invés da atual...
- [x] Implementar CarregarFoto de forma correta e estilizada;
- [ ] Verificar na documentação da template onde configurar o topo e a sidebar para fixos;

------------------------------------------------------------------------------------------------------------

- Início do Refactory de Prescricao e ApresentacaoAjusteInteracao para ser FK de Prontuario;
- [x] Excluir os dados de ApresentacaoAjusteInteracao para facilitar o relacionamento sem erros de validação;
- [x] Criar campo ProntuarioGuid em ApresentacaoAjusteInteracao como FK de Prontuario;
- [x] Criar objeto vitual prontuario em ApresentacaoAjusteInteracao;
- [x] Implementar select2 em ApresentacaoAjusteInteracao para selecioar o medicamento;
- [x] Ao Clicar em select2 de ApresentacaoAjusteInteracao carregar posologia no clique e não no onblur;
- [x] Implementar SimulaClique em ApresentacaoAjusteInteracao para popular paciente e prontuario;
- [x] Retirar legenda de Paciente;
- [x] Balanço hídrico MVC Controller dever ser portado para Prontuario;

- [x] Prescricao não deve ter NumAtendimento e nem DataPrescricao;
- [x] Excluir dados de prescricao para não comprometer o relacionamento, pois prescricao será FK de Prontuario;
- [x] Criar campo ProntuarioGuid em Prescricao como FK;
- [x] Criar o objeto virtual Prontuario em Prescricao;
- [x] Implementar Accordion e Form-Wizard em Prescricao para facilitar a navegação e separação de responsabilidade

- [x] Excluir ListaPrescricao de menu Left;
- [x] Excluir Prescricao de Menu principal;
- [x] Excluir Prescricao de Cadastro de Paciente;
- [x] Alterar Prescrever / Evoluir para apenas uma chamada em Cadastro Médico com a mesma descrição;
- [x] Todas as Action de Prescricao devem ser migradas para Prontuario CTRL MVC;
- [x] Replicar as alterações das Action/Views de Prescricao para Prontuário tb em CTRL AngularJS;
- [x] Implementar select2 em Apresentacao, Ajustes, Interacao e Posologia;
- [ ] Implementar select2 em ContraIndicacao. Será mais complicado, pois este controller é MVC;
- [x] Posologia parou de carregar em ApresentacaoAjusteInteracao: Verificar - Já Ok!!!
- [x] Implementar $rootScope, $broadcast e $on, respctivamente em app.js, prontuarioCtrl e prescricaoCtrl;

- [x] Excluir GetNewPrescricao de ApiResources;
- [x] Excluir Bloco que Lista Prescricoes;
- [x] Excluir PrescricaoController MVC. Não é mais necessário pois apenas listava as Prescricoes, 
que agora são parte de prontuario;
- [x] Observar ObterUmaPrescricaoPorId e ObterPrescricoes nos Controllers e Services Angular; 
- [x] Em caso de exclusão acima, excuir tb em ApiResources;
- [ ] Trocar Imagem de Prescricao para UniGeog em Tela Inicial;
- [x] sweetalert.css online excluído. O estilo está na template;
- [x] ProntuarioInvasoesValidator implementado com sucesso. Complementar depois...;
- [x] Criar os modelos ProntuarioBase, Invasoes e NotificacoesProntuario;
- [x] Implementar ui-Modal AngularJS para gerar Nº de Atendimento;
- [x] Gravar dados em ProntuarioBase, através do uiModal-AngularJS;
- [x] Validar Campo NumAtdto no uiModal Grando Novo prontuario de Pacientes;
- [ ] Usar uibModal para Telefone, Endereço e Outros dados em Pacientes;



/*
- [ ] Implementar a parte de baixo da function;
swal({
  title: "Are you sure?",
  text: "You will not be able to recover this imaginary file!",
  type: "warning",
  showCancelButton: true,
  confirmButtonClass: "btn-danger",
  confirmButtonText: "Yes, delete it!",
  cancelButtonText: "No, cancel plx!",
  closeOnConfirm: false,
  closeOnCancel: false
},
function(isConfirm) {
  if (isConfirm) {
    swal("Deleted!", "Your imaginary file has been deleted.", "success");
  } else {
    swal("Cancelled", "Your imaginary file is safe :)", "error");
  }
});
 ------------------------------------------------------------------ //
*/


```
_______________________________________________

Vcs estão diante de um dos maiores projetos de gestão e TI com foco para Web que já foi feito.
Este projeto tem a assinatura de mais de 5 anos de pesquisas e trabalho duro do Dr. Claudio. E ele está, há um ano e pouco, sendo preparado para o mundo da Web e dos dispositivos móveis!
- Estamos há poucos passos te ter uma obra prima acabada. Um verdadeiro "achado" deste médico desbravador aliado à muitas noites sem dormir dele e minha.
Guardem essa mensagem, pois ela é uma espécie de manisfesto de quem já escreveu muitos projetos grandes para empresas grandes, mas nunca "transcreveu" sozinho a obra de um estudioso incansável para uma plataforma difícil, mas maravilhosa, que é a plataforma Web, HTTP e os Medias Devices de todos os tamanhos.
(...) Por que estou escrevendo isso? Porque isso é o que é este projeto! E nunca conseguimos, de fato, falar dele por mais de 3 horas da forma que deveríamos. Então apenas guardem essas palavras; elas farão sentido do dia da nossa vitória, que está mais próxima do que o próximo fim de semana!
_______________________________________________

```

## Duas maneira de tentar formatar data, que não estão funcionando no sistema;
### User a Notação: "objDate = new Date(objDate);"

```
	$scope.paciente.datainternacao = ConverterDataJsonParaData(paciente.data.DataInternacao);
	$scope.prontuario.DataProntuario = new Date($filter('jsonToDate')(data.DataProntuario));

```




```


##Guia de Apresentação

```
> Imagem da Tela Inicial
```

![Tela Inicial do Sistema EvoluMed-Sys](http://evolumed.com.br/imgdocgit/telaapresentacao.png "Tela Inicial do Sistema EvoluMed-Sys")


```
> Menu Principal
```
![Menu Principal do Sistema EvoluMed-Sys](http://evolumed.com.br/imgdocgit/tela-inicial.png "Menu Principal do Sistema EvoluMed-Sys")



## Nesta tela apenas usuários cadastrados por Administradores poderão ter acesso ao Sistema!

![Tela de Login do Sistema EvoluMed-Sys](http://evolumed.com.br/imgdocgit/login.png "Tela de Login do Sistema EvoluMed-Sys")



## Dashboard do Sistema!

```
No Dashboard os dados estatísticos mais relevantes são mostrados de 
forma analítica e apenas os usuários com acesso admin poderão acessá-los!
```

![Dashboard do Sistema EvoluMed-Sys](http://evolumed.com.br/imgdocgit/dashboard.png "Dashboard do Sistema EvoluMed-Sys")


## Organograma Interessante!

```
> Tela interessante para estudo de um organograma ideal:
```

![Estudo de Caso para o Sistema EvoluMed-Sys](http://evolumed.com.br/imgdocgit/organogramaideal.png "Estudo de Caso para o Sistema EvoluMed-Sys")



## Implementada rotina para controlar Imagem de Perfil Padrão e Upload de foto em Perfil de Usuário.
```
> Também foi implementado um menu DropDown para perfil no menu left.
```

![Tela de perfil ajustada com imagem padrão e upload e redimensionamento de imagens para o Sistema EvoluMed-Sys](http://evolumed.com.br/imgdocgit/tela-manage-index.png "Tela de perfil ajustada com imagem padrão e upload e redimensionamento de imagens para o Sistema EvoluMed-Sys")


```
> Código da tela acima - Upload e Redimensionameto de Imagens de perfil.
```


![Código da Tela de perfil ajustada com imagem padrão e upload e redimensionamento de imagens para o Sistema EvoluMed-Sys](http://evolumed.com.br/imgdocgit/tela-manage-index-codigo01.png "Tela de perfil ajustada com imagem padrão e upload e redimensionamento de imagens para o Sistema EvoluMed-Sys")



### Rotina de Controle de DropDrowList para Interação: AngularJS / JavaSscript;


```javascript

    //// -------------------------------------------------- //
    //// -------------------------------------------------- //
    //// -------------------------------------------------- //
    //// ----/ Início do contexto de controles de Interação //


    ///*
    //     #. Verificar se as variáveis NÃO são nulas - Ok
    //     #. Verificar se NÃO são undefined - Ok
    //     #. Me restringir às linhas selecionadas para pegar os valores - Ok - Descontinuada...
    //     #. Pegar o length da variavel;
    //     #. Se for menor que 5, por tantos ZEROS quanto a diferença - Ok
    //     #. Ao gravar o medicamento prescrito voltar o value da selectlist para "" em Medicamento e Posologia - Ok
    //     #. NÃO pode haver mais de uma seleção para o mesmo medicamento.... - Ok
    //     #. Ao "barrar" a inserção de um novo elemento no array de medicamentos, zerar a option...
    //     #. Avisar ao usuário sobre as repetições para não passarem despercebidas. Ok
    //  ===>   10. Comparar com a base de dados de Interação;
    //            10.a.
    //            10.b.
    //            10.c.
    //            .....
    //*/


    // Por zero antes de um número, de acordo com a qtde de caracteres esperados.
    var lpad = function lpad(num, size) {
        var newString = num + "";
        while (newString.length < size) newString = "0" + newString;
        return newString;
    }
    // ----------------------------------------------------------------------- //


    /* 
        Funcção que procura um elemento dentro de um Array e, neste caso
        ainda zera as options repetidas, alem de não incluir o elemento!
    */
    $scope.combinacoes = [];
    $scope.repetidos = [];
    function atualizarCombinacoes(colecao, elemento) {
        debugger;
        if ($scope.combinacoes.indexOf(elemento) === -1) {
            $scope.combinacoes.push(elemento);
        } else if ($scope.combinacoes.indexOf(elemento) > -1) {
            $scope.repetidos.push(lpad($scope.apresentacaoajusteinteracao.IdGenerico,5));
        };
    };


    // -------/ --------------------------------- //
    var temRepeticao = function (generico, paciente) {
        debugger;
        var retVal = false;
        var zAntesGenerico = "";
        var zAntesPaciente = "";

        var vCount = 0;
        if (generico && paciente) {
            zAntesGenerico = lpad(generico, 5);
            zAntesPaciente = lpad(paciente, 5);
            var flag = zAntesGenerico + zAntesPaciente;
            atualizarCombinacoes($scope.combinacoes, flag);
            vCount++;
        }

        // -------/ Chamar modal para avisar das repetições /----------- //
        if ($scope.repetidos.length > 0) {
            zeraOption();
            openRepetidos('lg');
            retVal = true;
        };
        // Provisório...
        console.log('Nova coleção de medicamentos é : ' + $scope.combinacoes);
        return retVal;
    };

    /*
        Criar uma nova coleção que combine de 2 em 2 os elementos selecionados
        para testar se há interações medicamentosas entres os medicamentos escolhidos.
    */
    // Criar função aqui...

    /*
        Ao gravar voltar o valor da Option para Empty.
        Não esquecer de por Empty na DropDrownList de medicamento e, também, de posologia.
    */
    var zeraOption = function () {
            $("#medicamento").val($("#medicamento option:first").val());
            $("#posologia").val($("#posologia option:first").val());
    };


    // ------------------------------------------------------------------------------------- //
    // -----/ Controle do Modal de Options repetidas em Interações ------------------------- //
    $scope.animationsEnabled = true;

    var openRepetidos = function (size) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'ModalRepetidas.html',
            controller: 'ModalRepetidosCtrl',
            size: size,
            resolve: {
                vRepetidos: function () {
                    return $scope.repetidos;
                }
            }
        });

        modalInstance.result.then(function () {
        }, function () {
        });

    };


    //// -------/ Fim do contexto de controle de Interação ---//
    //// ---------------------------------------------------- //
    //// ---------------------------------------------------- //
    //// ---------------------------------------------------- //


```

## Modal que apresenta as seleções repetidas nos DropDrownList para interação:

```html
    <!--/ Modal -->
    <script type="text/ng-template" id="ModalRepetidas.html">
        <div class="modal-header">
            <h3 class="modal-title">Controle de Medicamentos para Interação</h3>
        </div>
        <div class="modal-body">

            <h3>Os seguintes items forma selecionados repetidamente:</h3>
            <br/>
            <div class="alert alert-warning">
                <ul>
                    <li ng-repeat="r in vRepetidos">
                        <h4>{{r}}</h4>
                    </li>
                </ul>
            </div>
            <div class="alert alert-info"><h4>Obs.: Já foram retirados da lista!</h4></div>
        </div>

        <div class="modal-footer">
            <button class="btn btn-primary" type="button" ng-click="ok()">OK</button>
        </div>
    </script>
    <!--/ Modal -->
```

## Em PrescricaoCtrl tem o código que chama o modal acima:

```javascript
    // ------------------------------------------------------------------------------------- //
    // -----/ Controle do Modal de Options repetidas em Interações ------------------------- //

    //$scope.mdctos = [];
    $scope.animationsEnabled = true;

    var openRepetidos = function (size) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'ModalRepetidas.html',
            controller: 'ModalRepetidosCtrl',
            size: size,
            resolve: {
                vRepetidos: function () {
                    return $scope.repetidos;
                }
            }
        });

        modalInstance.result.then(function () {
        }, function () {
        });

    };
```

## Aqui o Controle em AngularJS que faz o meio campo entre o html e o código Angular:

```javascript
	app.controller('ModalRepetidosCtrl', function ($scope, $uibModalInstance, vRepetidos) {

		$scope.vRepetidos = vRepetidos;
		$scope.ok = function () {
			$uibModalInstance.close();
		};

	});
```


##Resolvido o problema de formato de data de "yyyy-MM-ddT00:00:00" para "dd/MM/yyyy".
###Depois de muitas pesquisas e queimar muita a "mufa", descobri que não precisava de função alguma, bastando chamar new Date(objeto data original);

```
Óbvio que neste caso estou recebendo uma coleção, pequisada por ID e não um JsonResult:
```

```javascript
    $scope.obterPorId = function (medico) {
        var medicoData = medicoService.GetMedicoPorId(medico.MedicoId);
        medicoData.then(function (medico) {
            $scope.medico = medico.data;
			//AQUI ESTÁ A SOLUÇÃO!
            $scope.medico.DataNascimento = new Date(medico.data.DataNascimento);

            $scope.Acao = "Atualizar";
            $scope.divmedico = true;
        }, function () {
            toastr["error"]("Erro ao obter medico!", "EvoluMed-Sys");
        });
    };
```


## Dicas Importantes:
###Para achar os métodos abaixo basta utilizar o namespace: Using Microsoft.AspNet.Identity; Tanto no controller quanto na view.

```csharp
/*DICA: 0001*/
User.Identity.GetUserId();
HttpContext.Current.User.Identity.GetUserId();
```


```
* ﻿EWvoluMed-Sys - Links das telas:
----------------------------------

* http://prntscr.com/dbx6fu		-	Dashboard - Top
* http://prntscr.com/dbx6ri		-	Dashboard - Bottom
* http://prntscr.com/dbx6y6		-	Tooltips
* http://prntscr.com/dbx76s		-	Login
* http://prntscr.com/dbx7gc		-	Lista de usuários
* http://prntscr.com/dbx7k3		-	Mais Tooltips
* http://prntscr.com/dbx7pu		-	Modal de Cadastramento de usuários com checkbox de Perfil
* http://prntscr.com/dbx7zq		-	Tela de cima com mais detalhes
* http://prntscr.com/dbx86m		-	Edição de usuários
* http://prntscr.com/dbx8b2		-	Exclusão de usuários
* http://prntscr.com/dbx8je		-	Lista de Perfis de Usuários (Roles)
* http://prntscr.com/dbx8p2		-	Modal com edição de Perfis
* http://prntscr.com/dbx8y8		-	Lista de Chamada Medica (Busca, Paginação, Ordenação, Validação e CRUD) numa só page
* http://prntscr.com/dbx9dq		-	Adicionar Chamada Médica (Div alternando conforme ação)
* http://prntscr.com/dbx9nc		-	Mesmo de Cima com combobox acionada para Leitos
* http://prntscr.com/dbxa93		-	prontuário (Top) - Dados Cadastrais
* http://prntscr.com/dbxafw		-	prontuário (Bottom)
* http://prntscr.com/dbxtaj		-	prontuário (Top) - Invasões
* http://prntscr.com/dbxtpw		-	prontuário (Bottom) - Invasões
* http://prntscr.com/dbxtwj		-	Listando os Prontuários (Lista no final da página. Pode ser que tenha um posição melhor)
* http://prntscr.com/dbxu66		-	Combo Paciente em Pronuário (A última opção é o ID, apenas em desenvolvimento para testes)
* http://prntscr.com/dbxujp		-	Aba Drenos em Prontuários
* http://prntscr.com/dbxuty		-	Aba Exames / Antibióticos (Em Uso / Já Utilizados) - Prontuario
* http://prntscr.com/dby0kl		-	Aba Exames / Antibióticos (Exames) - Prontuario
* http://prntscr.com/dby0vr		-	Aba Exames / Antibióticos (Exames) - Prontuario - (Excluindo...)
* http://prntscr.com/dby19g		-	Aba Exames / Antibióticos (Exames) - Prontuario - (Combo Exames...)
* http://prntscr.com/dbxvg8		- 	Interação (ainda no Excel) - Já tenho a tabela e o CRUD pronto, mas não importei os dados ainda
* http://prntscr.com/dby1mh		-	Prescrição - Combo Pacientes
* http://prntscr.com/dby1tw		-	Prescrição - Dados Pessoais
* http://prntscr.com/dby20c		-	Prescrição - Dietas e Comorbidades (Top)
* http://prntscr.com/dby2gw		-	Prescrição - Hidratação, Nebulização, Antiácido, Anticoagulação,procinético (center)
* http://prntscr.com/dby2z7		-	Prescrição - Drippings, Glicemia Capilar, Insulina, Oxigenoterapia, Fisioterapia, Emeses, etc (Bottom)
* http://prntscr.com/dby3in		-	Prescrição - Aba Apresentação, Ajustes e Interações 
* http://prntscr.com/dby41j		-	Prescrição - Aba Apresentação, Ajustes e Interações (Tooltips)
* http://prntscr.com/dby45q		-	Prescrição - Aba Apresentação, Ajustes e Interações (Mais Tooltips)
* http://prntscr.com/dby4bi		-	Prescrição - Aba Apresentação, Ajustes e Interações (Avisos em Modal)
* http://prntscr.com/dby4ls		-	Balança Hídrico / Sinais Vitais - Aba Dados Cadastrais (Cabeçalho)
* http://prntscr.com/dby592		-	Balança Hídrico / Sinais Vitais - Aba Sinais Vitais (Últimas 24h.)
* http://prntscr.com/dby5ja		-	Balança Hídrico / Sinais Vitais - Aba balanço Hídrico (Últimas 24h.)
* http://prntscr.com/dby65j		-	Lista de Contatos
* http://prntscr.com/dby6fe		-	Mural de Avisos (tenho todo o CSS)
* http://prntscr.com/dby6mc		-	Mural de Avisos (tenho todo o CSS) - Modal de Adição
* http://prntscr.com/dby6rw		-	Mural de Avisos (tenho todo o CSS) - Excluir neste ícone
* http://prntscr.com/dby8gy		-	Excel - Tratamento de Patologias
```
* ...
```

* http://prnt.sc/demju3 		- 	CRUD Agendamento (Busca, Paginação, Ordenação, Validação e CRUD com Aviso em Toastr)
* http://prntscr.com/demlzg 	-	Editando Agendamento numa Div (Enable/Disable)
* http://prntscr.com/demmyw 	- 	Adicionando Agendamento na mesma Div, com Flag para Add/Remove
* http://prntscr.com/demnzo 	- 	Aviso em Toastr de gravação com sucesso!
* http://prntscr.com/demp8s 	- 	Aviso em Toastr de Exclusão com sucesso - Botão...
* http://prntscr.com/dempv7 	- 	Aviso em Toastr de Exclusão com sucesso - Mensagem...
* http://prntscr.com/demrin 	- 	Validação de MinLeght (Botão salvar Inibido)
* http://prntscr.com/dems8u 	- 	Validação de Required (Com $setPristine - Botão Inibido)
* http://prntscr.com/demx1v 	- 	Injetando dependência de dirPagination no module principal.
* http://prntscr.com/demvgo 	- 	Utilização de "dir-paginate" no lugar de "ng-repeat" - (Atenção para o pagination-id -IMPORTANTÍSSIMO)
* http://prntscr.com/den0o5 	- 	Editando Paciente (Através de um Modal, chamado a apartir da Right-Sidebar)
* http://prntscr.com/den1ok 	- 	Listando Paciente para CRUD
* http://prntscr.com/den223 	- 	Modal com Detalhes do Paciente
* http://prntscr.com/den2bd 	- 	Modal para Exclusão do Paciente
* http://prntscr.com/den2ni 	- 	Modal para Inclusão do Paciente
* http://prntscr.com/den3l6 	- 	Buscando / Filtrando Pacientes
```
* ...
```
* 
* http://prntscr.com/dffrsr		-	CRUD completo de CID, com busca, ordenação, paginação e validação;
* http://prntscr.com/dh1wvt 	- 	CRUD completo de Interação Medicamentosa com Ordenação, Busca, Paginação, Validação e API;
* http://prntscr.com/dhim32		-	Infra;
* http://prntscr.com/dhimcp		-	Anticoagulação;
* http://prntscr.com/dhimpe		-	Classes;
* http://prntscr.com/dhimwg		-	APIs - Listas...
* http://prntscr.com/dhin3y		-	APIs com descritivos XML;
* http://prntscr.com/dhinf6		-	APIs - Console;
* http://prntscr.com/dhinmd		-	Convenio: CRUD completo com Ordenação, Busca, Paginação, Validação e APIs;
* http://prntscr.com/dhio1d		-	Descritivo APIs Convenio;
* http://prntscr.com/dhiogm		-	APIs convenio: Console;
* http://prntscr.com/dhiood		-	Sexo: Apenas leitura;
* http://prntscr.com/dhiow1		-	Sexo: APIs de sexo - Descritivo. Somente leitura;
* http://prntscr.com/dhip9q		-	Sexo: APIs - Console;
* http://prntscr.com/dhyxb9		-	UF: CRUD completo com Ordenação, Busca, Paginação, Validação e APIs - (Base oficial do IBGE);
* http://prntscr.com/di07qe		-	Cidade Refeita com dados do IBGE;
```
* ...
```
* (continua...)
```





##Novas tabelas para a abordagem correta de Drenos fora de prontuário;

```csharp
Modelo para as descrições dos Tipos de Drenos:

	using System.ComponentModel.DataAnnotations;

	namespace Cooperchip.EvoluMed.Infraestrutura.Entidade
	{
		public class TipoDreno
		{
			[Key]
			public int TipoDrenoId { get; set; }

			[Display(Name="Descrição")]
			[Required]
			[MaxLength(25,ErrorMessage ="Máximo de caracter: 25")]
			public string Descricao { get; set; }
		}
	}
	
Modelo para as drenagens nos pacientes:

	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	namespace Cooperchip.EvoluMed.Infraestrutura.Entidade
	{
		public class Dreno
		{
			[Key]
			public int DrenoId { get; set; }

			[ForeignKey("Paciente")]
			[Required]
			public int PacienteId { get; set; }

			[ForeignKey("TipoDreno")]
			[Required]
			public int TipoDrenoId { get; set; }

			[Required]
			[MaxLength(35)]
			public string Local { get; set; }

			public DateTime DataInsercao  { get; set; }

			public virtual Paciente Paciente { get; set; }
			public virtual TipoDreno TipoDreno { get; set; }


		}
	}
	
```


##Rascunho de Alteração de Dreno, que será destachada de prontuário. REALIZADO - OK!!!

```
> Tela projetada apos print da atual implementação equivocada:
```
![Tela Rascunho de Novo Dreno do Sistema EvoluMed-Sys](http://evolumed.com.br/imgdocgit/rascunhodenovodreno.png "Tela Rascunho de Novo Dreno do Sistema EvoluMed-Sys")


##Marcação de vídeos (minuto:segundo) que sejam importantes para rever;
###Isso para não interromper o vídeo e conseguir ser mais atento diariamente na programação de 4 horas de vídeos/dia;

```
1. Rodrigo Branas > AngularJS > Vídeo #2 (Usando Diretivas > 00:15:25 > ng-repeat com {{key + '-' + value}} Obs: Testar em DropDrowList;
2. Rodrigo Branas > AngularJS > Vídeo #3 (Usando Diretivas > 00:17:20 > ngClass e ngStyle (Aplicando classes CSS e estilos dinamicamente);
3. Curso de Asp.Net Core com Angular 2 - Eduardo Pires > Vídeo #5 (MVC) > 00:56:00;
4. Curso de Asp.Net Core com Angular 2 - Eduardo Pires > Vídeo #5 (Taghelper e Viewcomponents);
```


##Print: Tela Editando Pacientes:

```
> Tela capturada diretamente do Sistema;
```
![Tela de Edição de Pacientes do Sistema EvoluMed-Sys](http://evolumed.com.br/imgdocgit/editandopaciente.png "Tela de Edição de Pacientes do Sistema EvoluMed-Sys")


##Print: Modelo inconsistentes de edição em Prontuario;

```
> Tela Capturada: Modelo inconsistentes de edição em Prontuario.
```
![Modelo inconsistentes de edição em Prontuario no Sistema EvoluMed-Sys](http://evolumed.com.br/imgdocgit/remodelagemdoCRUDprecaucao.png "Modelo inconsistentes de edição em Prontuario no Sistema EvoluMed-Sys")

```
> Tela Capturada: Dados inconsistentes na tabela de Prontuario.
```
![Dados inconsistentes na tabela de Prontuario no Sistema EvoluMed-Sys](http://evolumed.com.br/imgdocgit/tipodeprecaucaoparamodelar.png "Dados inconsistentes na tabela de Prontuario no Sistema EvoluMed-Sys")


##Print: Dados gravados na tabela Events (Results de FullCalendar);

```
> Tela Capturada: Modelo que pode substituir Agendamento.
```
![Dados gravados na tabela Events - Results de FullCalendar - no Sistema EvoluMed-Sys](http://evolumed.com.br/imgdocgit/events.png "Dados gravados na tabela Events - Results de FullCalendar - no Sistema EvoluMed-Sys")


##Exemplo de Performance I:
### Retorno de Agendamento com Include("TabelaRelacionada): Pouco mais de 1kb;


```json
	{
	  "Medico": {
					"Especialidade": 
						{
							"EspecialidadeId": 1,
							"Descricao": "Cardiologia"
						},
					"MedicoId": 10,
					"Nome": "Claudio Henrique",
					"Crm": "45555877",
					"DataNascimento": "1971-10-15T00:00:00",
					"IdEspecialidade": 1
				},
	  "Paciente": 
				{
					"Convenio": {
									"ConvenioId": 2, 
									"Descricao": "ASSIM"
								},
					"EstadoDoPaciente": 
								{
									"EstadoDoPacienteId": 1, 
									"Descricao": "Estável"
								},
					"Leito": 	{
									"LeitoId": 7,
									"EspecificacaoDoLeito": 
									"Qto 300"
								},
					"Setor": 	{
									"SetorId": 7,
									"Sigla": "USI",
									"Descricao": "Unidade Semi-Intensiva"
								},
					"Sexo": 	{
									"SexoId": 1,
									"Descricao": "Feminino"
								},
					"PacienteId": 8,
					"NumAtendimento": "1234567807",
					"Peso": 84,
					"DataInternacao": "2016-12-08T00:00:00",
					"Cpf": "76464464412",
					"Rg": "800445-0",
					"RgOrgao": "DETRAN",
					"RgDataEmissao": "2016-12-08T00:00:00",
					"Email": "bsilvab@opt.com.br",
					"Nome": "Bárbara Silva",
					"Ativo": true,
					"DataNascimento": "2016-12-08T00:00:00",
					"idConvenio": 2,
					"IdLeito": 7,
					"Alergia": "Clozanepan, Atenalol",
					"idSexo": 1,
					"idEstadoDoPaciente": 1,
					"IdSetor": 7
				},
	  "AgendamentoId": 16,
	  "IdPaciente": 8,
	  "Data": "2017-04-10T03:00:00",
	  "Hora": "12:45",
	  "Exames": "Teste 2",
	  "Confirmado": true,
	  "IdMedico": 10
	}

```



##Exemplo de Performance II:
### Retorno de Paciente com Include("TabelaRelacionada): Apenas 1kb 927Bytes

```json
[
	{
		"Convenio":
			{
				"ConvenioId":3,
				"Descricao":"GOLDEN"
			},
		"EstadoDoPaciente":
			{
				"EstadoDoPacienteId":3,
				"Descricao":"Crítico"
			},
		"Leito":
			{
				"LeitoId":4,
				"EspecificacaoDoLeito":"Sala 202 C"
			},
		"Setor":
			{
				"SetorId":1,
				"Sigla":"CTI",
				"Descricao":"Centro de Tratamento Intensivo"
			},
		"Sexo":
			{
				"SexoId":1,
				"Descricao":"Feminino"
			},
		"PacienteId":2,
		"NumAtendimento":"1234567877",
		"Peso":75,
		"DataInternacao":"2014-11-23T00:00:00",
		"Cpf":"75535785768",
		"Rg":"07152955-6",
		"RgOrgao":"IFP",
		"RgDataEmissao":"1980-06-15T00:00:00",
		"Email":"elisamrrnn@bol.com.br",
		"Nome":"Elisa Mariana",
		"Ativo":true,
		"DataNascimento":"1960-05-02T00:00:00",
		"idConvenio":3,
		"IdLeito":4,
		"Alergia":"Losartana Potássica, Dipirona",
		"idSexo":1,
		"idEstadoDoPaciente":3,
		"IdSetor":1
	}
]	
```


##Controle Auxiliar (provisória) para formar a tabela de MedicamentoApresentacao:

```csharp
	using Cooperchip.EvoluMed.Infraestrutura.ORM.EF.Contexto;
	using System.Web.Mvc;

	namespace Cooperchip.EvoluMed.Web.Controllers
	{
		/// <summary>
		/// 
		/// </summary>
		public class MedicamentoApresentacaoAuxController : Controller
		{

			private EvoluMedSysModelContext db = new EvoluMedSysModelContext();


			// GET: MedicamentoApresentacaoAux
			/// <summary>
			/// 
			/// </summary>
			/// <returns></returns>
			public ActionResult Index()
			{

				var listaAux = (from laux in db.ApresentacaoAux select laux).ToList();

				foreach (var item in listaAux)
				{
					var id = item.ApresentacaoId;

					var p1 = item.Apresentacao1;
					var p2 = item.Apresentacao2;
					var p3 = item.Apresentacao3;
					var p4 = item.Apresentacao4;
					var p5 = item.Apresentacao5;
					var p6 = item.Apresentacao6;
					var p7 = item.Apresentacao7;
					var p8 = item.Apresentacao8;
					var p9 = item.Apresentacao9;
					var p10 = item.Apresentacao10;
					var p11 = item.Apresentacao11;

					var obj = new MedicamentoApresentacao();
					if (p1 != "")
					{

						obj.IdMedicamento = id;
						obj.Descricao = p1;
						db.MedicamentoApresentacao.Add(obj);
						db.SaveChanges();



						if (!p2.IsEmpty())
						{
							obj.IdMedicamento = id;
							obj.Descricao = p2;
							db.MedicamentoApresentacao.Add(obj);
							db.SaveChanges();
						}
						if (!p3.IsEmpty())
						{
							obj.IdMedicamento = id;
							obj.Descricao = p3;
							db.MedicamentoApresentacao.Add(obj);
							db.SaveChanges();
						}
						if (!p4.IsEmpty())
						{
							obj.IdMedicamento = id;
							obj.Descricao = p4;
							db.MedicamentoApresentacao.Add(obj);
							db.SaveChanges();
						}
						if (!p5.IsEmpty())
						{
							obj.IdMedicamento = id;
							obj.Descricao = p5;
							db.MedicamentoApresentacao.Add(obj);
							db.SaveChanges();
						}
						if (!p6.IsEmpty())
						{
							obj.IdMedicamento = id;
							obj.Descricao = p6;
							db.MedicamentoApresentacao.Add(obj);
							db.SaveChanges();
						}
						if (!p7.IsEmpty())
						{
							obj.IdMedicamento = id;
							obj.Descricao = p7;
							db.MedicamentoApresentacao.Add(obj);
							db.SaveChanges();
						}
						if (!p8.IsEmpty())
						{
							obj.IdMedicamento = id;
							obj.Descricao = p8;
							db.MedicamentoApresentacao.Add(obj);
							db.SaveChanges();
						}
						if (!p9.IsEmpty())
						{
							obj.IdMedicamento = id;
							obj.Descricao = p9;
							db.MedicamentoApresentacao.Add(obj);
							db.SaveChanges();
						}
						if (!p10.IsEmpty())
						{
							obj.IdMedicamento = id;
							obj.Descricao = p10;
							db.MedicamentoApresentacao.Add(obj);
							db.SaveChanges();
						}
						if (!p11.IsEmpty())
						{
							obj.IdMedicamento = id;
							obj.Descricao = p11;
							db.MedicamentoApresentacao.Add(obj);
							db.SaveChanges();
						}



					}


				}

				ViewBag.Dados = listaAux;
				return View("Resultado", listaAux);


				Provisorio
				return View();

			}
		}
	}

```

##Controle Auxiliar (provisória) para formar a tabela de MedicamentoPosologia:

```csharp
	using System.Linq;
	using System.Web.Mvc;
	using Cooperchip.EvoluMed.Infraestrutura.ORM.EF.Contexto;

	namespace Cooperchip.EvoluMed.Web.Controllers
	{
		/// <summary>
		/// 
		/// </summary>
		public class MedicamentoPosologiaAuxController : Controller
		{

			private EvoluMedSysModelContext db = new EvoluMedSysModelContext();

			// GET: MedicamentoPosologiaAux
			/// <summary>
			/// 
			/// </summary>
			/// <returns></returns>
			public ActionResult Index()
			{

				var listaAux = (from laux in db.PosologiaAux select laux).ToList();

				foreach (var item in listaAux)
				{
					var id = item.PosologiaId;
					var padrao = item.PosologiaPadrao;
					var p1 = item.Posologia1;
					var p2 = item.Posologia2;
					var p3 = item.Posologia3;
					var p4 = item.Posologia4;
					var p5 = item.Posologia5;
					var p6 = item.Posologia6;
					var p7 = item.Posologia7;
					var p8 = item.Posologia8;
					var p9 = item.Posologia9;
					var p10 = item.Posologia10;
					var p11 = item.Posologia11;

					var obj = new MedicamentoPosologia();
					if (padrao != "")
					{

						obj.IdMedicamento = id;
						obj.Descricao = padrao;
						db.MedicamentoPosologia.Add(obj);
						db.SaveChanges();

						if (!p1.IsEmpty())
						{
							obj.IdMedicamento = id;
							obj.Descricao = p1;
							db.MedicamentoPosologia.Add(obj);
							db.SaveChanges();
						}

						if (!p2.IsEmpty())
						{
							obj.IdMedicamento = id;
							obj.Descricao = p2;
							db.MedicamentoPosologia.Add(obj);
							db.SaveChanges();
						}
						if (!p3.IsEmpty())
						{
							obj.IdMedicamento = id;
							obj.Descricao = p3;
							db.MedicamentoPosologia.Add(obj);
							db.SaveChanges();
						}
						if (!p4.IsEmpty())
						{
							obj.IdMedicamento = id;
							obj.Descricao = p4;
							db.MedicamentoPosologia.Add(obj);
							db.SaveChanges();
						}
						if (!p5.IsEmpty())
						{
							obj.IdMedicamento = id;
							obj.Descricao = p5;
							db.MedicamentoPosologia.Add(obj);
							db.SaveChanges();
						}
						if (!p6.IsEmpty())
						{
							obj.IdMedicamento = id;
							obj.Descricao = p6;
							db.MedicamentoPosologia.Add(obj);
							db.SaveChanges();
						}
						if (!p7.IsEmpty())
						{
							obj.IdMedicamento = id;
							obj.Descricao = p7;
							db.MedicamentoPosologia.Add(obj);
							db.SaveChanges();
						}
						if (!p8.IsEmpty())
						{
							obj.IdMedicamento = id;
							obj.Descricao = p8;
							db.MedicamentoPosologia.Add(obj);
							db.SaveChanges();
						}
						if (!p9.IsEmpty())
						{
							obj.IdMedicamento = id;
							obj.Descricao = p9;
							db.MedicamentoPosologia.Add(obj);
							db.SaveChanges();
						}
						if (!p10.IsEmpty())
						{
							obj.IdMedicamento = id;
							obj.Descricao = p10;
							db.MedicamentoPosologia.Add(obj);
							db.SaveChanges();
						}
						if (!p11.IsEmpty())
						{
							obj.IdMedicamento = id;
							obj.Descricao = p11;
							db.MedicamentoPosologia.Add(obj);
							db.SaveChanges();
						}



					}


				}

				ViewBag.Dados = listaAux;
				return View("Resultado", listaAux);
			}


		}
	}
```

##Tabela Auxiliar (provisória) - PosologiaAux:

```csharp
	using System.ComponentModel.DataAnnotations;

	namespace Cooperchip.EvoluMed.Infraestrutura.Entidade
	{
		public class PosologiaAux
		{
			[Key]
			public int PosologiaId { get; set; }

			public string PosologiaPadrao { get; set; }
			public string Posologia1 { get; set; }
			public string Posologia2 { get; set; }
			public string Posologia3 { get; set; }
			public string Posologia4 { get; set; }
			public string Posologia5 { get; set; }
			public string Posologia6 { get; set; }
			public string Posologia7 { get; set; }
			public string Posologia8 { get; set; }
			public string Posologia9 { get; set; }
			public string Posologia10 { get; set; }
			public string Posologia11 { get; set; }
		}
	}
```


## Histórico de commits deletados. Versão 1.0 concluída.

```
af6a970e	deletei os brach s vs2017 e desenv
743d8201 	Credenciamento como o primeiro serviço em Cooperchip.EvoluMed.Serveces
f2990ca0 	Novo README
3863a3a3 	Rotina de Pedido de credenciamento com gravação no Mural + Envio de E-Mail ok
68a9b75d 	Alterei todos os projetos (4) da Target 4.5.2 para a 4.6.1 e rodei com sucesso!
3ac1770c 	Config Arrumado c/+4 Tabelas + MenuRight + Dir src + Refactory for DDD
1e61580f 	Implementação completa de UniGeog, com chamada assincrona, via Ajax.BeginForm, ordenação, paginação, busca tudo muito rápido com PagedList
d7181d4e 	Por os métodos API do controller UnidadeGeografica em ApiResources, pois o controller de UG será apagado e sua implementação em AngulaJS também, assim como seu Ctrl e Service
35fc4265 	UniGeg com paginação e busca Ajax. 3 segundos numa busca de 1 milhão de registros, com parcial view sendo renderizada apenas. Falta paginar dentro das buscas
1922c83a 	Implementar busca com Ajax PartialView com post em ajax em bairro e UniGeog
870a60e5 	UnidadeGeografica populada na nova base local e implementação MVC com PagedList excelente
d075c8af 	Acertei as imagens de Boxinit e criei a página Portais em Developers.
111e5b42 	UnidadeGeografica foi para arq json e migrei a base de dados para LocalDb
962b8bb9 	NewEvoluMed implementada com LocalDb e layout possível de me livar de tantos js
08cb4e58 	Ordenação de prontuario e prescricao por nome do paciente e correção do .Include('Paciente')
06803c96 	ForeignKey de IdPaciente em Prontuario e Prescricao. Listagem de ambos ajustadas para edição acima do form
00be5a27 	Mdelos BHidrico e EImagens com ProntuarioGuid e PacienteGuid, falta preparar a listagem das Telas, que já são chamadas de Pacientes e faltam ser chamadas do menu left
bb60eb41 	Readme com ToDo das novas tarefas antes de Implementar ListaBHidrico e ListaEImagem
402a78be 	PacienteGuid criado em Prescricao + ListaPrescricao implementada
fa76f964 	Criar a relação OneToMany de Paciente para prontuário, pois já populei prontuario com os Guid de Paciente
1ca7e468 	ListaProntuario com designer e dados de prontuario e PacienteGuid Ok. Preciso implementar o Crud
58e8193a 	PacienteGuid, que será PacienteId Implementado com sucesso e tabela populada!
e1de774b 	Modelo Pessoa criado, assim como o Enum TipoPessoa. Contrutor implementando PessoaIs = Guid.NewGuid(); e DataInclusao = DateTime.Now; + Método acessor String GetTipoPessoa
51cb6345 	Unfiquei todas as telas de acesso e admin de user. Criei o modal para associar perfil e permissão. Tudo Ok. Navegação perfeita e exclusão do controller ClaimsController
:...skipping...
af6a970e 	deletei os brach s vs2017 e desenv
743d8201 	Credenciamento como o primeiro serviço em Cooperchip.EvoluMed.Serveces
f2990ca0 	Novo README
3863a3a3 	Rotina de Pedido de credenciamento com gravação no Mural + Envio de E-Mail ok
68a9b75d 	Alterei todos os projetos (4) da Target 4.5.2 para a 4.6.1 e rodei com sucesso!
3ac1770c 	Config Arrumado c/+4 Tabelas + MenuRight + Dir src + Refactory for DDD
1e61580f 	Implementação completa de UniGeog, com chamada assincrona, via Ajax.BeginForm, ordenação, paginação, busca tudo muito rápido com PagedList
d7181d4e 	Por os métodos API do controller UnidadeGeografica em ApiResources, pois o controller de UG será apagado e sua implementação em AngulaJS também, assim como seu Ctrl e Service
35fc4265 	UniGeg com paginação e busca Ajax. 3 segundos numa busca de 1 milhão de registros, com parcial view sendo renderizada apenas. Falta paginar dentro das buscas
1922c83a 	Implementar busca com Ajax PartialView com post em ajax em bairro e UniGeog
870a60e5 	UnidadeGeografica populada na nova base local e implementação MVC com PagedList excelente
d075c8af 	Acertei as imagens de Boxinit e criei a página Portais em Developers.
111e5b42 	UnidadeGeografica foi para arq json e migrei a base de dados para LocalDb
962b8bb9 	NewEvoluMed implementada com LocalDb e layout possível de me livar de tantos js
08cb4e58 	Ordenação de prontuario e prescricao por nome do paciente e correção do .Include('Paciente')
06803c96 	ForeignKey de IdPaciente em Prontuario e Prescricao. Listagem de ambos ajustadas para edição acima do form
00be5a27 	Mdelos BHidrico e EImagens com ProntuarioGuid e PacienteGuid, falta preparar a listagem das Telas, que já são chamadas de Pacientes e faltam ser chamadas do menu left
bb60eb41 	Readme com ToDo das novas tarefas antes de Implementar ListaBHidrico e ListaEImagem
402a78be 	PacienteGuid criado em Prescricao + ListaPrescricao implementada
fa76f964 	Criar a relação OneToMany de Paciente para prontuário, pois já populei prontuario com os Guid de Paciente
1ca7e468 	ListaProntuario com designer e dados de prontuario e PacienteGuid Ok. Preciso implementar o Crud
58e8193a 	PacienteGuid, que será PacienteId Implementado com sucesso e tabela populada!
e1de774b 	Modelo Pessoa criado, assim como o Enum TipoPessoa. Contrutor implementando PessoaIs = Guid.NewGuid(); e DataInclusao = DateTime.Now; + Método acessor String GetTipoPessoa
51cb6345 	Unfiquei todas as telas de acesso e admin de user. Criei o modal para associar perfil e permissão. Tudo Ok. Navegação perfeita e exclusão do controller ClaimsController
d2fe6ecf 	Excluí a cópia do projeto, pois já tem num commit. Exclui Foto e TipoDeImg de ApplicationUser e EditUserViewModel
c6ab1188 	Atualizando o README antes do commit abaixo
855fe172 	Atualizando o README e preparando o ambiente para teste de Controle de Acesso centralizado com Modal
2642db33 	Profile no estilo original com caret dropdown, submenu em perfil e foto padrao implementada. Lindo!
10a3a94a 	Upload e Recsize das imagens para Perfil ok. Falta acertar style do menu, mas isso po:...skipping...
af6a970e 	deletei os brach s vs2017 e desenv
743d8201 	Credenciamento como o primeiro serviço em Cooperchip.EvoluMed.Serveces
f2990ca0 	Novo README
3863a3a3 	Rotina de Pedido de credenciamento com gravação no Mural + Envio de E-Mail ok
68a9b75d 	Alterei todos os projetos (4) da Target 4.5.2 para a 4.6.1 e rodei com sucesso!
3ac1770c 	Config Arrumado c/+4 Tabelas + MenuRight + Dir src + Refactory for DDD
1e61580f 	Implementação completa de UniGeog, com chamada assincrona, via Ajax.BeginForm, ordenação, paginação, busca tudo muito rápido com PagedList
d7181d4e 	Por os métodos API do controller UnidadeGeografica em ApiResources, pois o controller de UG será apagado e sua implementação em AngulaJS também, assim como seu Ctrl e Service
35fc4265 	UniGeg com paginação e busca Ajax. 3 segundos numa busca de 1 milhão de registros, com parcial view sendo renderizada apenas. Falta paginar dentro das buscas
1922c83a 	Implementar busca com Ajax PartialView com post em ajax em bairro e UniGeog
870a60e5 	UnidadeGeografica populada na nova base local e implementação MVC com PagedList excelente
d075c8af 	Acertei as imagens de Boxinit e criei a página Portais em Developers.
111e5b42 	UnidadeGeografica foi para arq json e migrei a base de dados para LocalDb
962b8bb9 	NewEvoluMed implementada com LocalDb e layout possível de me livar de tantos js
08cb4e58 	Ordenação de prontuario e prescricao por nome do paciente e correção do .Include('Paciente')
06803c96 	ForeignKey de IdPaciente em Prontuario e Prescricao. Listagem de ambos ajustadas para edição acima do form
00be5a27 	Mdelos BHidrico e EImagens com ProntuarioGuid e PacienteGuid, falta preparar a listagem das Telas, que já são chamadas de Pacientes e faltam ser chamadas do menu left
bb60eb41 	Readme com ToDo das novas tarefas antes de Implementar ListaBHidrico e ListaEImagem
402a78be 	PacienteGuid criado em Prescricao + ListaPrescricao implementada
fa76f964 	Criar a relação OneToMany de Paciente para prontuário, pois já populei prontuario com os Guid de Paciente
1ca7e468 	ListaProntuario com designer e dados de prontuario e PacienteGuid Ok. Preciso implementar o Crud
58e8193a 	PacienteGuid, que será PacienteId Implementado com sucesso e tabela populada!
e1de774b 	Modelo Pessoa criado, assim como o Enum TipoPessoa. Contrutor implementando PessoaIs = Guid.NewGuid(); e DataInclusao = DateTime.Now; + Método acessor String GetTipoPessoa
51cb6345 	Unfiquei todas as telas de acesso e admin de user. Criei o modal para associar perfil e permissão. Tudo Ok. Navegação perfeita e exclusão do controller ClaimsController
d2fe6ecf 	Excluí a cópia do projeto, pois já tem num commit. Exclui Foto e TipoDeImg de ApplicationUser e EditUserViewModel
c6ab1188 	Atualizando o README antes do commit abaixo
855fe172 	Atualizando o README e preparando o ambiente para teste de Controle de Acesso centralizado com Modal
2642db33 	Profile no estilo original com caret dropdown, submenu em perfil e foto padrao implementada. Lindo!
10a3a94a 	Upload e Recsize das imagens para Perfil ok. Falta acertar style do menu, mas isso pode esperar
209b0baf 	Controller, Método e Action para Foto no Perfil Ok. só falta ajustar o botão de upload
78d55c99 	Antes da foto, Criei uma action para pesquisar os Ícones do Sistema para auxiliar nos designers
957c5556 	Estado antes de implementar foro de perfil
590a4849 	Método Seed, em Configuration / Identity Ok + Novos campos para User -> Foto e TipoImgFoto
654c3d6d 	Tela Abertura - Teste Inclusa com um modelo elegante de Tab
cfe75e39 	Tela Inicial responsiva. BoxInit no lugar de Abertura
ac7752c3 	Igualei as versoes do NewtonSoft nos projetos
770284b9 	Trouxe a produção e o desenvolvimento para este branch (master) depois apago o repositório DevEvoluMedProducao
357f14a7 	Realocando o README
c60a1428 	Conferindo Branch master que quero unificar
b09eb0bb 	Atualizando o Branche vs2017 para fazer um merge para master e depois excluí-lo
0906fd6b 	Otimizando Repositótrio
c0ac278f 	Downgrade para projeto sem Injeção, mas com o UserAdmin funcionando
0c99442e 	Downgrade2
5b4caf86 	Entrar dividido entre tela de apresentação e Dashboard
20b6dcf9 	Injeção de Dependencia com SimpleInject Ok e Inicializer tb Ok
ad1a68fd 	Reimplementei o método Seed com Role e User e Otimizei o uso de .js no Bundleconfig
0d324c5f 	Menu refatorado e Tabs para os dados dos Pacientes, como telefones e endereços, etc.
42b058b1 	SweetAlert e Configurações implementadas e otimizadas, assim como designer de TFA
65d3c424 	Claims Ok. Faltando apenas alguns ajustes de layout
4d282252 	Designer de paciente preparado para nova implementação de prontuarios, prescrição, B.Hídrico e Ex.Imagem
b49462e4 	Identity com Claims ok em projeto separado e config centralizado
95e1704f 	Antes de refatorar o sistema de gravação de Prontuario e Prescrição
e34ab0b5 	Controller e View de AcessoPorClaims implementado relacionado com AspNetUsers
5ba68fc2 	Tabela, Controller e Views de AcessoPorClaims criada com sucesso, com Fk em AspNetUsers
7bb7d487 	Services e Filtro de Autorização por Claims Implementado, falta criar a tela para gravar no banco de dados
b2e439c7 	Antes de Implementar Claims
526a0f10 	Antes de Começar o dia 28-06-2017
fdb4f994 	ApplicationUser custoizado e Perfil dinâmico implementado
c6b46f03 	IoC Identity -> Statup_auth, Configuration, BootStrapper e SimpleInjectInicializer
d2cc91aa 	Isolamento do Identity Ok, faltando IoC
38fd9591 	Add Task List para o isolamento do Identity e/ou criação de Usuario
cf3b165e 	Atualizando Database para Isolar o Identity
0f6f8d1a 	Antes de criar Usuario Refatorado
755feec8 	Antes de criar Usuario
0cc857db 	Database Updated
fc51b990 	Alteração e refatoração em User - UserName agora é Usuario
0c4151bb 	Database updated
42ee0807 	Antes da alteração de Identity
bddb244a 	atualização Dreno, Precaução, Pic, Pia, Marcapasso, Contraindicação
e197838e 	PrecaucaoId ajustado, faltando edit e delete
e4acfd1a 	Precaucao Aerozol, Contato, Padrao e Goticula refatora para Precaucao apenas + DataBase Ok
94a071b7 	Atualização de DataBase 29-05-2017-19:32
8a99f4c3 	Precaucao em ApiResource e CRUD de precaucao em AngularJS sem testar
15c85f19 	Contra Indicação com Modais Ok e database atualizado no git
7521577f 	Insercao de Tipo de Precaução e Contra Indicação
b9fef81a 	Alteração completa na estrutura de endereços com Includes para Paciente, Uf, Cidade e Bairro, alem da junção de sua controller WebAPI para APIResources
4c077d92 	Varios ajustes de layouts em várias telas, mas o patern de telefone falhou
559b6e3a 	CRUD de Medico Validado
afb33dfb 	Correção / Atualização do README
d58d7396 	Atualização do README e Tela Inicial + Ex. de Agendamento.Json
687e42eb 	Tela de Events, que deve substiruir agendamentos
bec183a4 	Rascunho de normalização de precaucao e CRUD
5fafb9ad 	Imagem de dados de precaucao, fora da normalizacao
653a2636 	Imagens com medidas padronizadas
ba39030c 	Novo README e tela de precaução NÃO normalizada
bddad1d7 	Upd VS2017 & LocalDB & 80 solução nova Interacao com Table nova, etc.
a01035f2 	Refactory completo de ApresentacaoAjusteInteracao com dados em tabela fora de prescricao
78dfaa6b 	Copia de projeto e Database para mudança radical em Interacao
cd877227 	Pequena alteração no README
51fb1cd7 	Formato de Data resolvido em Agendamento e Medico
d319ffb8 	Mudança na formatação da Pagina Inicial
3ca2fe81 	Adiçao do arquivo dataFormats.js em utilService.js
01e33587 	Adiçao do arquivo dataFormats.js no README e em Uteis
247e609a 	Reajuste do BundlerConfig com distribuição dos Ctrl AngularJS
a4763bee 	Update database e snapshot
377937a0 	Tela Inicial e designer de tables ajustados
833a93f5 	Inserção de Organograma Interessante para Estudo de Caso
f0ce5de3 	Nova concepção de CRUD em Tipo deDreno e Dreno dinâmico
90c18cd5 	Cadastro de Tipo de Dreno completo (paginacao, busca, ordenacao e crud
062c4e85 	Inserção da Imagem de Apresentação no README
17fd9682 	Inserção da imagem de apresentação no README
230382bf 	Sinais Vitais e Balanço Hidricos Ok (zerei view de Dreno para refazer)
75959ad2 	Anotando alterações em prontuario > retirando campos de dreno depreciados
daed35cf 	Corrigindo README
35d924dd 	Add Novas tabelas TipoDreno e Dreno
845c45b8 	Atualizando README e add Tela de Edição de Pacientes refatorado
7426c71b 	Atualizando README e add Tela de Edição de Pacientes
85aa2017 	Atualização de README, com add de Tasklist com emoji 2
2aed1372 	Atualização de README, com add de Tasklist com emoji
9e24472e 	Atualização de README, com add de Tasklist refatorado
7fa9a9de 	Atualização de README, com add de Tasklist
e5271f64 	Medico quase pronto e faltando Acertar a data. Especialidade Ok
0d15f484 	Medico quase pronto e faltando CRUD/View de Especialidade
efa7944a 	Acerto no código de Apresentação e no README
7f29b61c 	Códigos para apresentar o Modal de Repetidos em Interação
e976702b 	Guardando repetições no .repetidos para aviso ao usuário
bab3fd15 	Acertando a função para mostrar as seleções repetidas
c00daf4a 	Acertando o README
fb4d55e9 	Ao (barrar) a inserção de um novo elemento no array de medicamentos, zerar a option e eliminar o elemento
44925d97 	Ao (barrar) a inserção de um novo elemento no array de medicamentos, zerar a option
5dde0ae2 	Implementação da função que zera as options dos ddlist ao desmarcar as checkbox em Interacao
ee6dd5d9 	Alteração em README - Identação de bloco de código 4
eeb47d4c 	Alteração em README - Identação de bloco de código 3
bdfa6db1 	Alteração em README - Identação de bloco de código 2
5bf2032d 	Alteração em README - Identação de bloco de código
f874c7d4 	Diário de Bordo das primeiras anotações do sistema!
696e7f6f 	Imagem do Dashboard - Ajustá-la depois!
161ef741 	Código implementado para Interações Medicamentosas - Primeiros Algoritmos
5dacd095 	Reeditando - Documentação [README] Tela de Login
5fac0f09 	Reeditando - Documentação [README] - Initial
d8ddb95b 	Editando - Documentação [README] - Initial
cf1350d8 	Documentação [README] - Initial
ef5047fd 	Ajustes na documentação das funções da Interação
7f55143c 	Início do contexto de controles de Interação em Prescrição
437d275d 	Acertos no processo de Interação - Início do Algoritmo
541db10c 	Repositorio todo refeito
ffbe5a5c 	Atualização de algumas tags para bg-bind ao invéz dos {{}}
2d01ba30 	Descrição dos genéricos ok em InteracaoMedicamentosa
3020f0cc 	Correção de AgendamentoExame
81052a69 	Update Agendamento com Fk em Medico e Paciente -. Ainda com bug
b54c91c8 	Update (Descricao >> Id) Ajustes, Posologia e Apresentacao + Upd Paciente e Prescricao
4c32e2b0 	Update Database
991694f1 	Barra lateral direita toda em AngularJS e Modal Paciente também
f5d3bbda 	Comentei totalReg em Pacientes/Leito
5b3bb518 	Modal Paciente/Leito em todas as Telas com AngulaJS
014d422e 	Alterei os nomes padrões de template e ctrl de ModalApresentacao
91938da9 	Apresentação em Prescrição Ok
3934ed16 	Reiniciando o repositorio
```

