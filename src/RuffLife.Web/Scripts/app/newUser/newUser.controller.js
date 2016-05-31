'use strict';

angular.module('app').controller('newUserController', NewUserController);

NewUserController.$inject = ['$state', '$rootScope', 'ownerService', 'walkerService'];

function NewUserController($state, $rootScope, ownerService, walkerService) {
    var vm = this;

    vm.userType = $rootScope.userType;
    vm.user = {};

    vm.save = function () {
        $rootScope.user = vm.user;
        if (vm.userType == 'owner') ownerService.addOwner(vm.user);
        else walkerService.addWalker(vm.user);
        return $state.go('dashboard');
    };
};