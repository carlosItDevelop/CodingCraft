using System.Web.Optimization;

namespace Cooperchip.MedicalManagement.Web
{
    /// <summary>
    /// 
    /// </summary>
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bundles"></param>
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/core").Include(
                    "~/tpl/plugins/core/pace/pace.min.js",
                    "~/tpl/js/libs/jquery-2.1.1.min.js",
                    // Make-Admin
                    "~/Scripts/make-admin/jquery-ui/jquery-ui-1.11.2.min.js",

                    "~/tpl/js/bootstrap/bootstrap.min.js",
                    "~/tpl/js/jRespond.min.js",
                    "~/tpl/plugins/core/slimscroll/jquery.slimscroll.min.js",
                    "~/tpl/plugins/core/slimscroll/jquery.slimscroll.horizontal.min.js",
                    "~/tpl/plugins/core/fastclick/fastclick.js",
                    "~/tpl/plugins/core/velocity/jquery.velocity.min.js",
                    "~/tpl/plugins/core/quicksearch/jquery.quicksearch.js",
                    "~/tpl/plugins/ui/bootbox/bootbox.mim.js",
                    "~/Scripts/jquery.unobtrusive*"
                ));


            bundles.Add(new ScriptBundle("~/bundles/otherdashboard").Include(
                    "~/tpl/js/libs/date.js",
                    "~/tpl/plugins/charts/sparklines/jquery.sparkline.js",
                    "~/tpl/plugins/charts/progressbars/progressbar.min.js",
                    "~/tpl/plugins/ui/waypoint/waypoints.js",
                    "~/tpl/plugins/ui/weather/skyicons.js",
                    "~/tpl/plugins/ui/notify/jquery.gritter.min.js",
                    "~/tpl/plugins/misc/countTo/jquery.countTo.js",
                    "~/tpl/js/jquery.dynamic.js",
                    "~/tpl/js/pages/dashboard.js",
                    "~/tpl/js/main.js"
                ));


            bundles.Add(new ScriptBundle("~/bundles/datatableswithtools").Include(
                    "~/tpl/plugins/charts/sparklines/jquery.sparkline.js",
                    "~/tpl/plugins/tables/datatables/jquery.dataTables.js",
                    "~/tpl/plugins/tables/datatables/dataTables.tableTools.js",
                    "~/tpl/plugins/tables/datatables/dataTables.bootstrap.js",
                    "~/tpl/plugins/tables/datatables/dataTables.responsive.js",
                    "~/tpl/js/jquery.dynamic.js"
                ));



            //< !--Other plugins(load only nessesary plugins for every page) -->
            bundles.Add(new ScriptBundle("~/bundles/formonlypage").Include(
                "~/tpl/plugins/forms/fancyselect/fancySelect.js",
                "~/tpl/plugins/charts/sparklines/jquery.sparkline.js",

              
                // Make-Admin
                "~/Scripts/make-admin/select2/select2.js",
                "~/Scripts/make-admin/select2/select2_locale_pt-BR.js",
                "~/Scripts/make-admin/bootstrap-tags-input/bootstrap-tagsinput.js",             
                "~/tpl/js/libs/typeahead.bundle.js",
                "~/tpl/plugins/forms/bootstrap-markdown/bootstrap-markdown.js",
                "~/tpl/plugins/forms/summernote/summernote.js",
                "~/tpl/js/pages/forms-advanced.js"
                ));


            //< !--/ Form basic-- >
            bundles.Add(new ScriptBundle("~/bundles/formbasic").Include(
              "~/tpl/plugins/forms/bootstrap-filestyle/bootstrap-filestyle.js",
              "~/tpl/plugins/forms/autosize/jquery.autosize.js",
              "~/tpl/plugins/forms/maxlength/bootstrap-maxlength.js",
              "~/tpl/plugins/forms/checkall/jquery.checkAll.js",
              "~/tpl/js/pages/forms-basic.js"
              ));

            //< !--/ Form validate-- >
            bundles.Add(new ScriptBundle("~/bundles/formval").Include(
                "~/tpl/plugins/forms/validation/additional-methods.min.js",
                "~/tpl/js/pages/forms-validation.js",
                "~/tpl/plugins/forms/validation/jquery.validate.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/formwizard").Include(
                "~/tpl/plugins/forms/bootstrap-wizard/jquery.bootstrap.wizard.js",
                "~/tpl/js/pages/forms-wizard.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/formtabs").Include(
                "~/tpl/plugins/ui/tabdrop/bootstrap-tabdrop.js",
                "~/tpl/js/jquery.dynamic.js",
                "~/tpl/js/main.js",
                "~/tpl/js/pages/tabs.js"
                ));

            bundles.Add(new StyleBundle("~/Content/angularcss").Include(
                    "~/Content/cooperchip/contato.css",
                    "~/Content/cooperchip/anticoagulacao.css"
                ));

            // Usando o Angular 1.5.7
            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
               "~/Scripts/AngularJS/angular.min.js",

               "~/Scripts/AngularJS/angular-sanitize.min.js",
               "~/Scripts/AngularJS/angular-animate.min.js",

               "~/Scripts/AngularJS/i18n/angular-locale_pt-br.js",
               "~/Scripts/AngularJS/angular-route.min.js",
               "~/Scripts/AngularJS/angular-messages.min.js",
               "~/Scripts/AngularJS/ui-bootstrap-tpls-2.0.1.js",
               "~/Scripts/Others/moment.min.js",
               "~/Scripts/Others/calendar.js",
               "~/Scripts/Others/fullcalendar.js",
               "~/Scripts/Others/gcal.js",
               "~/Scripts/App/ngModule.js",
               "~/Scripts/App/Ctrl/jsonToDateFilter/jsonToDateFilter.js",
               "~/Scripts/App/Ctrl/dirPagination/dirPagination.js"
               ));

            bundles.Add(new ScriptBundle("~/bundles/angularservices").Include(
               "~/Scripts/App/Service/Alergia/alergiaService.js",
               //"~/Scripts/App/Service/getDiscriptionsService.js",
               "~/Scripts/App/Service/Medicamento/medicamentoService.js",
               "~/Scripts/App/Service/Medico/MedicoService.js",
               "~/Scripts/App/Service/Dreno/drenoService.js",
               "~/Scripts/App/Service/AtbEmUso/atbemusoService.js",
               "~/Scripts/App/Service/AtbJaUtilizado/atbJaUtilizadoService.js",
               "~/Scripts/App/Service/ChamadaMedico/chamadaMedicoService.js",
               "~/Scripts/App/Service/Prescricao/prescricaoService.js",
               "~/Scripts/App/Service/InteracaoMedicamentosa/interacaoMedicamentosaService.js",
               "~/Scripts/App/Service/Especialidade/especialidadeService.js",
               "~/Scripts/App/Service/Generico/GenericoService.js",
               "~/Scripts/App/Service/Agendamento/agendamentoService.js",
               "~/Scripts/App/Service/TipoDreno/tipodrenoService.js",
               "~/Scripts/App/Service/Util/utilService.js",
               "~/Scripts/App/Service/Prontuario/prontuarioService.js",
               "~/Scripts/App/Service/Precaucao/precaucaoService.js",
               "~/Scripts/App/Service/ProntuarioPrecaucao/prontuarioprecaucaoService.js",
               "~/Scripts/App/Service/TipoDePrecaucao/tipodeprecaucaoService.js",
               "~/Scripts/App/Service/CausaPrecaucao/causaprecaucaoService.js",
               "~/Scripts/App/Service/CidAdaptada/cidAdaptadaService.js",
               "~/Scripts/App/Service/Dieta/dietaService.js",
               "~/Scripts/App/Service/Complicacao/complicacaoService.js",
               "~/Scripts/App/Service/Endereco/enderecoService.js",
               "~/Scripts/App/Service/Cidade/cidadeService.js",
               "~/Scripts/App/Service/Bairro/bairroService.js",
               "~/Scripts/App/Service/Uf/ufService.js",
               "~/Scripts/App/Service/Classe/classeService.js",
               "~/Scripts/App/Service/PrecaucaoAerozol/precaucaoAerozolService.js",
               "~/Scripts/App/Service/PrecaucaoContato/precaucaoContatoService.js",
               "~/Scripts/App/Service/PrecaucaoGoticula/precaucaoGoticulaService.js",
               "~/Scripts/App/Service/PrecaucaoPadrao/precaucaoPadraoService.js",
               "~/Scripts/App/Service/BaseDeConhecimento/baseDeConhecimentoService.js",

               "~/Scripts/App/Service/Notificacoes/notificacoesService.js",

               "~/Scripts/App/Service/Convenio/convenioService.js",
               "~/Scripts/App/Service/Sexo/sexoService.js",
               "~/Scripts/App/Service/Setor/setorService.js",
               "~/Scripts/App/Service/Leito/leitoService.js",
               "~/Scripts/App/Service/EstadoDoPaciente/estadoDoPacienteService.js",

               "~/Scripts/App/Service/Paciente/PacienteService.js",


               "~/Scripts/App/Service/ExameDescricao/exameDescricaoService.js",
               "~/Scripts/App/Service/Anticoagulacao/anticoagulacaoService.js",
               "~/Scripts/App/Service/Fisioterapia/fisioterapiaService.js",
               "~/Scripts/App/Service/SimplePaginationService.js"

           ));


            bundles.Add(new ScriptBundle("~/bundles/angularctrl").Include(
                "~/Scripts/App/Ctrl/SinaisVitais/SinaisVitaisCtrl.js",
                "~/Scripts/App/Ctrl/Uf/UfCtrl.js",
                "~/Scripts/App/Ctrl/AtbEmUso/atbemusoCtrl.js",
                "~/Scripts/App/Ctrl/Prontuario/ProntuarioCtrl.js",
                "~/Scripts/App/Ctrl/ProntuarioBase/prontuarioBaseCtrl.js",
                "~/Scripts/App/Ctrl/Prescricao/PrescricaoCtrl.js",
                "~/Scripts/App/Ctrl/ExameDeImagem/exameDeImagemCtrl.js",
                "~/Scripts/App/Ctrl/BalancoHidrico/balancoHidricoCtrl.js",
                "~/Scripts/App/Ctrl/Dashboard/DashboardCtrl.js",
                "~/Scripts/app/Ctrl/FullCalendar/FullCalendarCtrl.js",
                "~/Scripts/app/Ctrl/Alergia/AlergiaCtrl.js",
                "~/Scripts/app/Ctrl/AgendamentoAgenda/AgendamentoAgendaCtrl.js",
                "~/Scripts/app/Ctrl/InteracaoMedicamentosa/InteracaoMedicamentosaCtrl.js",
                "~/Scripts/app/Ctrl/Anticoagulacao/anticoagulacaoCtrj.js",
                "~/Scripts/App/Ctrl/DemoCtrl.js",
                "~/Scripts/App/Ctrl/ListaTelefonica/listaTelefonicaCtrl.js",
                "~/Scripts/App/Ctrl/TipoDreno/tipodrenoCtrl.js",
                "~/Scripts/App/Ctrl/Dreno/drenoCtrl.js",
                "~/Scripts/App/Ctrl/Generico/genericoCtrl.js",
                "~/Scripts/App/Ctrl/Dieta/dietaCtrl.js",
                "~/Scripts/App/Ctrl/Endereco/enderecoCtrl.js",
                "~/Scripts/App/Ctrl/CidAdaptada/cidadaptadaCtrl.js",
                "~/Scripts/App/Ctrl/Cidade/cidadeCtrl.js",
                "~/Scripts/App/Ctrl/Bairro/bairroCtrl.js",
                "~/Scripts/App/Ctrl/Fisioterapia/fisioterapiaCtrl.js",
                "~/Scripts/App/Ctrl/Complicacao/complicacaoCtrl.js",
                /* ----------------------------------------------- */
                "~/Scripts/App/Ctrl/Convenio/convenioCtrl.js",                
                "~/Scripts/App/Ctrl/Leito/leitoCtrl.js",                
                "~/Scripts/App/Ctrl/Setor/setorCtrl.js",
                "~/Scripts/App/Ctrl/EstadoDoPaciente/estadoDoPacienteCtrl.js",
                "~/Scripts/App/Ctrl/ChamadaMedico/chamadaMedicoCtrl.js",
                /* ----------------------------------------------- */
                // Chamando depois do bloco acima
                "~/Scripts/app/Ctrl/Paciente/PacienteCtrl.js",


                "~/Scripts/App/Ctrl/AtbJaUtilizado/atbjautilizadoCtrl.js",
                "~/Scripts/App/Ctrl/ApresentacaoAjusteInteracao/apresentacaoajusteinteracaoCtrl.js",
                "~/Scripts/App/Ctrl/TelefonePaciente/telefonePacienteCtrl.js",
                "~/Scripts/App/Ctrl/Precaucao/crudprecaucaoCtrl.js",
                "~/Scripts/App/Ctrl/ProntuarioPrecaucao/prontuarioprecaucaoCtrl.js",
                "~/Scripts/App/Ctrl/PrecaucaoAerozol/precaucaoAerozolCtrl.js",
                "~/Scripts/App/Ctrl/PrecaucaoContato/precaucaoContatoCtrl.js",
                "~/Scripts/App/Ctrl/PrecaucaoGoticula/precaucaoGoticulaCtrl.js",
                "~/Scripts/App/Ctrl/PrecaucaoPadrao/precaucaoPadraoCtrl.js",
                "~/Scripts/App/Ctrl/ClassesMedicamentos/classesMedicamentosCtrl.js",
                "~/Scripts/App/Ctrl/ExameDescricao/exameDescricaoCtrl.js",
                "~/Scripts/App/Ctrl/BaseDeConhecimento/baseDeConhecimentoCtrl.js",
                "~/Scripts/App/Ctrl/MedicamentosEAfins/medicamentoPosologiaCtrl.js",
                "~/Scripts/App/Ctrl/MedicamentosEAfins/medicamentoApresentacaoCtrl.js",
                "~/Scripts/App/Ctrl/MedicamentosEAfins/MedicamentoAjusteCtrl.js",
                "~/Scripts/App/Ctrl/MedicamentosEAfins/MedicamentoCtrl.js",
                "~/Scripts/App/Ctrl/Medico/MedicoCtrl.js",
                "~/Scripts/App/Ctrl/Especialidade/EspecialidadeCtrl.js",             
                "~/Scripts/App/Ctrl/ModaisUIAngular/ModalDemoCtrl.js",
                "~/Scripts/App/Ctrl/ModaisUIAngular/ModalApresentacaoCtrl.js",
                "~/Scripts/App/Ctrl/ModaisUIAngular/ModalPacientesLeitosCtrl.js",
                "~/Scripts/App/Ctrl/ModaisUIAngular/ModalNovoProntuarioCtrl.js",
                "~/Scripts/App/Ctrl/ModaisUIAngular/ModalFullCalendarCtrl.js",
                "~/Scripts/App/Ctrl/LeitosPacientePainel/LeitosPacientePainelCtrl.js",

                "~/Scripts/App/Ctrl/Notificacoes/notificacoesCtrj.js",


                "~/Scripts/App/Ctrl/SimplePaginationCtrl.js"


                ));


            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                    "~/Scripts/Others/toastr.js"
                ));


            /* Carlos Inclusão de Tabs */
            bundles.Add(new StyleBundle("~/bundles/tabscooperchipcss").Include(
                    "~/Scripts/cooperchip/tabs/styles/bootstrap-responsive.min.css",
                    "~/Scripts/cooperchip/tabs/styles/font-awesome.min.css",
                    "~/Scripts/cooperchip/tabs/css/preview.min.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/tabscooperchipjs").Include(                
                "~/Scripts/cooperchip/tabs/scripts/tabs-addon.js"
                ));
            /* Carlos Inclusão de Tabs */


            BundleTable.EnableOptimizations = true;


        }
    }
}
