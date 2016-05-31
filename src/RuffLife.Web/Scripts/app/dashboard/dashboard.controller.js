'use strict';

angular.module('app').controller('dashboardController', DashboardController);

UserRepository.$inject = ['userRepository'];

function DashboardController(userRepository, $stateParams) {
    var vm = this;
    //var username = $stateParams.username;

    userRepository
    .get(username)
    .then(function (user) {
        vm.user = user;
    });
    
};