using System.Web.Http;
using WebActivatorEx;
using Cooperchip.MedicalManagement.Web;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Cooperchip.MedicalManagement.Web
{
    /// <summary>
    /// 
    /// </summary>
	public class SwaggerConfig
	{

        /// <summary>
        /// 
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    // Por padrão, o URL da raiz do serviço é inferido da solicitação usada para acessar os documentos.
                    // No entanto, pode haver situações (por exemplo, ambientes de proxy e de balanceamento de carga), onde isso não
                    // resolve-se corretamente. Você pode solucionar isso fornecendo seu próprio código para determinar o URL da raiz.
                    //
                    //c.RootUrl(req => GetRootUrlFromAppConfig());

                    // Se os esquemas não são explicitamente fornecidos em um documento Swagger 2.0, então o esquema costumava acessar
                    // os documentos são assumidos como padrão. Se sua API suportar vários esquemas e você quer ser explícito
                    // sobre eles, você pode usar a opção "Esquemas" como mostrado abaixo.
                    //
                    c.Schemes(new[] { "http", "https" });

                    // Use "SingleApiVersion" para descrever uma única versão da API. Swagger 2.0 inclui um objeto "Info" para
                    // mantenha metadados adicionais para uma API. Versão e título são obrigatórios, mas você também pode fornecer
                    // campos adicionais por métodos de encadeamento de SingleApiVersion.
                    //
                        //c.SingleApiVersion("v1", "APIs - MedicalManagement-Sys")
                        c.SingleApiVersion("v1", "APIs - Medical Management-Sys")
                        .License(l =>
                        {
                            l.Name("MIT");
                            l.Url("http://portalcooperchip.com.br");
                        })
                        .Contact(ct =>
                        {
                            ct.Name("Cooperchip Informática");
                            ct.Email("portalcooperchip@gmail.com");
                            ct.Url("http://portalcooperchip.com.br");
                        })
                        .Description("APIs do Projeto Medical Management -Sys")
                        .TermsOfService("Consulte nossos Termos e Serviços");

                    // Se você deseja que a saída Swagger docs seja indentada corretamente, habilite a opção "PrettyPrint".
                    //
                    c.PrettyPrint();

                    // Se sua API tiver várias versões, use "MultipleApiVersions" em vez de "SingleApiVersion".
                    // Neste caso, você deve fornecer uma expressão lambda que informa a Swashbuckle quais ações devem ser
                    // incluído nos documentos para uma determinada versão da API. Como "SingleApiVersion", cada chamada para "Versão"
                    // retorna um construtor "Info" para que você possa fornecer metadados adicionais por versão da API.
                    //
                    //c.MultipleApiVersions(
                    //    (apiDesc, targetApiVersion) => ResolveVersionSupportByRouteConstraint(apiDesc, targetApiVersion),
                    //    (vc) =>
                    //    {
                    //        vc.Version("v2", "Swashbuckle Dummy API V2");
                    //        vc.Version("v1", "Swashbuckle Dummy API V1");
                    //    });

                    // Você pode usar as opções "BasicAuth", "ApiKey" ou "OAuth2" para descrever esquemas de segurança para a API.
                    // Consulte https://github.com/swagger-api/swagger-spec/blob/master/versions/2.0.md para obter mais detalhes.
                    // NOTA: Estes apenas definem os esquemas e precisam ser acoplados com uma propriedade "de segurança" correspondente
                    // no documento ou nível de operação para indicar quais esquemas são necessários para uma operação. Para fazer isso,
                    // você precisará implementar um IDocumentFilter personalizado e / ou IOperationFilter para definir essas propriedades
                    // de acordo com sua implementação de autorização específica
                    //
                    //c.BasicAuth("basic")
                    //    .Description("Basic HTTP Authentication");
                    //

                    // NOTA: Você também deve configurar 'EnableApiKeySupport' abaixo na seção SwaggerUI
                    //c.ApiKey("apiKey")
                    //    .Description("API Key Authentication")
                    //    .Name("apiKey")
                    //    .In("header");
                    //
                    //c.OAuth2("oauth2")
                    //    .Description("OAuth2 Implicit Grant")
                    //    .Flow("implicit")
                    //    .AuthorizationUrl("http://petstore.swagger.wordnik.com/api/oauth/dialog")
                    //    //.TokenUrl("https://tempuri.org/token")
                    //    .Scopes(scopes =>
                    //    {
                    //        scopes.Add("read", "Read access to protected resources");
                    //        scopes.Add("write", "Write access to protected resources");
                    //    });

                    // Set this flag to omit descriptions for any actions decorated with the Obsolete attribute
                    //c.IgnoreObsoleteActions();

                    // Cada operação deve ser atribuída a uma ou mais etiquetas que são usadas pelos consumidores por diversas razões.
                    // Por exemplo, o swagger-ui agrupa as operações de acordo com a primeira tag de cada operação.
                    // Por padrão, este será o nome do controlador, mas você pode usar a opção "GroupActionsBy" para
                    // substituir com qualquer valor.
                    //
                    //c.GroupActionsBy(apiDesc => apiDesc.HttpMethod.ToString());


                    // Você também pode especificar uma ordem de classificação personalizada para grupos (conforme definido por "GroupActionsBy") para ditar
                    // o pedido em que as operações estão listadas. Por exemplo, se o agrupamento padrão estiver no lugar
                    // (nome do controlador) e você especifica uma ordem de classificação alfabética decrescente, então as ações de um
                    // O ProductsController será listado antes dos de um CustomerController. Isso geralmente é
                    // usado para personalizar a ordem dos agrupamentos no swagger-ui.
                    //
                    //c.OrderActionGroupsBy(new DescendingAlphabeticComparer());


                    // Se você anotar controladores e tipos de API com
                    // Comentários Xml (http://msdn.microsoft.com/en-us/library/b2s063f7(v=vs.110).aspx), você pode incorporar
                    // esses comentários nos documentos e UI gerados. Você pode habilitar isso fornecendo o caminho para um ou
                    // mais arquivos de comentários do Xml.
                    //
                    c.IncludeXmlComments(GetXmlCommentsPath());

                    // Swashbuckle faz a melhor tentativa de gerar esquemas JSON compatíveis com Swagger para os vários tipos
                    // exposto na sua API. No entanto, pode haver ocasiões em que é necessário mais controle da saída.
                    // Isto é suportado através das opções "MapType" e "SchemaFilter":
                    //
                    // Use a opção "MapType" para substituir a geração do Esquema por um tipo específico.
                    // Deve notar-se que o Esquema resultante será colocado "inline" para qualquer Operação aplicável.
                    // Enquanto o Swagger 2.0 suporta definições de linha para "todos" os tipos de Esquema, a ferramenta swagger-ui não.
                    // Ele espera que os esquemas "complexos" sejam definidos separadamente e referenciados. Por esta razão, você deve apenas
                    // use a opção "MapType" quando o Esquema resultante é um tipo primitivo ou de matriz. Se você precisa alterar um
                    // Esquema complexo, use um filtro Esquema.
                    //
                    //c.MapType<ProductType>(() => new Schema { type = "integer", format = "int32" });


                    // Se você quiser publicar os esquemas "complexos" após a geração deles, em geral ou por um
                    // tipo específico, você pode conectar um ou mais filtros Esquema.
                    //
                    //c.SchemaFilter<ApplySchemaVendorExtensions>();


                    // Em um documento Swagger 2.0, os tipos complexos geralmente são declarados globalmente e referenciados por itens únicos
                    // Esquema Id. Por padrão, Swashbuckle NÃO usa o nome do tipo completo em Id. De Esquema. Na maioria dos casos, isso
                    // funciona bem porque impede que os "detalhes de implementação" dos namespaces de tipo vazem para o seu
                    // Swagger docs e UI. No entanto, se você tiver vários tipos em sua API com o mesmo nome de classe, você
                    // precisa desativar esse comportamento para evitar conflitos de Id. de esquema.
                    //
                    //c.UseFullTypeNameInSchemaIds();


                    // Alternativamente, você pode fornecer sua própria estratégia personalizada para inferir SchemaId's para
                    // descrevendo tipos "complexos" em sua API.
                    //
                    //c.SchemaId(t => t.FullName.Contains('`') ? t.FullName.Substring(0, t.FullName.IndexOf('`')) : t.FullName);

                    // Defina esta bandeira para omitir descrições de propriedades de esquema para qualquer tipo de propriedades decoradas com o
                    // atributo obsoleto
                    //c.IgnoreObsoleteProperties();


                    // De acordo com o construído no JsonSerializer, o Swashbuckle, por padrão, descreverá enums como números inteiros.
                    // Você pode alterar o comportamento do serializador configurando o StringToEnumConverter globalmente ou para um dado
                    // tipo enum. Swashbuckle irá homenagear esta mudança fora da caixa. No entanto, se você usar um
                    // abordagem para serializar enums como strings, você também pode forçar Swashbuckle para descrevê-los como strings.
                    //
                    //c.DescribeAllEnumsAsStrings();


                    // Semelhante aos filtros de Esquema, a Swashbuckle também suporta filtros de Operação e Documento:
                    //
                    // Descrições da Operação pós-modificação uma vez que foram geradas por fiação de um ou mais
                    // Filtros de operação.
                    //
                    //c.OperationFilter<AddDefaultResponse>();
                    //
                    // Se você definiu um fluxo OAuth2 conforme descrito acima, você poderia usar um filtro personalizado
                    // para inspecionar algum atributo em cada ação e inferir quais escopos OAuth2 (se houver) são necessários
                    // para executar a operação
                    //
                    //c.OperationFilter<AssignOAuth2SecurityRequirements>();


                    // Post-modifique todo o documento do Swagger ao conectar um ou mais filtros de documentos.
                    // Isso dá controle total para modificar o SwaggerDocument final. Você deve ter uma boa compreensão de
                    // a especificação Swagger 2.0. - https://github.com/swagger-api/swagger-spec/blob/master/versions/2.0.md
                    // antes de usar esta opção.
                    //
                    //c.DocumentFilter<ApplyDocumentVendorExtensions>();


                    // Em contraste com o WebApi, o Swagger 2.0 não inclui o componente de seqüência de consulta ao mapear um URL
                    // para uma ação. Como resultado, Swashbuckle aumentará uma exceção se encontrar várias ações
                    // com o mesmo caminho (sem string de consulta) e método HTTP. Você pode resolver isso fornecendo uma
                    // estratégia personalizada para escolher um vencedor ou mesclar as descrições para os propósitos dos documentos Swagger
                    //
                    //c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());


                    // Envolva o SwaggerGenerator padrão com comportamento adicional (por exemplo, cache) ou forneça um
                    // implementação alternativa para ISwaggerProvider com a opção CustomProvider.
                    //
                    //c.CustomProvider((defaultProvider) => new CachingSwaggerProvider(defaultProvider));
                })
                .EnableSwaggerUi(c =>
                {
                    // Use a opção "DocumentTitle" para alterar o título do documento.
                    // Muito útil quando você tem várias páginas Swagger abertas, para distingui-las.
                    //
                    c.DocumentTitle("Medical Management-Sys API");


                    // Use a opção "InjectStylesheet" para enriquecer a UI com uma ou mais folhas de estilo CSS adicionais.
                    // O arquivo deve ser incluído em seu projeto como um "Recurso Integrado" e, em seguida, o recurso
                    // "Nome Lógico" é passado para o método como mostrado abaixo.
                    //
                    //c.InjectStylesheet(containingAssembly, "Swashbuckle.Dummy.SwaggerExtensions.testStyles1.css");


                    // Use a opção "InjectJavaScript" para invocar um ou mais JavaScripts personalizados após o swagger-ui
                    // carregou. O arquivo deve ser incluído em seu projeto como um "recurso incorporado" e, em seguida, o recurso
                    // "Nome Lógico" é passado para o método como mostrado acima.
                    //
                    //c.InjectJavaScript(thisAssembly, "Swashbuckle.Dummy.SwaggerExtensions.testScript1.js");

                    // O swagger-ui processa os tipos de dados booleanos como um menu suspenso. Por padrão, ele fornece "true" e "false"
                    // cordas como as possíveis escolhas. Você pode usar essa opção para alterá-la para outra coisa,
                    // por exemplo, 0 e 1.
                    //
                    //c.BooleanValues(new[] { "0", "1" });


                    // Por padrão, swagger-ui validará especificações contra o validador on-line do swagger.io e exibirá o resultado
                    // em um distintivo na parte inferior da página. Use estas opções para definir um URL de validação diferente ou para desativar a
                    // recurso inteiramente.

                    //c.SetValidatorUrl("http://localhost/validator");
                    //c.DisableValidator();


                    // Use esta opção para controlar como a lista de Operações é exibida.
                    // Pode ser definido como "Nenhum" (padrão), "Lista" (mostra operações para cada recurso),
                    // ou "Completo" (totalmente expandido: mostra operações e seus detalhes).
                    //
                    //c.DocExpansion(DocExpansion.List);


                    // Especifique quais operações de HTTP terão o 'Experimente!' opção. Uma lista de parâmetros vazia desabilita
                    // para todas as operações.
                    //
                    //c.SupportedSubmitMethods("GET", "HEAD");


                    // Use a opção CustomAsset para fornecer sua própria versão dos ativos usados ​​no swagger-ui.
                    // Normalmente é usado para instruir o Swashbuckle para retornar sua versão em vez do padrão
                    // quando uma solicitação é feita para "index.html". Como com todo o conteúdo personalizado, o arquivo deve ser incluído
                    // no seu projeto como "Recurso Integrado" e, em seguida, o "Nome Lógico" do recurso é passado para
                    // o método conforme mostrado abaixo.
                    //
                    //c.CustomAsset("index", containingAssembly, "YourWebApiProject.SwaggerExtensions.index.html");

                    // Se sua API tiver várias versões e você aplicou a configuração MultipleApiVersions
                    // conforme descrito acima, você também pode ativar uma caixa de seleção no swagger-ui, que exibe
                    // um URL de descoberta para cada versão. Isso fornece uma maneira conveniente para usuários navegar documentação
                    // para diferentes versões da API.
                    //
                    //c.EnableDiscoveryUrlSelector();


                    // Se sua API suportar o fluxo implícito OAuth2 e você descreveu corretamente, de acordo com
                    // a especificação Swagger 2.0, você pode ativar o suporte à UI, conforme mostrado abaixo.
                    //
                    //c.EnableOAuth2Support(
                    //    clientId: "test-client-id",
                    //    clientSecret: null,
                    //    realm: "test-realm",
                    //    appName: "Swagger UI"
                    //    //additionalQueryStringParams: new Dictionary<string, string>() { { "foo", "bar" } }
                    //);


                    // Se sua API suportar ApiKey, você pode substituir os valores padrão.
                    // "apiKeyIn" pode ser "consulta" ou "cabeçalho"
                    //
                    //c.EnableApiKeySupport("apiKey", "header");

                });
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		protected static string GetXmlCommentsPath()
		{
			return System.String.Format(@"{0}\bin\Cooperchip.MedicalManagement.Web.XML", System.AppDomain.CurrentDomain.BaseDirectory);
		}


	}
}
