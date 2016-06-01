﻿'use strict';

angular.module('app').factory('pendingWalksService', PendingWalksService);

PendingWalksService.$inject = ['$http', '$q', '$rootScope'];

function PendingWalksService($http, $q, $rootScope) {
    var pendingWalks = [{ startTime: new Date(), endTime: new Date(), location: 'Split', dog: { name: 'Cuko' } },
        { startTime: new Date(), endTime: new Date(), location: 'Kaštela', dog: { name: 'Rex' } }];

    function addPendingWalk(walk) {
        pendingWalks.push(walk);
    };

    function getPendingWalks() {
        return $q.resolve(pendingWalks);
    }

    function removePendingWalk(id) {
        pendingWalks.splice(id, 1);
        return $q.resolve(pendingWalks);
    }

    return {
        pendingWalks : pendingWalks,
        getPendingWalks: getPendingWalks,
        addPendingWalk: addPendingWalk,
        removePendingWalk: removePendingWalk
    };
};