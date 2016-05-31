'use strict';

angular.module('app').config(AppConfig)

AppConfig.$inject = ['$urlRouterProvider', '$stateProvider']

function AppConfig($urlRouterProvider) {
    $urlRouterProvider.otherwise('/sign-in');
}