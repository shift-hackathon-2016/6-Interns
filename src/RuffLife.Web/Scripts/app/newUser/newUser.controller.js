'use strict';

angular.module('app').controller('newUserController', NewUserController);

NewUserController.$inject = ['$state', 'userAuthService'];

function NewUserController($state, userAuthService) {
    var vm = this;

    vm.user = {};

    vm.userType;
    userAuthService.getNewUserType().then(function (type) {
        vm.userType = type;
    });

    vm.save = function () {
        return $state.go('dashboard');
    };
};