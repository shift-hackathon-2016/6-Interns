'use strict';

angular.module('app').factory('userAuthService', UserAuthService);

UserAuthService.$inject = ['$http', '$q'];

function UserAuthService($http, $q) {
    var users = [];

    function getAllUsers() {
        $http.post('').then(function (users) {
            users = users;
        });
    };

    getAllUsers();

    function isValidUser() {
        var isValid = 0;
        //angular.foreach(users, function (value, key) {
        //    if (value.username != user.username) isValid = 1;
        //    else if(value.password != user.password) isValid = 2;
        //    else isValid = 0;
        //});

        return $q.resolve(isValid);
    };

    return {
        isValidUser: isValidUser
    };
};