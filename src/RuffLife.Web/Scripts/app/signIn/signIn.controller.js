'use strict';

angular.module('app').controller('signInController', SignInController);

SignInController.$inject = ['userAuthService', '$state'];

function SignInController(userAuthService, $state) {
    var vm = this;

    vm.username = '';
    vm.errorMessage = '';

    vm.login = function () {
        userAuthService.isValidUser(vm.username).then(function (response) {
            console.log(response);
            if (response == 1) {
                return $state.go('dashboard');
            }
        })
    };

    vm.register = function () {
        return $state.go('chooseUserType');
    };
};