'use strict';

angular.module('app').factory('dogService', DogService);

DogService.$inject = ['$http', '$q'];

function DogService($http, $q) {

    return {
    };
};