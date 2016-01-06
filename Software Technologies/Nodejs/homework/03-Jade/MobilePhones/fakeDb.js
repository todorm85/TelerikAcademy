var phones = [];
for (var i = 0; i < 10; i++) {
    phones.push({
        model: 'phone #' + i,
        screenSize: (i%3===0) ? '5"' : '3"',
        batteryCapacity: (i%3===0) ? '1800' : '1350',
    });
}

var tablets = [];
for (var i = 0; i < 10; i++) {
    tablets.push({
        model: 'tablet #' + i,
        screenSize: (i%3===0) ? '5"' : '3"',
        batteryCapacity: (i%3===0) ? '1800' : '1350',
    });
}

var wearables = [];
for (var i = 0; i < 10; i++) {
    wearables.push({
        model: 'wearables #' + i,
        screenSize: (i%3===0) ? '5"' : '3"',
        batteryCapacity: (i%3===0) ? '1800' : '1350',
    });
}

module.exports = {
    phones,
    tablets,
    wearables
};