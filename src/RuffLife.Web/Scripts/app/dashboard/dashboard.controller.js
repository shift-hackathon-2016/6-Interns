'use strict';

angular.module('app').controller('dashboardController', DashboardController);

UserRepository.$inject = ['userRepository'];

function DashboardController(userRepository, $stateParams) {
    var vm = this;
    
    vm.user = userRepository.currentUser;
   
};