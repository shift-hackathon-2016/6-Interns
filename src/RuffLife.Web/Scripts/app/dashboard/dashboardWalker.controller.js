'use strict';

angular.module('app').controller('dashboardWalkerController', DashboardWalkerController);

DashboardWalkerController.$inject = ['userAuthService', 'ownerService', 'pendingWalksService', 'upcomingWalksService', '$scope'];

function DashboardWalkerController(userAuthService, ownerService, pendingWalksService, upcomingWalksService, $scope) {
    var vm = this;

    vm.user = {
        username : "Izabela", 
        location : "Split",
        email : "izabela@dump.hr", 
        costPerHourInHRK : 50, 
        contactNumber: "095",
        walk: [{
            startTime : new Date(), 
            endTime : new Date(), 
            location : "Lokacija1", 
            price : 50
        },
        {
            startTime: new Date(),
            endTime: new Date(),
            location: "Lokacija3",
            price: 70
        }]
    };
    
    vm.pendingWalks = pendingWalksService.pendingWalks;

    vm.upcomingWalks = upcomingWalksService.upcomingWalks;
    console.log('pending: ', vm.pendingWalks);
    console.log('upcoming: ', vm.upcomingWalks);
};