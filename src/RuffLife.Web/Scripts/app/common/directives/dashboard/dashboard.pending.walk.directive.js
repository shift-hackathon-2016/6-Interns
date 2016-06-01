'use strict';

angular.module('app').directive('dashboardPendingWalk', DashboardPendingWalk);

function DashboardPendingWalk() {
    return {
        templateUrl: "./Scripts/app/common/directives/dashboard/pending.walk.template.html",
        restrict: "A"
    }
}