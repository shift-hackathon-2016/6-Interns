'use strict';

angular.module('app').factory('ownerService', OwnerService);

OwnerService.$inject = ['$http', '$q'];

function OwnerService($http, $q) {
    var owners;
    function getAllOwners() {
        $http.get('http://localhost:2493/api/owners/get-all').then(function (response) {
            owners = response.data;
        });
    };
    getAllOwners();

    function getAllWalkers() {
        $http.get('http://localhost:2493/api/walkers/get-all').then(function (response) {
            walkers = response.data;
        });
    };
    getAllWalkers();

    function addOwner(owner) {
        owners.push(owner);
    };

    return {
        owners: owners
    };
};