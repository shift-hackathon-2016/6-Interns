'use strict';

angular.module('app').controller('registerUserTypeController', RegisterUserTypeController);

RegisterUserTypeController.$inject = ['$state', 'userAuthService'];

function RegisterUserTypeController($state, userAuthService) {
    var vm = this;

    vm.text = 'Hello user';

    vm.userType;

    vm.continue = function () {
        userAuthService.setNewUserType(vm.userType).then(function () {
            return $state.go('newUser');
        });
    }
};