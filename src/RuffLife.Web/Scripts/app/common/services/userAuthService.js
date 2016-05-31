'use strict';

angular.module('app').factory('userAuthService', UserAuthService);

UserAuthService.$inject = ['$http', '$q'];

function UserAuthService($http, $q) {
    var users = [{ username: 'mirko', password: 'hej' }, { username: 'andrea', password: 'hoj' }];
    var newUserType;
    //function getAllUsers() {
    //    $http.post('').then(function (users) {
    //        users = users;
    //    });
    //};

    //getAllUsers();

    function isValidUser(user) {
        var isValid;
        angular.forEach(users, function (value, key) {
            if (value.username != user.username) isValid = 1;
            else if (value.password != user.password) isValid = 2;
            else isValid = 0;
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