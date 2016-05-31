'use strict';

angular.module('app').factory('userAuthService', UserAuthService);

UserAuthService.$inject = ['$http', '$q'];

function UserAuthService($http, $q) {
    //var users = [{ username: 'mirko', password: 'hej' }, { username: 'andrea', password: 'hoj' }];
    var newUserType;
    var users;
    function getAllOwners() {
        $http.get('http://localhost:2493/api/owners/get-all').then(function (response) {
            console.log(response.data);
            users = response.data;
        });
    };

    getAllOwners();

    function isValidUser(username) {
        var isValid = 0;
        console.log(users);
        angular.forEach(users, function (value, key) {
            console.log(value.Username);
            if (value.Username == username) isValid = 1;
            
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