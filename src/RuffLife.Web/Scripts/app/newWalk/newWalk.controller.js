'use strict';

angular.module('app').controller('newWalkController', NewWalkController);

NewWalkController.$inject = ['walkerService', '$rootScope', '$state'];

function NewWalkController(walkerService, $rootScope, $state) {
    var vm = this;
    vm.walkers = []

    vm.newWalk = {
        user : $rootScope.user,
        walker: ""

    }

    function createWalk (){
        walkService.createWalk(vm.newWalk)
            .success(() => {
                return $state.go('dashboard')
            })
    }

    getWalkers();

    function getWalkers() {
        walkerService.httpAllWalkers()
            .then(result => {
                vm.walkers = result.data;
            });
    }

}