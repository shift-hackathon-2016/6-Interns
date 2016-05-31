'use strict';

angular.module('app').factory('walkerReviewService', WalkerReviewService);

WalkerReviewService.$inject = ['$http', '$q'];

function WalkerReviewService($http, $q) {
    var walkerReviews;

    function getWalkerReviews(id) {
        $http.get('/api/reviewForWalkers/' + id).then(function () {
            console.log('walker reviews: ', response.data);
            walkerReviews = response.data;
            return $q.resolve(walkerReviews);
        });
    }

    return {
        walkerReviews: walkerReviews,
        getWalkerReviews: getWalkerReviews
    };
};