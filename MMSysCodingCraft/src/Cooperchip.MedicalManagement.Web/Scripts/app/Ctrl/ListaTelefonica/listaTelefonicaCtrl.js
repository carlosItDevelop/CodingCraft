
(function () {
    'use strict';

    // ---------------------------------------------------- //


    app.controller("listaTelefonicaCtrl",
        ['$scope', 'uppercaseFilter', '$http',
            function ($scope, uppercaseFilter, $http) {
                $scope.titulo = "Lista de Contatos";

                $scope.contatos = [];
                $scope.operadoras = [];

                var carregaContatos = function () {
                    $http.get("/Home/GetContato").success(function (data) {
                        //console.log(data);
                        $scope.contatos = data;
                    }).error(function (data, status) {
                        $scope.message = "Aconteceu um erro: " + data;
                    });
                };




                var carregaOperadoras = function () {
                    $http.get("/Home/GetOperadoras").success(function (data) {
                        //console.log(data);
                        $scope.operadoras = data;
                    }).error(function (data, status) {
                        $scope.message = "Aconteceu um erro: " + data;
                    });
                };


                $scope.adicionarContato = function (contato) {
                    contato.data = new Date();
                    $http.post("/Home/AddContato", contato).success(function (data) {
                        delete $scope.contato;
                        $scope.contatoForm.$setPristine();
                        carregaContatos();
                    }).error(function (data, status) {
                        $scope.message = "Aconteceu um erro: " + data;
                    });
                };


                $scope.apagarContatos = function (contatos) {
                    $scope.contatos = contatos.filter(function (contato) {
                        if (contato.selecionado) {
                            $http.post("/Home/DelContato/" + contato.ContatoId).success(function (data) {
                                console.log(data);
                            }).error(function (data, status) {
                                $scope.message = "Aconteceu um erro: " + data;
                            });
                        };
                        if (!contato.selecionado) return contato;
                    });
                };


                $scope.isContatoSelecionado = function (contatos) {
                    return contatos.some(function (contato) {
                        return contato.selecionado;
                    });
                };
                $scope.ordenarPor = function (campo) {
                    $scope.criterioDeOrdenacao = campo;
                    $scope.direcaoDaOrdenacao = !$scope.direcaoDaOrdenacao;
                };


                carregaContatos();
                carregaOperadoras();


            }
        ]);
}());
