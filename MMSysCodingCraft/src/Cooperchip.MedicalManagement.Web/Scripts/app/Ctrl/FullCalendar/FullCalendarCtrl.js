
(function () {

    // ---/ uiCalendar ---

    app.controller("agendaFullCalendar", ['$scope',
        '$http',
        'uiCalendarConfig',
        '$uibModal',
        function ($scope, $http, uiCalendarConfig, $uibModal) {
            $scope.SelectedEvent = null;
            var isFirstTime = true;
            $scope.events = [];
            $scope.eventSources = [$scope.events];

            $scope.NewEvent = {};

            //this function for get datetime from json date
            function getDate(datetime) {
                if (datetime) {
                    var mili = datetime.replace(/\/Date\((-?\d+)\)\//, '$1');
                    return new Date(parseInt(mili));
                } else {
                    return "";
                }
            }

            // this function clears clender enents
            function clearCalendar() {
                if (uiCalendarConfig.calendars.myCalendar) {
                    uiCalendarConfig.calendars.myCalendar.fullCalendar('removeEvents');
                    uiCalendarConfig.calendars.myCalendar.fullCalendar('unselect');
                }
            }

            //Load events from server to display on caledar
            function populate() {
                clearCalendar();
                $http.get('/AgendaCalendar/GetEvents', {
                    cache: false,
                    params: {}
                }).then(function (data) {
                    $scope.events.slice(0, $scope.events.length);
                    angular.forEach(data.data, function (value) {
                        $scope.events.push({
                            id: value.EventId,
                            title: value.Title,
                            description: value.Description,
                            start: new Date(parseInt(value.StartAt.substr(6))),
                            end: new Date(parseInt(value.EndAt.substr(6))),
                            allDay: value.IsFullDay,
                            stick: true
                        });
                    });
                });
            }

            populate();
            //UI- calendar configuration
            $scope.uiConfig = {
                calendar: {
                    height: 450,
                    editable: true,
                    displayEventTime: true,
                    header: {
                        left: 'month,agendaWeek,agendaDay',
                        center: 'title',
                        right: 'today prev,next'
                    },
                    timeFormat: {
                        month: ' ', // for hide on month view
                        agenda: 'h:mm t'
                    },
                    selectable: true,
                    selectHelper: true,
                    select: function (start, end) {
                        var fromDate = moment(start).format('YYYY/MM/DD LT');
                        var endDate = moment(end).format('YYYY/MM/DD LT');
                        $scope.NewEvent = {
                            EventId: 0,
                            StartAt: fromDate,
                            EndAt: endDate,
                            IsFullDay: false,
                            Title: '',
                            Description: ''
                        }

                        $scope.ShowModal();
                    },
                    eventClick: function (event) {
                        $scope.SelectedEvent = event;
                        var fromDate = moment(event.start).format('YYYY/MM/DD LT');
                        var endDate = moment(event.end).format('YYYY/MM/DD LT');
                        $scope.NewEvent = {
                            EventId: event.id,
                            StartAt: fromDate,
                            EndAt: endDate,
                            IsFullDay: false,
                            Title: event.title,
                            Description: event.description
                        }

                        $scope.ShowModal();
                    },
                    eventAfterAllRender: function () {
                        if ($scope.events.length > 0 && isFirstTime) {
                            uiCalendarConfig.calendars.myCalendar.fullCalendar('gotoDate', $scope.events[0].start);
                            isFirstTime = false;
                        }
                    }
                }
            };

            //This function shows bootstrap modal dialog
            $scope.ShowModal = function () {
                $scope.option = {
                    templateUrl: 'modalContent.html',
                    controller: 'ModalFullCalendarCtrl',
                    backdrop: 'static',
                    resolve: {
                        NewEvent: function () {
                            return $scope.NewEvent;
                        }
                    }
                };
                //CRUD operations on Calendar starts here
                var modal = $uibModal.open($scope.option);
                modal.result.then(function (data) {
                    $scope.NewEvent = data.event;
                    switch (data.operation) {
                        case 'Save': //save
                            $http({
                                method: 'POST',
                                url: '/AgendaCalendar/SaveEvent',
                                data: $scope.NewEvent
                            }).then(function (response) {
                                if (response.data.status) {
                                    populate();
                                }
                            });
                            break;
                        case 'Delete': //delete
                            $http({
                                method: 'POST',
                                url: '/AgendaCalendar/DeleteEvent',
                                data: { 'eventID': $scope.NewEvent.EventId }
                            }).then(function (response) {
                                if (response.data.status) {
                                    populate();
                                }
                            });
                            break;
                        default:
                            break;
                    }
                }, function () {
                    console.log('Modal dialog closed');
                });
            }
        }
    ]);
}());