'use strict'

angular.module('app').factory('walkService', WalkService);

WalkService.$inject = ['$http'];

function WalkService($http) {
    function createWalk(walkToCreate) {
        var walkerId = walkToCreate.walker;
        return $http.post(`api/walks/${walkerId}/createWalk`, walkToCreate.user);
    }

    return {
        createWalk : createWalk
    }
}