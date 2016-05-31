'use strict';

angular.module('app').config(DashboardOwnerStateProvider);

DashboardOwnerStateProvider.$inject = ['$stateProvider'];

function DashboardOwnerStateProvider($stateProvider) {
    $stateProvider
    .state('dashboard.owner', {
        url: '/owner',
        templateUrl: './../../Scripts/app/dashboard/dashboardOwner.template.html',
        controller: 'dashboardOwnerController',
        controllerAs: 'vm'

    });

};