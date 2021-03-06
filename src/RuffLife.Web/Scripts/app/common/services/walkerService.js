﻿'use strict';

angular.module('app').factory('walkerService', WalkerService);

WalkerService.$inject = ['$http', '$q'];

function WalkerService($http, $q) {
    var walkers;

    function getAllWalkers() {
        $http.get('/api/walkers/all').then(function (response) {
            walkers = response.data;
        });
    };
    getAllWalkers();

    function addWalker(walker) {
        $http.post('/api/walkers/create', walker).then(function () {
            walkers.push(walker);
        });
    };

    function httpAllWalkers() {
        return $http.get('/api/walkers/all');
    }

    return {
        httpAllWalkers: httpAllWalkers,
        walkers: walkers,
        addWalker: addWalker
    };
};