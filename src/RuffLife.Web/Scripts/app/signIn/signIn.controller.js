'use strict';

angular.module('app').controller('signInController', SignInController);

SignInController.$inject = ['userAuthService', '$state'];

function SignInController(userAuthService, $state) {
    var vm = this;

    vm.user = {
        username: '',
        password: ''
    };
    vm.errorMessage = '';

    vm.login = function () {
        userAuthService.isValidUser(vm.user).then(function (response) {
            if (response == 0) {
                return $state.go('dashboard');
            }
        })
    };

    vm.register = function () {
        return $state.go('chooseUserType');
    };
};