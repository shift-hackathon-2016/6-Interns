'use strict';

angular.module('app').factory('orderedDogWalksService', OrderedDogWalksService);

OrderedDogWalksService.$inject = ['$http', '$q'];

function OrderedDogWalksService($http, $q) {
    var orderedWalks = [{ startTime: new Date(), endTime: new Date(), location: 'Split', price: '50', walker: { username: 'Mirko' } },
        { startTime: new Date(), endTime: new Date(), location: 'Kaštela', price: '10', walker: { username: 'Nikola' } }];

    /*function addUpcomingWalk(walk) {
        upcomingWalks.push(walk);
    };*/

    function getOrderedWalks() {
        return $q.resolve(orderedWalks);
    };

    function getCurrentWalk() {
        angular.forEach(orderedWalks, function (value, key) {
            var currentTime = Date.now();
            if (!(value.endTime > currentTime && value.startTime < currentTime))
                return $q.resolve('');
            return $q.resolve(value[key]);
        });
    };

    return {
        orderedWalks: orderedWalks,
        getOrderedWalks: getOrderedWalks,
        getCurrentWalk: getCurrentWalk,
        //addUpcomingWalk: addUpcomingWalk
    };
};