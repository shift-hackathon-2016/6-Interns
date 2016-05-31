'use strict';

angular.module('app').config(DashboardWalkerStateProvider);

DashboardWalkerStateProvider.$inject = ['$stateProvider'];

function DashboardWalkerStateProvider($stateProvider) {
    $stateProvider
    .state('dashboard.walker', {
        url: '/walker',
        templateUrl: './../../Scripts/app/dashboard/dashboardWalker.template.html',
        controller: 'dashboardWalkerController',
        controllerAs: 'vm'
    });

};