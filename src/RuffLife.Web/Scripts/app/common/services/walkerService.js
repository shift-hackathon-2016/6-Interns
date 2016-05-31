'use strict';

angular.module('app').factory('walkerService', WalkerService);

WalkerService.$inject = ['$http', '$q'];

function WalkerService($http, $q) {
    var walkers;

    function getAllWalkers() {
        $http.get('http://localhost:2493/api/walkers/get-all').then(function (response) {
            walkers = response.data;
        });
    };
    getAllWalkers();

    function addWalker(walker) {
        walkers.push(walker);
    };

    return {
        walkers: walkers
    };
};