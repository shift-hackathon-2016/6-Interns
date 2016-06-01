'use strict';

angular.module('app').directive('dashboardPendingWalk', DashboardPendingWalk);

function DashboardPendingWalk() {
    return {
        templateUrl: "Scripts/app/common/dashboard/dashboard.pending.walk.template.html",
        restrict: "A"
    }
}