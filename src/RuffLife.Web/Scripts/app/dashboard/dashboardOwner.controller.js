'use strict';

angular.module('app').controller('dashboardOwnerController', DashboardOwnerController);

DashboardOwnerController.$inject = ['ownerService', 'orderedDogWalksService', 'pastDogWalksService', '$rootScope'];

function DashboardOwnerController(ownerService, orderedDogWalksService, pastDogWalksService, $rootScope) {
    var vm = this;

    vm.isAddPet = false;
    vm.isOrdered = false;
    vm.dog = {};
    vm.user = {
        username: "Izabela",
        location: "Split",
        email: "izabela@dump.hr",
        costPerHourInHRK: 50,
        contactNumber: "095",
        pet: [{
            petName: "Roni",
            petImage: "#",
        },
        {
            petName: "Leo",
            petImage: "#",
        }]
    };

    vm.orderedWalks = orderedDogWalksService.getOrderedWalks();
    console.log(vm.orderedWalks);
    vm.currentWalk = orderedDogWalksService.getCurrentWalk();
    console.log(vm.currentWalk);
    vm.pastWalks = pastDogWalksService.getPastWalks();
    console.log(vm.pastWalks);

    vm.walkOrder = function () {

        vm.isOrdered = false;
    };

    vm.save = function () {
        vm.isAddPet = false;
        //dog.push();
    };
};