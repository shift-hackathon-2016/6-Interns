'use strict';

angular.module('app').factory('ownerService', OwnerService);

OwnerService.$inject = ['$http', '$q'];

function OwnerService($http, $q) {
    var owners;

    function getAllOwners() {
        $http.get('/api/owners/all').then(function (response) {
            owners = response.data;
        });
    };
    getAllOwners();

    function addOwner(owner) {
        $http.post('/api/owners/create', owner).then(function () {
            owners.push(owner);
        });
    };

    return {
        owners: owners,
        addOwner: addOwner
    };
};