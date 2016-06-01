'use strict';

angular.module('app').factory('pastDogWalksService', PastDogWalksService);

PastDogWalksService.$inject = ['$http', '$q'];

function PastDogWalksService($http, $q) {
    var orderedWalks = [{ startTime: new Date(), endTime: new Date(), location: 'Split', price: '50', walker: { username: 'Mirko' } },
        { startTime: new Date(), endTime: new Date(), location: 'Kaštela', price: '10', walker: { username: 'Nikola' } }];

    function getPastWalks() {

        var pastWalks = [];
        angular.forEach(orderedWalks, function (value, key) {
            var currentTime = Date.now();
            if (value.endTime < currentTime)
                pastWalks.push(value);
        });
        console.log(pastWalks);
        return $q.resolve(pastWalks);
    };

    return {
        getPastWalks: getPastWalks,
    };
};