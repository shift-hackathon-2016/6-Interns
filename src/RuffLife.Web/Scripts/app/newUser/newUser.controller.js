'use strict';

angular.module('app').controller('newUserController', NewUserController);

NewUserController.$inject = ['$state', '$rootScope'];

function NewUserController($state, $rootScope) {
    var vm = this;

    vm.user = {};

    vm.save = function () {
        console.log('Type: ', $rootScope.userType);
        return $state.go('dashboard');
    };
};