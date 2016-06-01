'use strict';

angular.module('app').config(NewWalkStateProvider);

NewWalkStateProvider.$inject = ['$stateProvider'];

function NewWalkStateProvider($stateProvider) {
    $stateProvider
    .state('new-walk', {
        url: '/new-walk',
        templateUrl: './../../Scripts/app/newWalk/newWalk.template.html',
        controller: 'newWalkController',
        controllerAs: 'vm'
    });
};