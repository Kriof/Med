var app = angular.module('app', ['ui.grid', 'ui.grid.pagination']);

app.controller("TagCtrl",
    function ($scope, $http) {
        $scope.gridOptions = {};
        $scope.gridOptions.data = [];
        var paginationOptions = {
            pageNumber: 1,
            pageSize: 25,
            sort: null
        };
        $scope.onInit = function () {
            $scope.items = {};

            $scope.getTagFromApi();
            $scope.gridOptions.columnDefs = [
                { name: 'Name' },
                { name: 'Usage', field: 'Count' },
                { name: 'Percentage' }
            ];
        };
        $scope.gridOptions = {
            paginationPageSizes: [25, 50, 75],
            paginationPageSize: 25,
            useExternalPagination: true,
            totalItems: 1000,
            onRegisterApi: function (gridApi) {

                gridApi.pagination.on.paginationChanged($scope, function (newPage, pageSize) {
                    paginationOptions.pageNumber = newPage;
                    paginationOptions.pageSize = pageSize;
                    $scope.getTagFromApi();
                });
            }
        }
        $scope.getTagFromApi = function () {

            $http({
                method: 'GET',
                url: 'http://localhost/Mediporta_Services/api/PopularTag/GetTags',
                params: {
                    pageNumber: paginationOptions.pageNumber,
                    pageSize: paginationOptions.pageSize
                }
            })
                .then(function (data, status) {
                    $scope.gridOptions.data = data.data.Data.length ? data.data.Data : data;
                },
                function (data, status) {
                    console.log("Error");
                    console.log(data);
                    console.log(status);
                });

        }
    });



