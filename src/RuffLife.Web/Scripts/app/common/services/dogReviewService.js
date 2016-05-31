'use strict';

angular.module('app').factory('dogReviewService', DogReviewService);

DogReviewService.$inject = ['$http', '$q'];

function DogReviewService($http, $q) {
    var dogReviews;

    return {
        dogReviews: dogReviews
    };
};