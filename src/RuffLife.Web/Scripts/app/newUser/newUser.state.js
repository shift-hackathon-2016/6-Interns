'use strict';

angular.module('app').config(NewUserStateProvider);

NewUserStateProvider.$inject = ['$stateProvider'];

function NewUserStateProvider($stateProvider) {
    $stateProvider
    .state('newUser', {
        url: '/new-user',
        templateUrl: './../../Scripts/app/newUser/newUser.template.html',
        controller: 'newUserController',
        controllerAs: 'vm'
    });
};