'use strict';

angular.module('app').controller('signInController', SignInController);

SignInController.$inject = ['userAuthService', '$state', '$rootScope'];

function SignInController(userAuthService, $state, $rootScope) {
    var vm = this;

    vm.username = '';
    vm.errorMessage = '';

    vm.login = function (type) {
        userAuthService.isValidUser(vm.username, type).then(function (response) {
            console.log(response);
            if (response == 1) {
                console.log(type);
                $rootScope.userType = type;
                return $state.go('dashboard');
            }
        })
    };

    vm.register = function () {
        return $state.go('chooseUserType');
    };
};