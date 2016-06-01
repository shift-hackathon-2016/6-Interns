'use strict'

angular.module('app').factory('walkService', WalkService);

WalkService.$inject = ['$http'];

function WalkService($http) {
    function createWalk(walkToCreate) {
        $http.post('api/walks/create', walkToCreate);
    }

    return {
        createWalk : createWalk
    }
}