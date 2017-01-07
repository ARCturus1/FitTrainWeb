'use strict';
angular.module('fitTraining.userspace.services', [])
    .factory('UserSettingsService',
    [
        '$http',
        function($http) {
            return {
                postSettins: function(weight, height, activity) {
                    return $http.post('api/UserSettings', { Weight: weight, Height: height, ActivityOfHuman: activity.id });
                },
                getDietDayByMode: function(mode) {
                    return $http.get('api/UserSettings/GetUserSettingByMode?mode=' + mode);
                }
            }
        }
    ]);