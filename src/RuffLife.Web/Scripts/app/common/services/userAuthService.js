'use strict';

angular.module('app').factory('userAuthService', UserAuthService);

UserAuthService.$inject = ['$http', '$q', '$rootScope'];

function UserAuthService($http, $q, $rootScope) {
    var newUserType;
    var owners;
    var walkers;
    function getAllOwners() {
        $http.get('/api/owners/all').then(function (response) {
            owners = response.data;
        });
    };
    getAllOwners();

    function getAllWalkers() {
        $http.get('/api/walkers/all').then(function (response) {
            walkers = response.data;
        });
    };
    getAllWalkers();

    function isValidUser(username, type) {
        var isValid = 0;
        if (type == 'owner')
            angular.forEach(owners, function (value, key) {
                if (value.Username == username) { isValid = 1; $rootScope.user = value; }
            });
        else
            angular.forEach(walkers, function (value, key) {
                if (value.Username == username) { isValid = 1; $rootScope.user = value; }
            });
        return $q.resolve(isValid);
    };

    function getNewUserType() {
        return $q.resolve(newUserType);
    }

    function setNewUserType(type) {
        newUserType = type;

        return $q.resolve();
    };

    return {
        isValidUser: isValidUser,
        getNewUserType: getNewUserType,
        setNewUserType: setNewUserType
    };
};