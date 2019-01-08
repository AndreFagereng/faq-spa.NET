"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
//Question class
var Questions = /** @class */ (function () {
    function Questions() {
    }
    return Questions;
}());
exports.Questions = Questions;
//Uses Enum to set the appropriate question-type.
var QEnumType;
(function (QEnumType) {
    QEnumType["Account"] = "Account";
    QEnumType["Payments"] = "Payments";
    QEnumType["Delivery"] = "Delivery";
    QEnumType["Customer"] = "Customer";
})(QEnumType = exports.QEnumType || (exports.QEnumType = {}));
//# sourceMappingURL=Questions.js.map