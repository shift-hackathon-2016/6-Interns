'use strict';

angular.module('app').controller('dashboardController', DashboardController);

DashboardController.$inject = ['$rootScope', '$state'];

function DashboardController($rootScope, $state) {
    var vm = this;

    if ($rootScope.userType == 'owner') return $state.go('.owner');
    else return $state.go('.walker');
};