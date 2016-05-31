'use strict';

angular.module('app').factory('walkerReviewService', WalkerReviewService);

WalkerReviewService.$inject = ['$http', '$q'];

function WalkerReviewService($http, $q) {
    var walkerReviews;

    return {
        walkerReviews: walkerReviews
    };
};