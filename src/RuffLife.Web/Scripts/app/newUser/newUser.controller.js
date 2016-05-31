'use strict';

angular.module('app').controller('newUserController', NewUserController);

NewUserController.$inject = ['$state', '$rootScope'];

function NewUserController($state, $rootScope) {
    var vm = this;

    vm.userType = $rootScope.userType;
    vm.user = {};

    vm.save = function () {
        console.log('Type: ', $rootScope.userType);
        $rootScope.user = vm.user;
        return $state.go('dashboard');
    };
};