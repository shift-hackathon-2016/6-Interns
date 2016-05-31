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
        userAuthService.isValidUser().then(function (response) {
            if (response == 0) {
                console.log('Success');
                return $state.go('chooseUserType');
            }
        })
    };
};