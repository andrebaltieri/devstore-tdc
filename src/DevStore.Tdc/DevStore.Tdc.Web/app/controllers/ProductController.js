(function () {
    'use strict';

    var controllerId = 'ProductController';

    // TODO: replace app with your module name
    angular.module('app').controller(controllerId,
        ['$scope', '$http', '$rootScope', ProductController]);

    function ProductController($scope, $http, $rootScope) {
        var vm = this;

        vm.title = "Lista de produtos";
        vm.activate = activate;
        vm.products = [];
        vm.product = {
            id: 0,
            name: "",
            productNumber: 0
        };

        GetProducts();

        function activate() { }

        function GetProducts() {
            $http.get('http://localhost:9000/api/v1/public/products')
            .success(function (data, status, headers, config) {
                angular.forEach(data, function (prd) {
                    vm.products.push(prd);
                });
            });
        }

        function GetProduct(id) {
            $http.get('http://localhost:9000/api/v1/public/products' + id)
            .success(function (data, status, headers, config) {
                console.log(data);
                vm.product = data;
            });
        }

        function ResetProduct() {
            vm.product = {
                id: 0,
                title: "",
                price: 0,
                acquireDate: "",
                isActive: true,
                categoryId: 0
            };
        }

        $scope.SelectProduct = function (id) {
            angular.forEach(vm.products, function (prd) {
                if (prd.id == id) {
                    vm.product = prd;
                    console.log(prd);
                }
            });
        };

        $scope.SaveProduct = function () {
            var data = vm.product;
            
            if (data.id == 0) {
                $http.post('http://localhost:9000/api/v1/public/products', data)
                .success(function (result) {
                    toastr.success("Produto cadastrado com sucesso", "Novo Produto");
                    vm.products.push(result);
                    ResetProduct();
                });
            } else {
                $http.put('http://localhost:9000/api/v1/public/products', data)
                .success(function () {
                    toastr.success("Produto alterado com sucesso", "Alteração");
                    ResetProduct();
                });
            }
        };

        $scope.DeleteProduct = function () {
            var cid = vm.product.id;

            if (cid == 0) {
                toastr.error("Selecione um Produto", "Erro");
                return false;
            }

            $http.delete('http://localhost:9000/api/v1/public/products?productId=' + cid)
                .success(function () {
                    angular.forEach(vm.products, function (prd) {
                        if (prd.id == cid) {
                            var index = vm.products.indexOf(prd);
                            vm.products.splice(index, 1);
                            toastr.success("Produto excluído com sucesso!", "Sucesso");
                            ResetProduct();
                        }
                    });
                });
        };

        $scope.NewProduct = function () {
            ResetProduct();
        }
    }
})();
