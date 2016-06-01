'use strict';

angular.module('app').directive('dashboardUpcomingWalk', DashboardUpcomingWalk);

function DashboardUpcomingWalk() {
    return {
        templateUrl: "./Scripts/app/common/directives/dashboard/upcoming.walk.template.html",
        restrict: "A"
    }
}