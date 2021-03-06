﻿'use strict';

angular.module('app').factory('upcomingWalksService', UpcomingWalksService);

UpcomingWalksService.$inject = ['$http', '$q', '$rootScope'];

function UpcomingWalksService($http, $q, $rootScope) {
    var upcomingWalks = [{ startTime: new Date(), endTime: new Date(), location: 'Split', price: '50', dog: { name: 'Cuko' } },
        { startTime: new Date(), endTime: new Date(), location: 'Kaštela', price: '10', dog: { name: 'Rex' } }];

    function addUpcomingWalk(walk) {
        upcomingWalks.push(walk);
        $rootScope.$broadcast('UPCOMING_WALK_ADDED', upcomingWalks);
    };

    function getUpcomingWalks() {
        return $q.resolve(upcomingWalks);
    }

    return {
        upcomingWalks: upcomingWalks,
        getUpcomingWalks: getUpcomingWalks,
        addUpcomingWalk: addUpcomingWalk
    };
};