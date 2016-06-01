'use strict';

angular.module('app').factory('dogReviewService', DogReviewService);

DogReviewService.$inject = ['$http', '$q'];

function DogReviewService($http, $q) {
    var dogReviews;

    function getDogReviews(id) {
        $http.get('/api/dogs/' + id + '/reviews').then(function (response) {
            dogReviews = response.data;
            console.log(dogReviews);
            return $q.resolve(dogReviews);
        });
    };

    return {
        dogReviews: dogReviews,
        getDogReviews: getDogReviews
    };
};