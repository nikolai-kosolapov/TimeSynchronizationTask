Number.prototype.pad = function (length) {
    var res = this.toString();
    while (res.length < length)
        res = '0' + res;
    return res;
};
