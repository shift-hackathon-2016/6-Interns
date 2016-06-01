'use strict';

angular.module('app').controller('dashboardWalkerController', DashboardWalkerController);

DashboardWalkerController.$inject = ['userAuthService', 'ownerService', 'pendingWalksService', 'upcomingWalksService', '$scope', '$rootScope'];

function DashboardWalkerController(userAuthService, ownerService, pendingWalksService, upcomingWalksService, $scope, $rootScope) {
    var vm = this;
    vm.user = $rootScope.user;
    
    vm.pendingWalks = pendingWalksService.pendingWalks;

    vm.upcomingWalks = upcomingWalksService.upcomingWalks;

    vm.reject = function (id) {
        console.log('Rejected!');
        pendingWalksService.removePendingWalk(id);
        $scope.$on('PENDING_WALK_REMOVED', function (event, obj) { vm.pendingWalks = obj;});
    };

    vm.accept = function (id) {
        console.log('Accepted!');
    };
};