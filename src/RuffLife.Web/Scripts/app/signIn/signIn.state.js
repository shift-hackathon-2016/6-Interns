﻿'use strict';

angular.module('app').config(SignInStateProvider);

SignInStateProvider.$inject = ['$stateProvider'];

function SignInStateProvider($stateProvider) {
    $stateProvider
    .state('signIn', {
        url: '/sign-in',
        templateUrl: './../../Scripts/app/signIn/signIn.template.html',
        controller: 'signInController',
        controllerAs: 'vm'
    });
};