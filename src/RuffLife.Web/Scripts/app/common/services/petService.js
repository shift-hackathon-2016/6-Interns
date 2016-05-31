'use strict';

angular.module('app').factory('petService', PetService);

PetService.$inject = ['$http', '$q'];

function PetService($http, $q) {
    var pets;

    function getAllPets() {
        $http.get('http://localhost:2493/api/owners/get-all').then(function (response) {
            owners = response.data;
        });
    };
    getAllOwners();

    function addOwner(owner) {
        owners.push(owner);
    };

    return {
        owners: owners,
        addOwner: addOwner
    };
};