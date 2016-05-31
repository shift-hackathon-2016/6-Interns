'use strict';

angular.module('app').config(RegisterUserTypeStateProvider);

RegisterUserTypeStateProvider.$inject = ['$stateProvider'];

function RegisterUserTypeStateProvider($stateProvider) {
    $stateProvider
    .state('chooseUserType', {
        url: '/user-type',
        templateUrl: './../../Scripts/app/registerUserType/registerUserType.template.html',
        controller: 'registerUserTypeController',
        controllerAs: 'vm'
    });
};