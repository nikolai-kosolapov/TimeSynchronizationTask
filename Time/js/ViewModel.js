function ViewModel() {
    var self = this;
    self.time = ko.observable("Получаем время");

    self.shortTime = ko.computed(function () {
        var time = self.time();
        if (time === 'Получаем время')
            return "Получаем время";
        return time.getHours().pad(2) + ":" + time.getMinutes().pad(2) + ':' + time.getSeconds().pad(2);
    }, self);

    self.start = function() {
        getTime();
        setInterval(tick, 1000);
    };

    self.addHour = function () {
        changeHour(1);
        $.get("api/time/AddHour");
    };

    self.subtractHour = function () {
        changeHour(-1);
        $.get("api/time/SubtractHour");
    };

    var getTime = function() {
        $.get("api/time/gettime", function (data) {
            self.time(new Date(0, 0, 0, data.Hour, data.Minutes, data.Seconds, 0));
        });
    };

    var tick = function() {
        var time = self.time();
        time.setSeconds(time.getSeconds() + 1);
        self.time(time);
        getTime();
    };

    var changeHour = function (n) {
        var time = self.time();
        time.setHours(time.getHours() + n);
        self.time(time);
    };
} 