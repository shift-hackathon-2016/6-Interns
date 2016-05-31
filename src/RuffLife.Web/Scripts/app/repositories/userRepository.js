'use strict';

angular.module('app').factory('userRepository', UserRepository);

UserRepository.$inject = ['$q'];

function UserRepository($q) {

    var users = [{
        'userType': 'owner',
        'username': 'mirko',
        'password': '12345'
    },
    {
        'userType': 'walker',
        'username': 'andrea',
        'password': '11111'
    },
    {
        'userType': 'owner',
        'username': 'nikola',
        'password': '55555'
    }];

    function get(username) {
        angular.forEach(users, function (value, key) {
            if (value.username == username)
                return $q.resolve(users[key]);
        });
    }

    var currentUser = get(username);

    return {
        users: users,
        currentUser: currentUser,
        get: get
    }

}