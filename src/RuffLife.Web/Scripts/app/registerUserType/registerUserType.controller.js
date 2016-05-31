'use strict';

angular.module('app').controller('registerUserTypeController', RegisterUserTypeController);

RegisterUserTypeController.$inject = ['$state', '$rootScope'];

function RegisterUserTypeController($state, $rootScope) {
    var vm = this;

    vm.text = 'Hello user';

    vm.userType;

    vm.continue = function () {
        $rootScope.userType = vm.userType;
        return $state.go('newUser');
    }
};