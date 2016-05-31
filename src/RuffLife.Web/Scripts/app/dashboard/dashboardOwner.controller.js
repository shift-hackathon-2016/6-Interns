'use strict';

angular.module('app').controller('dashboardOwnerController', DashboardOwnerController);

DashboardOwnerController.$inject = ['ownerService'];

function DashboardOwnerController(ownerService) {
    var vm = this;

    vm.isAddPet = false;
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

    vm.save = function () {
        vm.isAddPet = false;
        //dog.push();
    };

    vm.walkOrder = function () {

    };
};