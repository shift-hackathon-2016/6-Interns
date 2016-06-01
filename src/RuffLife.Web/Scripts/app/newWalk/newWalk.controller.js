'use strict';

angular.module('app').controller('newWalkController', NewWalkController);

NewWalkController.$inject = ['walkerService', '$rootScope', '$state', 'walkService'];

function NewWalkController(walkerService, $rootScope, $state, walkService) {
    var vm = this;
    vm.walkers = []

    vm.newWalk = {
        user : $rootScope.user,
        walker: ""

    }

    getWalkers();

    function getWalkers() {
        walkerService.httpAllWalkers()
            .then(result => {
                vm.walkers = result.data;
            });
    }

    vm.createWalk = function(){
        vm.newWalk.walker = vm.walker;
        walkService.createWalk(vm.newWalk)
            .success(() => {
                return $state.go('dashboard');
            });

    }

}