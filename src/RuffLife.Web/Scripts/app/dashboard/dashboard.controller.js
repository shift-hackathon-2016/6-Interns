'use strict';

angular.module('app').controller('dashboardController', DashboardController);

DashboardController.$inject = ['$rootScope'];

function DashboardController($rootScope) {
    var vm = this;
   
    vm.username = 'srg';
    console.log('Current type: ', $rootScope.userType);
    console.log('Current user: ', $rootScope.user);
};