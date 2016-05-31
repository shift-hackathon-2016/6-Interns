'use strict';

angular.module('app').config(DashboardStateProvider);

DashboardStateProvider.$inject = ['$stateProvider'];

function DashboardStateProvider($stateProvider) {
    $stateProvider
    .state('dashboard', {
        url: '/dashboard',
        templateUrl: './Scripts/app/dashboard/dashboard.template.html',
        controller: 'dashboardController',
        controllerAs: 'vm'
    });
};