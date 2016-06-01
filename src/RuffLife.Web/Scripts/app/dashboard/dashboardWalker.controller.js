'use strict';

angular.module('app').controller('dashboardWalkerController', DashboardWalkerController);

DashboardWalkerController.$inject = ['userAuthService', 'ownerService', 'pendingWalksService', 'upcomingWalksService', '$scope', '$rootScope'];

function DashboardWalkerController(userAuthService, ownerService, pendingWalksService, upcomingWalksService, $scope, $rootScope) {
    var vm = this;
    vm.user = $rootScope.user;
    
    vm.pendingWalks = pendingWalksService.pendingWalks;

    vm.upcomingWalks = upcomingWalksService.upcomingWalks;

    vm.reject = function () {
        console.log('Rejected!');
    };

    vm.accept = function () {
        console.log('Accepted!');
    };
};